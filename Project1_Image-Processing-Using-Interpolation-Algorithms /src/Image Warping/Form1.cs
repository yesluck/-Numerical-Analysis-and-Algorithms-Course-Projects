using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Warping
{
    /************************以下为变量类型声明部分***********************/
    public partial class Form1 : Form
    {
        /// <summary>
        /// 图像与变换属性
        /// </summary>
        public class Property
        {
            public string filename;         //文件名
            public string warp = "旋转扭曲";//扭曲方式
            public string interposition = "最近邻插值";    //插值方式
            public int saveCount = 0;
            public string saveName;
            public double length;           //图像长度
            public double lengthCenter;     //图像长方向中心点
            public double height;           //图像高度
            public double heightCenter;     //图像高方向中心点
            public int tpsPointBox;         //TPS特征点数记录
        }
        Property property = new Property();

        /// <summary>
        /// 变换前后图像与图案的存储
        /// </summary>
        public class Picture
        {
            public Bitmap oldPic;           //变换前图像
            public Bitmap newPic;           //变换后图像
            public Graphics grfx;           //TPS变形特征点及其连线图案
        }
        Picture pic = new Picture();

        /// <summary>
        /// TPS特征点
        /// </summary>
        public class TPSPoint
        {
            public int oriX = 0;
            public int oriY = 0;
            public double x = 0;
            public double y = 0;
        }
        TPSPoint[] tpsPoint ={new TPSPoint(),new TPSPoint(),new TPSPoint(),new TPSPoint(),new TPSPoint(),new TPSPoint(),new TPSPoint(),new TPSPoint(),
                      new TPSPoint(),new TPSPoint(),new TPSPoint(),new TPSPoint(),new TPSPoint(),new TPSPoint(),new TPSPoint(),new TPSPoint(),};

        /// <summary>
        /// TPS特征点连线属性
        /// </summary>
        public class TPSLine
        {
            public double x1 = 0;
            public double x2 = 0;
            public double y1 = 0;
            public double y2 = 0;
        }
        TPSLine[] line = { new TPSLine(), new TPSLine(), new TPSLine(), new TPSLine(), new TPSLine(), new TPSLine(), new TPSLine(), new TPSLine() };

        /// <summary>
        /// TPS变换的相关矩阵
        /// </summary>
        public class TPSArray
        {
            public double[][] L;
            public double[][] Y;
            public double[][] W;
        }
        TPSArray tpsArray = new TPSArray();

        public int tpsPoints = 0;           //TPS特征点对数

        /************************以上为变量类型声明部分***********************/

        /**************************以下为矩阵运算部分*************************/

        /// <summary>
        /// 递归计算行列式的值
        /// </summary>
        public double Determinant(double[][] matrix)
        {
            //二阶及以下行列式直接计算
            if (matrix.Length == 0) return 0;
            else if (matrix.Length == 1) return matrix[0][0];
            else if (matrix.Length == 2)
            {
                return matrix[0][0] * matrix[1][1] - matrix[0][1] * matrix[1][0];
            }

            //对第一行使用“加边法”递归计算行列式的值
            double dSum = 0, dSign = 1;
            for (int i = 0; i < matrix.Length; i++)
            {
                double[][] matrixTemp = new double[matrix.Length - 1][];
                for (int count = 0; count < matrix.Length - 1; count++)
                {
                    matrixTemp[count] = new double[matrix.Length - 1];
                }
                for (int j = 0; j < matrixTemp.Length; j++)
                {
                    for (int k = 0; k < matrixTemp.Length; k++)
                    {
                        matrixTemp[j][k] = matrix[j + 1][k >= i ? k + 1 : k];
                    }
                }
                dSum += (matrix[0][i] * dSign * Determinant(matrixTemp));
                dSign = dSign * -1;
            }
            return dSum;
        }

        /// <summary>
        /// 计算方阵的伴随矩阵
        /// </summary>
        public double[][] AdjointMatrix(double[][] matrix)
        {
            //制作一个伴随矩阵大小的矩阵
            double[][] result = new double[matrix.Length][];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = new double[matrix[i].Length];
            }
            //生成伴随矩阵
            for (int i = 0; i < result.Length; i++)
            {
                for (int j = 0; j < result.Length; j++)
                {
                    //存储代数余子式的矩阵（行、列数都比原矩阵少1）
                    double[][] temp = new double[result.Length - 1][];
                    for (int k = 0; k < result.Length - 1; k++)
                    {
                        temp[k] = new double[result[k].Length - 1];
                    }
                    //生成代数余子式
                    for (int x = 0; x < temp.Length; x++)
                    {
                        for (int y = 0; y < temp.Length; y++)
                        {
                            temp[x][y] = matrix[x < i ? x : x + 1][y < j ? y : y + 1];
                        }
                    }
                    result[j][i] = ((i + j) % 2 == 0 ? 1 : -1) * Determinant(temp);
                }
            }
            return result;
        }
           
        /// <summary>
        /// 求矩阵的逆矩阵
        /// </summary>
        public double[][] InverseMatrix(double[][] matrix)
        {
            //matrix必须为非空
            if (matrix == null || matrix.Length == 0)
            {
                return new double[][] { };
            }
            //matrix 必须为方阵
            int len = matrix.Length;
            for (int counter = 0; counter < matrix.Length; counter++)
            {
                if (matrix[counter].Length != len)
                {
                    throw new Exception("matrix 必须为方阵");
                }
            }
            //计算矩阵行列式的值
            double dDeterminant = Determinant(matrix);
            if (Math.Abs(dDeterminant) <= 1E-6)
            {
                throw new Exception("矩阵不可逆");
            }
            //制作一个伴随矩阵大小的矩阵
            double[][] result = AdjointMatrix(matrix);
            //矩阵的每项除以矩阵行列式的值，即为所求
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix.Length; j++)
                {
                    result[i][j] = result[i][j] / dDeterminant;
                }
            }
            return result;
        }

        /// <summary>
        /// 矩阵乘法
        /// </summary>
        public double[][] MultipleMatrix(double[][] matA, double[][] matB)
        {
            double[][] mat=new double[matA.Length][];
            for (int i = 0; i < matA.Length; i++)
			{
                mat[i] = new double[matB[0].Length];
			}

            for (int i = 0; i < mat.Length; i++)
            {
                for (int j = 0; j < mat[i].Length; j++)
                {
                    for (int k = 0; k < matA[0].Length; k++)
                    {
                        mat[i][j] += matA[i][k] * matB[k][j];
                    }
                }
            }
            return mat;
        }

        /**************************以上为矩阵运算部分*************************/

        /************************以下为必要计算方法部分***********************/

        /// <summary>
        /// 双三次插值核函数S(x)
        /// </summary>
        public double S(double x)
        {
            if (Math.Abs(x) <= 1) return 1 - 2 * Math.Abs(x) * Math.Abs(x) + Math.Pow(Math.Abs(x), 3);
            else if (Math.Abs(x) > 1 && Math.Abs(x) < 2) return 4 - 8 * Math.Abs(x) + 5 * Math.Abs(x) * Math.Abs(x) - Math.Pow(Math.Abs(x), 3);
            else return 0;
        }

        /// <summary>
        /// 径向基函数U(r)
        /// </summary>
        public double U(double x1, double y1, double x2, double y2)
        {
            double r = Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
            if (r == 0) return 0;
            else return (r * r * Math.Log(r * r));
        }

        /// <summary>
        /// 变形矩阵初始化函数
        /// </summary>
        public void TPSArrayCalculate(int num)
        {
            tpsArray.L = new double[num + 3][];
            for (int i = 0; i < num + 3; i++)
            {
                tpsArray.L[i] = new double[num + 3];
            }
            tpsArray.Y = new double[num + 3][];
            for (int i = 0; i < num + 3; i++)
            {
                tpsArray.Y[i] = new double[2];
            }
            tpsArray.W = new double[num + 3][];
            for (int i = 0; i < num + 3; i++)
            {
                tpsArray.W[i] = new double[2];
            }

            for (int i = 0; i < num; i++)
            {
                for (int j = i + 1; j < num; j++)
                {
                    tpsArray.L[i][j] = U(tpsPoint[2 * i].x, tpsPoint[2 * i].y, tpsPoint[2 * j].x, tpsPoint[2 * j].y);
                    tpsArray.L[j][i] = U(tpsPoint[2 * i].x, tpsPoint[2 * i].y, tpsPoint[2 * j].x, tpsPoint[2 * j].y);
                }
                tpsArray.L[num][i] = 1;
                tpsArray.L[i][num] = 1;
                tpsArray.L[num + 1][i] = tpsPoint[2 * i].x;
                tpsArray.L[i][num + 1] = tpsPoint[2 * i].x;
                tpsArray.L[num + 2][i] = tpsPoint[2 * i].y;
                tpsArray.L[i][num + 2] = tpsPoint[2 * i].y;
                tpsArray.Y[i][0] = tpsPoint[2 * i + 1].x;
                tpsArray.Y[i][1] = tpsPoint[2 * i + 1].y;
            }
            tpsArray.W = MultipleMatrix(InverseMatrix(tpsArray.L), tpsArray.Y);
        }

        /************************以上为必要计算方法部分***********************/

        /**************************以下为插值方法部分*************************/

        /// <summary>
        /// 最近邻插值
        /// </summary>
        public Color NearestNeighborInterposition(double x, double y, Bitmap pic)
        {
            if ((int)Math.Round(x) > 0 && (int)Math.Round(y) > 0 && (int)Math.Round(x) < property.length && (int)Math.Round(y) < property.height)
            {
                return pic.GetPixel((int)Math.Round(x), (int)Math.Round(y));
            }
            else return Color.FromArgb(0, 0, 0);
        }

        /// <summary>
        /// 双线性插值
        /// </summary>
        public Color Biliner(double x, double y, Bitmap pic)
        {
            if ((int)Math.Floor(x) > 0 && (int)Math.Floor(y) > 0 && (int)Math.Floor(x) < property.length && (int)Math.Floor(y) < property.height)
            {
                int xFloor = (int)Math.Floor(x);
                int yFloor = (int)Math.Floor(y);
                double u = x - xFloor;
                double v = y - yFloor;
                Color f00 = pic.GetPixel(xFloor, yFloor);
                Color f01 = pic.GetPixel(xFloor, yFloor);
                Color f10 = pic.GetPixel(xFloor, yFloor);
                Color f11 = pic.GetPixel(xFloor, yFloor);
                if (yFloor < property.height - 1) f01 = pic.GetPixel(xFloor, yFloor + 1);
                if (xFloor < property.length - 1) f10 = pic.GetPixel(xFloor + 1, yFloor);
                if (xFloor < property.length - 1 && yFloor < property.height - 1) f11 = pic.GetPixel(xFloor + 1, yFloor + 1);
                int r = (int)((1 - u) * (1 - v) * f00.R + (1 - u) * v * f01.R + u * (1 - v) * f10.R + u * v * f11.R);
                int g = (int)((1 - u) * (1 - v) * f00.G + (1 - u) * v * f01.G + u * (1 - v) * f10.G + u * v * f11.G);
                int b = (int)((1 - u) * (1 - v) * f00.B + (1 - u) * v * f01.B + u * (1 - v) * f10.B + u * v * f11.B);
                if (r > 255) r = 255;
                if (g > 255) g = 255;
                if (b > 255) b = 255;
                if (r < 0) r = 0;
                if (g < 0) g = 0;
                if (b < 0) b = 0;
                return Color.FromArgb(r, g, b);
            }
            else return Color.FromArgb(0, 0, 0);
        }

        /// <summary>
        /// 双三次插值
        /// </summary>
        public Color Bicubic(double x, double y, Bitmap pic)
        {
            if ((int)Math.Floor(x) > 0 && (int)Math.Floor(y) > 0 && (int)Math.Floor(x) < property.length && (int)Math.Floor(y) < property.height)
            {
                int xFloor = (int)Math.Floor(x);
                int yFloor = (int)Math.Floor(y);
                double u = x - xFloor;
                double v = y - yFloor;
                Color[,] f = new Color[4, 4];
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        f[i, j] = pic.GetPixel(xFloor, yFloor);
                    }
                }
                if (xFloor > 0 && yFloor > 0 && xFloor < property.length - 2 && yFloor < property.height - 2)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            f[i, j] = pic.GetPixel(xFloor + i - 1, yFloor + j - 1);
                        }
                    }
                }
                double r = 0;
                double g = 0;
                double b = 0;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        r += f[i, j].R * S(v + 1 - i) * S(u + 1 - j);
                        g += f[i, j].G * S(v + 1 - i) * S(u + 1 - j);
                        b += f[i, j].B * S(v + 1 - i) * S(u + 1 - j);
                    }
                }
                int ri = 0;
                int gi = 0;
                int bi = 0;
                ri = (int)r;
                gi = (int)g;
                bi = (int)b;
                if (ri > 255) ri = 255;
                if (gi > 255) gi = 255;
                if (bi > 255) bi = 255;
                if (ri < 0) ri = 0;
                if (gi < 0) gi = 0;
                if (bi < 0) bi = 0;
                return Color.FromArgb(ri, gi, bi);
            }
            else return Color.FromArgb(0, 0, 0);
        }

        /**************************以上为插值方法部分*************************/

        /************************以下为扭曲变形方式部分***********************/

        /// <summary>
        /// 1、旋转扭曲
        /// </summary>
        public void Rotate()
        {
            double row = (double)maxRBox.Value;
            double rotateAngle = (double)rotateAngleBox.Value / 180 * Math.PI;
            for (int i = 0; i < property.length; i++)
            {
                for (int j = 0; j < property.height; j++)
                {
                    //求取每个新点对应的旧点的极坐标表示
                    double r = Math.Sqrt((double)((i - property.lengthCenter) * (i - property.lengthCenter) + (j - property.heightCenter) * (j - property.heightCenter)));
                    double ang = 0;
                    if (i < property.lengthCenter)
                    {
                        ang = Math.PI + Math.Atan((double)((j - property.heightCenter) / (i - property.lengthCenter))) - rotateAngle * (row - r) / row;
                    }
                    else if (i > property.lengthCenter)
                    {
                        ang = Math.Atan((double)((j - property.heightCenter) / (i - property.lengthCenter))) - rotateAngle * (row - r) / row;
                    }
                    else if (i == property.lengthCenter && j < property.heightCenter) ang = 3 * Math.PI / 2 - rotateAngle * (row - r) / row;
                    else if (i == property.lengthCenter && j > property.heightCenter) ang = Math.PI / 2 - rotateAngle * (row - r) / row;

                    //若该点在最大旋转半径范围内，则进行旋转扭曲
                    if (Math.Abs(i - property.lengthCenter) * Math.Abs(i - property.lengthCenter) + Math.Abs(j - property.heightCenter) * Math.Abs(j - property.heightCenter) < row * row)
                    {
                        double x = r * Math.Cos(ang) + property.lengthCenter;
                        double y = r * Math.Sin(ang) + property.heightCenter;
                        //1.1、最近邻插值
                        if (nearestNeighborButton.Checked == true)
                        {
                            pic.newPic.SetPixel(i, j, NearestNeighborInterposition(x, y, pic.oldPic));
                        }
                        //1.2、双线性插值
                        if (bilinearButton.Checked == true)
                        {
                            pic.newPic.SetPixel(i, j, Biliner(x, y, pic.oldPic));
                        }
                        //1.3、双三次插值
                        if(bicubicButton.Checked==true)
                        {
                            pic.newPic.SetPixel(i, j, Bicubic(x, y, pic.oldPic));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 2、图像畸变
        /// </summary>
        public void Distort()
        {
            double R = Math.Sqrt(property.height * property.height + property.length * property.length) / (double)distortBox.Value * 2;
            for (int i = 0; i < property.length; i++)
            {
                for (int j = 0; j < property.height; j++)
                {
                    //求取每个新点对应的旧点的极坐标表示
                    double r = 0;
                    if (convexButton.Checked == true)   r = R * Math.Asin(Math.Sqrt((double)((i - property.lengthCenter) * (i - property.lengthCenter) + (j - property.heightCenter) * (j - property.heightCenter))) / R);
                    if (concaveButton.Checked == true)  r = R * Math.Sin(Math.Sqrt((double)((i - property.lengthCenter) * (i - property.lengthCenter) + (j - property.heightCenter) * (j - property.heightCenter))) / R);
                    double ang = 0;
                    if (i < property.lengthCenter)
                    {
                        ang = Math.PI + Math.Atan((double)((j - property.heightCenter) / (i - property.lengthCenter)));
                    }
                    else if (i > property.lengthCenter)
                    {
                        ang = Math.Atan((double)((j - property.heightCenter) / (i - property.lengthCenter)));
                    }
                    else if (i == property.lengthCenter && j < property.heightCenter) ang = 3 * Math.PI / 2;
                    else if (i == property.lengthCenter && j > property.heightCenter) ang = Math.PI / 2;

                    double x = r * Math.Cos(ang) + property.lengthCenter;
                    double y = r * Math.Sin(ang) + property.heightCenter;
                    //1.1、最近邻插值
                    if (nearestNeighborButton.Checked == true)
                    {
                        pic.newPic.SetPixel(i, j, NearestNeighborInterposition(x, y, pic.oldPic));
                    }
                    //1.2、双线性插值
                    if (bilinearButton.Checked == true)
                    {
                        pic.newPic.SetPixel(i, j, Biliner(x, y, pic.oldPic));
                    }
                    //1.3、双三次插值
                    if (bicubicButton.Checked == true)
                    {
                        pic.newPic.SetPixel(i, j, Bicubic(x, y, pic.oldPic));
                    }
                }
            }
        }

        /// <summary>
        /// 3、TPS网格变换
        /// </summary>
        public void TPS()
        {
            double x = 0;
            double y = 0;
            if (tpsPoints / 2 == (int)tpsPointBox.Value)
            {
                TPSArrayCalculate(tpsPoints / 2);
                for (int i = 0; i < property.length; i++)
                {
                    for (int j = 0; j < property.height; j++)
                    {
                        pic.newPic.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                    }
                }
                for (int i = 0; i < property.length; i++)
                {
                    for (int j = 0; j < property.height; j++)
                    {
                        x = 0;
                        y = 0;
                        for (int k = 0; k < (int)tpsPointBox.Value; k++)
                        {
                            x += tpsArray.W[k][0] * U(tpsPoint[2 * k].x, tpsPoint[2 * k].y, i, j);
                            y += tpsArray.W[k][1] * U(tpsPoint[2 * k].x, tpsPoint[2 * k].y, i, j);
                        }
                        x = x + tpsArray.W[(int)tpsPointBox.Value][0] + tpsArray.W[(int)tpsPointBox.Value + 1][0] * i + tpsArray.W[(int)tpsPointBox.Value + 2][0] * i;
                        y = y + tpsArray.W[(int)tpsPointBox.Value][1] + tpsArray.W[(int)tpsPointBox.Value + 1][1] * i + tpsArray.W[(int)tpsPointBox.Value + 2][1] * j;
                        if ((int)Math.Round(x) > 0 && (int)Math.Round(y) > 0 && (int)Math.Round(x) < property.length && (int)Math.Round(y) < property.height)
                        {
                            pic.newPic.SetPixel((int)Math.Round(x), (int)Math.Round(y), pic.oldPic.GetPixel(i, j));
                        }
                    }
                }
                for (int i = 2; i < property.length - 2; i++)
                {
                    for (int j = 2; j < property.height - 2; j++)
                    {
                        if (pic.newPic.GetPixel(i, j) == Color.FromArgb(0, 0, 0) && pic.newPic.GetPixel(i + 1, j) != Color.FromArgb(0, 0, 0))
                        {
                            if (pic.newPic.GetPixel(i - 1, j) != Color.FromArgb(0, 0, 0))
                            {
                                pic.newPic.SetPixel(i, j, pic.newPic.GetPixel(i - 1, j));
                                goto end;
                            }
                        }
                        if (pic.newPic.GetPixel(i, j) == Color.FromArgb(0, 0, 0) && pic.newPic.GetPixel(i - 1, j) != Color.FromArgb(0, 0, 0))
                        {
                            if (pic.newPic.GetPixel(i + 1, j) != Color.FromArgb(0, 0, 0))
                            {
                                pic.newPic.SetPixel(i, j, pic.newPic.GetPixel(i + 1, j));
                                goto end;
                            }
                        }
                        if (pic.newPic.GetPixel(i, j) == Color.FromArgb(0, 0, 0) && pic.newPic.GetPixel(i, j + 1) != Color.FromArgb(0, 0, 0))
                        {
                            if (pic.newPic.GetPixel(i, j - 1) != Color.FromArgb(0, 0, 0))
                            {
                                pic.newPic.SetPixel(i, j, pic.newPic.GetPixel(i, j - 1));
                                goto end;
                            }
                        }
                        if (pic.newPic.GetPixel(i, j) == Color.FromArgb(0, 0, 0) && pic.newPic.GetPixel(i, j - 1) != Color.FromArgb(0, 0, 0))
                        {
                            if (pic.newPic.GetPixel(i, j + 1) != Color.FromArgb(0, 0, 0))
                            {
                                pic.newPic.SetPixel(i, j, pic.newPic.GetPixel(i, j + 1));
                                goto end;
                            }
                        }
                        if (pic.newPic.GetPixel(i, j) == Color.FromArgb(0, 0, 0) && pic.newPic.GetPixel(i + 1, j + 1) != Color.FromArgb(0, 0, 0))
                        {
                            if (pic.newPic.GetPixel(i - 1, j - 1) != Color.FromArgb(0, 0, 0))
                            {
                                pic.newPic.SetPixel(i, j, pic.newPic.GetPixel(i - 1, j - 1));
                                goto end;
                            }
                        }
                        if (pic.newPic.GetPixel(i, j) == Color.FromArgb(0, 0, 0) && pic.newPic.GetPixel(i - 1, j + 1) != Color.FromArgb(0, 0, 0))
                        {
                            if (pic.newPic.GetPixel(i + 1, j - 1) != Color.FromArgb(0, 0, 0))
                            {
                                pic.newPic.SetPixel(i, j, pic.newPic.GetPixel(i + 1, j - 1));
                                goto end;
                            }
                        }
                        if (pic.newPic.GetPixel(i, j) == Color.FromArgb(0, 0, 0) && pic.newPic.GetPixel(i + 1, j + 1) != Color.FromArgb(0, 0, 0))
                        {
                            if (pic.newPic.GetPixel(i - 1, j - 1) != Color.FromArgb(0, 0, 0))
                            {
                                pic.newPic.SetPixel(i, j, pic.newPic.GetPixel(i - 1, j - 1));
                                goto end;
                            }
                        }
                        if (pic.newPic.GetPixel(i, j) == Color.FromArgb(0, 0, 0) && pic.newPic.GetPixel(i - 1, j - 1) != Color.FromArgb(0, 0, 0))
                        {
                            if (pic.newPic.GetPixel(i + 1, j + 1) != Color.FromArgb(0, 0, 0))
                            {
                                pic.newPic.SetPixel(i, j, pic.newPic.GetPixel(i + 1, j + 1));
                                goto end;
                            }
                        }
                    end: ;
                    }    
                }
            }
            else
            {
                MessageBox.Show("请将" + (int)tpsPointBox.Value + "组控制点选择完毕再进行变换！", "提示", MessageBoxButtons.OK);
            }
        }

        /************************以上为扭曲变形方式部分***********************/

        /**************************以下为图片读取部分*************************/

        public void LoadPic()
        {
            if(pictureBox1.Image==null)
            {
                MessageBox.Show("请先选择图片！", "提示", MessageBoxButtons.OK);
            }
            else
            {
                //利用Bitmap类对像素点进行处理
                pic.oldPic = new Bitmap(pictureBox1.Image);
                pic.newPic = new Bitmap(pictureBox1.Image);
                //读入图片长、宽和图片中心点，并据此设置最大半径数值框中的数值范围
                property.length = pictureBox1.Image.Width;
                property.height = pictureBox1.Image.Height;
                property.lengthCenter = (int)property.length / 2;
                property.heightCenter = (int)property.height / 2;
                if (property.height <= property.length) maxRBox.Maximum = (decimal)property.heightCenter;
                else if (property.height > property.length) maxRBox.Maximum = (decimal)property.lengthCenter;
                //显示图片属性
                picPropertyLabel.Text = "图像属性：长=" + property.length + "像素，宽=" + property.height + "像素";
                picCenterLabel.Text = "图像中心：(" + property.lengthCenter + "," + property.heightCenter + ")";
            }  
        }

        /**************************以上为图片读取部分*************************/

        /**************************以下为控件属性部分*************************/

        public Form1()
        {
            InitializeComponent();
        }

        private void rotateButton_CheckedChanged(object sender, EventArgs e)
        {
            if (rotateButton.Checked == true)
            {
                maxRBox.Enabled = true;
                rotateAngleBox.Enabled = true;
                this.rotateParameterBox.Location = new Point(29, 168);
                property.warp = "旋转扭曲";
            }
            else if (rotateButton.Checked == false)
            {
                maxRBox.Enabled = false;
                rotateAngleBox.Enabled = false;
                this.rotateParameterBox.Location = new Point(396, 44);
            }
        }

        private void distortButton_CheckedChanged(object sender, EventArgs e)
        {
            if (distortButton.Checked == true)
            {
                convexButton.Enabled = true;
                concaveButton.Enabled = true;
                this.distortParameterBox.Location = new Point(29, 168);
                property.warp = "图像畸变";
            }
            else if (distortButton.Checked == false)
            {
                convexButton.Enabled = false;
                concaveButton.Enabled = false;
                this.distortParameterBox.Location = new Point(197, 168);
            }
        }

        private void tpsButton_CheckedChanged(object sender, EventArgs e)
        {
            if (tpsButton.Checked == true)
            {
                tpsPointBox.Enabled = true;
                this.tpsParameterBox.Location = new Point(29, 168);
                pic.grfx = pictureBox1.CreateGraphics();
                bilinearButton.Enabled = false;
                bicubicButton.Enabled = false;
                nearestNeighborButton.Checked = true;
                property.warp = "TPS网格变形";
            }
            else if (tpsButton.Checked == false)
            {
                tpsPointBox.Enabled = false;
                this.tpsParameterBox.Location = new Point(345, 168);
                bilinearButton.Enabled = true;
                bicubicButton.Enabled = true;
                tpsPoints = 0;
                for (int i = 0; i < 8; i++)
                {
                    tpsPoint[2 * i].x = 0;
                    tpsPoint[2 * i].y = 0;
                    tpsPoint[2 * i + 1].x = 0;
                    tpsPoint[2 * i + 1].y = 0;
                    line[i].x1 = 0;
                    line[i].x2 = 0;
                    line[i].y1 = 0;
                    line[i].y2 = 0;
                    pictureBox1.Image = pic.oldPic;
                }
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if(tpsButton.Checked==true)
            {
                if (tpsButton.Checked == true && tpsPoints < 2 * (int)tpsPointBox.Value)
                {
                    tpsPoint[tpsPoints].oriX = e.X;
                    tpsPoint[tpsPoints].oriY = e.Y;
                    tpsPoint[tpsPoints].x = (double)e.X * property.length / (double)375;
                    tpsPoint[tpsPoints].y = (double)e.Y * property.height / (double)375;
                    Rectangle rec = new Rectangle(e.X - 2, e.Y - 2, 4, 4);
                    if (tpsPoints % 2 == 1) pic.grfx.DrawEllipse(new Pen(Color.Blue, 3), rec);
                    else if (tpsPoints % 2 == 0) pic.grfx.DrawEllipse(new Pen(Color.Red, 3), rec);
                    tpsPoints++;
                    if (tpsPoints % 2 == 0)
                    {
                        line[tpsPoints / 2 - 1].x1 = tpsPoint[tpsPoints - 2].oriX;
                        line[tpsPoints / 2 - 1].y1 = tpsPoint[tpsPoints - 2].oriY;
                        line[tpsPoints / 2 - 1].x2 = tpsPoint[tpsPoints - 1].oriX;
                        line[tpsPoints / 2 - 1].y2 = tpsPoint[tpsPoints - 1].oriY;
                        Point pt1 = new Point((int)line[tpsPoints / 2 - 1].x1, (int)line[tpsPoints / 2 - 1].y1);
                        Point pt2 = new Point((int)line[tpsPoints / 2 - 1].x2, (int)line[tpsPoints / 2 - 1].y2);
                        pic.grfx.DrawLine(new Pen(Color.Green, 2), pt1, pt2);
                    }
                }
                else MessageBox.Show("选择的TPS控制点超标！请点击“处理图片”开始处理，或增加特征点个数。", "提示", MessageBoxButtons.OK);
            }
        }

        private void clearTPS_Click(object sender, EventArgs e)
        {
            tpsPoints = 0;
            for (int i = 0; i < 8; i++)
            {
                tpsPoint[2 * i].x = 0;
                tpsPoint[2 * i].y = 0;
                tpsPoint[2 * i + 1].x = 0;
                tpsPoint[2 * i + 1].y = 0;
                line[i].x1 = 0;
                line[i].x2 = 0;
                line[i].y1 = 0;
                line[i].y2 = 0;
                pictureBox1.Image = pic.oldPic;
            }
        }

        private void tpsPointBox_ValueChanged(object sender, EventArgs e)
        {
            if ((int)tpsPointBox.Value < property.tpsPointBox)
            {
                tpsPoints = 0;
                for (int i = 0; i < 8; i++)
                {
                    tpsPoint[2 * i].x = 0;
                    tpsPoint[2 * i].y = 0;
                    tpsPoint[2 * i + 1].x = 0;
                    tpsPoint[2 * i + 1].y = 0;
                    line[i].x1 = 0;
                    line[i].x2 = 0;
                    line[i].y1 = 0;
                    line[i].y2 = 0;
                    pictureBox1.Image = pic.oldPic;
                }
            }
            property.tpsPointBox = (int)tpsPointBox.Value;
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            DialogResult responseDiaglogResult;
            openFileDialog.InitialDirectory = Application.StartupPath;
            responseDiaglogResult = openFileDialog.ShowDialog();
            if (responseDiaglogResult != DialogResult.Cancel)
            {
                property.filename = openFileDialog.FileName;
                pictureBox1.Image = new Bitmap(openFileDialog.OpenFile());
                pictureBox2.Image = pictureBox1.Image;
                LoadPic();
                tpsPoints = 0;
                for (int i = 0; i < 8; i++)
                {
                    tpsPoint[2 * i].x = 0;
                    tpsPoint[2 * i].y = 0;
                    tpsPoint[2 * i + 1].x = 0;
                    tpsPoint[2 * i + 1].y = 0;
                    line[i].x1 = 0;
                    line[i].x2 = 0;
                    line[i].y1 = 0;
                    line[i].y2 = 0;
                    pictureBox1.Image = pic.oldPic;
                }
            }
        }

        private void disposeButton_Click(object sender, EventArgs e)
        {
            if (rotateButton.Checked == true) Rotate();
            else if (distortButton.Checked == true) Distort();
            else if (tpsButton.Checked == true) TPS();
            pictureBox2.Image = pic.newPic;
            LoadPic();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (nearestNeighborButton.Checked == true) property.interposition = "最近邻插值";
            else if (bilinearButton.Checked == true) property.interposition = "双线性插值";
            else if (bicubicButton.Checked == true) property.interposition = "双三次插值";
            if (pic.newPic != null)
            {
                DialogResult responseDiaglogResult;
                saveFileDialog.InitialDirectory = Application.StartupPath;
                responseDiaglogResult = saveFileDialog.ShowDialog();
                if (responseDiaglogResult != DialogResult.Cancel)
                {
                    property.saveName = property.filename + property.saveCount + property.warp + property.interposition;
                    pictureBox2.Image.Save(property.saveName + ".jpg");
                    property.saveCount++;
                }
            }
            else MessageBox.Show("请先导入并处理图像后再保存！", "提示", MessageBoxButtons.OK);
        }

        /**************************以上为控件属性部分*************************/

    }
}