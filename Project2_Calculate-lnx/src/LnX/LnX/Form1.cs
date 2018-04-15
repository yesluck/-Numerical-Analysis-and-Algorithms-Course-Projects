using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace LnX
{
    public partial class Form1 : Form
    {
        static int precision;

        /// <summary>
        /// 大数类
        /// </summary>
        public class BigNum
        {
            public int[] integerNum;    //整数部分
            public int[] decimalNum;    //小数部分
            public int symbol = 1;      //符号位（1为正，-1为负）

            /// <summary>
            /// 构造函数1：以小数位数与整数位数为输入，构造大数对象
            /// </summary>
            /// <param name="decLen"></param>
            /// <param name="intLen"></param>
            public BigNum (int decLen,int intLen)
            {
                integerNum = new int[intLen];
                decimalNum = new int[decLen];
            }

            /// <summary>
            /// 构造函数2：以字符串为输入，构造大数对象
            /// </summary>
            /// <param name="str"></param>
            public BigNum (string str)
            {
                integerNum = new int[str.IndexOf('.')];
                decimalNum = new int[str.Length - str.IndexOf('.') - 1];
                for (int i = 0; i < str.IndexOf('.'); i++)
                {
                    integerNum[i] = str[i] - '0';
                }
                for (int i = str.IndexOf('.') + 1; i < str.Length; i++)
                {
                    decimalNum[i - str.IndexOf('.') - 1] = str[i] - '0';
                }
            }

            /// <summary>
            /// 构造函数3：以大数为输入，复制一个大数对象
            /// </summary>
            /// <param name="bignum"></param>
            public BigNum (BigNum bignum)
            {
                integerNum = new int[bignum.integerNum.Length];
                decimalNum = new int[bignum.decimalNum.Length];
                integerNum = bignum.integerNum;
                decimalNum = bignum.decimalNum;
                symbol = bignum.symbol;
            }

            /// <summary>
            /// 构造函数4：直接构造(50,50)大数对象
            /// </summary>
            public BigNum()
            {
                integerNum = new int[50];
                decimalNum = new int[50];
            }

            /// <summary>
            /// 重载“+”运算符
            /// </summary>
            /// <param name="bignum1"></param>
            /// <param name="bignum2"></param>
            /// <returns></returns>
            public static BigNum operator+ (BigNum bignum1,BigNum bignum2)
            {
                int carry = 0;  //进位标记
                BigNum returnResult = new BigNum(50, 50);   //这个变量其实并不会被用到！但是如果在最后不return它，编译器会认为有些情况可能无return。
                //情况1：同号相加
                if (bignum1.symbol == bignum2.symbol)
                {
                    //第一步：处理小数部分。
                    //1.1:如果二者小数部分位数不同，将短的末尾补上0。
                    int decLen;
                    int[] decimalResult;
                    if (bignum1.decimalNum.Length != bignum2.decimalNum.Length)
                    {
                        int lenGap;
                        int[] shortTemp;
                        if (bignum1.decimalNum.Length > bignum2.decimalNum.Length)
                        {
                            lenGap = bignum1.decimalNum.Length - bignum2.decimalNum.Length;
                            shortTemp = new int[bignum2.decimalNum.Length];
                            shortTemp = bignum2.decimalNum;
                            bignum2.decimalNum = new int[bignum1.decimalNum.Length];
                            for (int i = 0; i < shortTemp.Length; i++)
                            {
                                bignum2.decimalNum[i] = shortTemp[i];
                            }
                            for (int i = 0; i < lenGap; i++)
                            {
                                bignum2.decimalNum[shortTemp.Length + i] = 0;
                            }
                        }
                        else if (bignum1.decimalNum.Length < bignum2.decimalNum.Length)
                        {
                            lenGap = bignum2.decimalNum.Length - bignum1.decimalNum.Length;
                            shortTemp = new int[bignum1.decimalNum.Length];
                            shortTemp = bignum1.decimalNum;
                            bignum1.decimalNum = new int[bignum2.decimalNum.Length];
                            for (int i = 0; i < shortTemp.Length; i++)
                            {
                                bignum1.decimalNum[i] = shortTemp[i];
                            }
                            for (int i = 0; i < lenGap; i++)
                            {
                                bignum1.decimalNum[shortTemp.Length + i] = 0;
                            }
                        }
                    }
                    //1.2:对位大数相加，若过10则进位
                    decLen = bignum1.decimalNum.Length;
                    decimalResult = new int[decLen];
                    for (int i = decLen - 1; i >= 0; i--)
                    {
                        if (carry == 0) decimalResult[i] = bignum1.decimalNum[i] + bignum2.decimalNum[i];
                        else if (carry == 1)
                        {
                            decimalResult[i] = bignum1.decimalNum[i] + bignum2.decimalNum[i] + 1;
                            carry = 0;
                        }
                        if (decimalResult[i] >= 10)
                        {
                            decimalResult[i] = decimalResult[i] - 10;
                            carry = 1;
                        }
                    }
                    //第二步：处理整数部分。
                    //2.1:如果整数部分二者位数不同，将短的开头补上0。
                    int intLen;
                    int[] integerResult;
                    if (bignum1.integerNum.Length != bignum2.integerNum.Length)
                    {
                        int lenGap;
                        int[] shortTemp;
                        if (bignum1.integerNum.Length > bignum2.integerNum.Length)
                        {
                            lenGap = bignum1.integerNum.Length - bignum2.integerNum.Length;
                            shortTemp = new int[bignum2.integerNum.Length];
                            shortTemp = bignum2.integerNum;
                            bignum2.integerNum = new int[bignum1.integerNum.Length];
                            for (int i = 0; i < lenGap; i++)
                            {
                                bignum2.integerNum[i] = 0;
                            }
                            for (int i = 0; i < shortTemp.Length; i++)
                            {
                                bignum2.integerNum[lenGap + i] = shortTemp[i];
                            }
                        }
                        else if (bignum1.integerNum.Length < bignum2.integerNum.Length)
                        {
                            lenGap = bignum2.integerNum.Length - bignum1.integerNum.Length;
                            shortTemp = new int[bignum1.integerNum.Length];
                            shortTemp = bignum1.integerNum;
                            bignum1.integerNum = new int[bignum2.integerNum.Length];
                            for (int i = 0; i < lenGap; i++)
                            {
                                bignum1.integerNum[i] = 0;
                            }
                            for (int i = 0; i < shortTemp.Length; i++)
                            {
                                bignum1.integerNum[lenGap + i] = shortTemp[i];
                            }
                        }
                    }
                    //2.2:对位大数相加，若过10则进位
                    intLen = bignum1.integerNum.Length;
                    integerResult = new int[intLen];
                    int plusFlag = 0;   //个位数是否+1
                    if (carry == 1) //若小数部分进位向整数部分，则个位数+1
                    {
                        bignum1.integerNum[intLen - 1] = bignum1.integerNum[intLen - 1] + 1;
                        carry = 0;
                        plusFlag = 1;
                    }
                    for (int i = intLen - 1; i >= 0; i--)
                    {
                        if (carry == 0) integerResult[i] = bignum1.integerNum[i] + bignum2.integerNum[i];
                        else if (carry == 1)
                        {
                            integerResult[i] = bignum1.integerNum[i] + bignum2.integerNum[i] + 1;
                            carry = 0;
                        }
                        if (integerResult[i] >= 10)
                        {
                            integerResult[i] = integerResult[i] - 10;
                            carry = 1;
                        }
                    }
                    if (plusFlag == 1)
                    {
                        bignum1.integerNum[intLen - 1] = bignum1.integerNum[intLen - 1] - 1;
                    }
                    //2.3:若对最高位还有进位，则增加一位并设置为1
                    if (carry == 1)
                    {
                        int[] shortTemp;
                        shortTemp = integerResult;
                        integerResult = new int[intLen + 1];
                        integerResult[0] = 1;
                        for (int i = 0; i < intLen; i++)
                        {
                            integerResult[i + 1] = shortTemp[i];
                        }
                        intLen++;
                    }
                    //第三步：返回结果
                    BigNum bignumResult = new BigNum(decLen, intLen);
                    bignumResult.decimalNum = decimalResult;
                    bignumResult.integerNum = integerResult;
                    if (bignum1.symbol == -1 && bignum2.symbol == -1) bignumResult.symbol = -1;
                    return bignumResult;
                }
                //情况2：异号相加->甩给“-”运算去做
                else if (bignum1.symbol != bignum2.symbol)
                {
                    BigNum bignumTemp = new BigNum(50, 50);
                    if (bignum1.symbol == 1)        //正1+负2->正1-正2
                    {
                        bignumTemp = bignum2;
                        bignumTemp.symbol = 1;
                        return bignum1 - bignumTemp;
                    }
                    else if (bignum2.symbol == 1)   //负1+正2->正2-正1
                    {
                        bignumTemp = bignum1;
                        bignumTemp.symbol = 1;
                        return bignum2 - bignumTemp;
                    }
                }
                return returnResult;
            }

            /// <summary>
            /// 重载“-”运算符
            /// </summary>
            /// <param name="bignum1"></param>
            /// <param name="bignum2"></param>
            /// <returns></returns>
            public static BigNum operator- (BigNum bignum1,BigNum bignum2)
            {
                BigNum bignum1Ori = new BigNum(50, 50);
                BigNum bignum2Ori = new BigNum(50, 50);
                bignum1Ori = bignum1;
                bignum2Ori = bignum2;
                int carry = 0;  //退位标记
                BigNum returnResult = new BigNum(50, 50);   //这个变量其实并不会被用到！但是如果在最后不return它，编译器会认为有些情况可能无return。
                //情况1：同号相减
                if (bignum1.symbol == bignum2.symbol)
                {
                    //第一步：处理小数部分。
                    //1.1:如果二者小数部分位数不同，将短的末尾补上0。
                    int decLen;
                    int[] decimalResult;
                    if (bignum1.decimalNum.Length != bignum2.decimalNum.Length)
                    {
                        int lenGap;
                        int[] shortTemp;
                        if (bignum1.decimalNum.Length > bignum2.decimalNum.Length)
                        {
                            lenGap = bignum1.decimalNum.Length - bignum2.decimalNum.Length;
                            shortTemp = new int[bignum2.decimalNum.Length];
                            shortTemp = bignum2.decimalNum;
                            bignum2.decimalNum = new int[bignum1.decimalNum.Length];
                            for (int i = 0; i < shortTemp.Length; i++)
                            {
                                bignum2.decimalNum[i] = shortTemp[i];
                            }
                            for (int i = 0; i < lenGap; i++)
                            {
                                bignum2.decimalNum[shortTemp.Length + i] = 0;
                            }
                        }
                        else if (bignum1.decimalNum.Length < bignum2.decimalNum.Length)
                        {
                            lenGap = bignum2.decimalNum.Length - bignum1.decimalNum.Length;
                            shortTemp = new int[bignum1.decimalNum.Length];
                            shortTemp = bignum1.decimalNum;
                            bignum1.decimalNum = new int[bignum2.decimalNum.Length];
                            for (int i = 0; i < shortTemp.Length; i++)
                            {
                                bignum1.decimalNum[i] = shortTemp[i];
                            }
                            for (int i = 0; i < lenGap; i++)
                            {
                                bignum1.decimalNum[shortTemp.Length + i] = 0;
                            }
                        }
                    }
                    //第二步：处理整数部分。
                    //2.1:如果整数部分二者位数不同，将短的开头补上0。
                    int intLen;
                    int[] integerResult;
                    if (bignum1.integerNum.Length != bignum2.integerNum.Length)
                    {
                        int lenGap;
                        int[] shortTemp;
                        if (bignum1.integerNum.Length > bignum2.integerNum.Length)
                        {
                            lenGap = bignum1.integerNum.Length - bignum2.integerNum.Length;
                            shortTemp = new int[bignum2.integerNum.Length];
                            shortTemp = bignum2.integerNum;
                            bignum2.integerNum = new int[bignum1.integerNum.Length];
                            for (int i = 0; i < lenGap; i++)
                            {
                                bignum2.integerNum[i] = 0;
                            }
                            for (int i = 0; i < shortTemp.Length; i++)
                            {
                                bignum2.integerNum[lenGap + i] = shortTemp[i];
                            }
                        }
                        else if (bignum1.integerNum.Length < bignum2.integerNum.Length)
                        {
                            lenGap = bignum2.integerNum.Length - bignum1.integerNum.Length;
                            shortTemp = new int[bignum1.integerNum.Length];
                            shortTemp = bignum1.integerNum;
                            bignum1.integerNum = new int[bignum2.integerNum.Length];
                            for (int i = 0; i < lenGap; i++)
                            {
                                bignum1.integerNum[i] = 0;
                            }
                            for (int i = 0; i < shortTemp.Length; i++)
                            {
                                bignum1.integerNum[lenGap + i] = shortTemp[i];
                            }
                        }
                    }
                    //第三步：比较两个数
                    int flag = 0;   //flag=1表示确定bignum1>bignum2，无需调整顺序；flag=-1表示bignum1<bignum2，需要调整顺序。flag=0表示待定。
                    BigNum temp = new BigNum(50, 50);
                    decLen = bignum1.decimalNum.Length;
                    intLen = bignum1.integerNum.Length;
                    for (int i = 0; i < intLen; i++)
                    {
                        if (bignum1.integerNum[i] > bignum2.integerNum[i])
                        {
                            flag = 1;
                            break;
                        }
                        else if (bignum1.integerNum[i] < bignum2.integerNum[i])
                        {
                            flag = -1;
                            break;
                        }
                    }
                    if (flag == 0)
                    {
                        for (int i = 0; i < decLen; i++)
                        {
                            if (bignum1.decimalNum[i] > bignum2.decimalNum[i])
                            {
                                flag = 1;
                                break;
                            }
                            else if (bignum1.decimalNum[i] < bignum2.decimalNum[i])
                            {
                                flag = -1;
                                break;
                            }
                        }
                    }
                    if (flag == -1)
                    {
                        temp = bignum1;
                        bignum1 = bignum2;
                        bignum2 = temp;
                    }
                    //第四步：小数部分对位大数相减，若不足0则退位
                    decimalResult = new int[decLen];
                    for (int i = decLen - 1; i >= 0; i--)
                    {
                        if (carry == 0) decimalResult[i] = bignum1.decimalNum[i] - bignum2.decimalNum[i];
                        else if (carry == 1)
                        {
                            decimalResult[i] = bignum1.decimalNum[i] - bignum2.decimalNum[i] - 1;
                            carry = 0;
                        }
                        if (decimalResult[i] < 0)
                        {
                            decimalResult[i] = decimalResult[i] + 10;
                            carry = 1;
                        }
                    }
                    //第五步：整数部分对位大数相减，若不足0则退位
                    integerResult = new int[intLen];
                    int minusFlag = 0;  //个位数是否-1
                    if (carry == 1) //若小数部分退位向整数部分，则个位数-1
                    {
                        bignum1.integerNum[intLen - 1] = bignum1.integerNum[intLen - 1] - 1;
                        carry = 0;
                        minusFlag = 1;
                    }
                    for (int i = intLen - 1; i >= 0; i--)
                    {
                        if (carry == 0) integerResult[i] = bignum1.integerNum[i] - bignum2.integerNum[i];
                        else if (carry == 1)
                        {
                            integerResult[i] = bignum1.integerNum[i] - bignum2.integerNum[i] - 1;
                            carry = 0;
                        }
                        if (integerResult[i] < 0)
                        {
                            integerResult[i] = integerResult[i] + 10;
                            carry = 1;
                        }
                    }
                    if (minusFlag == 1)
                    {
                        bignum1.integerNum[intLen - 1] = bignum1.integerNum[intLen - 1] + 1;
                    }
                    //第六步：整数位去零
                    int firstNonZero = intLen - 1;      //第一个非零位，其中intLen-1表示初始状态
                    for (int i = 0; i < intLen; i++)
                    {
                        if (integerResult[i] != 0)
                        {
                            firstNonZero = i;
                            break;
                        }
                    }
                    if (firstNonZero != 0)
                    {
                        int[] zeroTemp = new int[intLen];
                        zeroTemp = integerResult;
                        integerResult = new int[intLen - firstNonZero];
                        for (int i = 0; i < intLen - firstNonZero; i++)
                        {
                            integerResult[i] = zeroTemp[i + firstNonZero];
                        }
                    }
                    //第七步：返回结果
                    BigNum bignumResult = new BigNum(decLen, intLen);
                    bignumResult.decimalNum = decimalResult;
                    bignumResult.integerNum = integerResult;
                    if (flag * bignum1.symbol == -1) bignumResult.symbol = -1;
                    return bignumResult;
                }
                //情况2：异号相减->甩给“+”运算去做
                else if (bignum1.symbol != bignum2.symbol)
                {
                    BigNum bignumTemp = new BigNum(50, 50);
                    if (bignum1.symbol == 1)        //正1-负2->正1+正2
                    {
                        bignumTemp = bignum2;
                        bignumTemp.symbol = 1;
                        return bignum1 + bignumTemp;
                    }
                    else if (bignum2.symbol == 1)   //负1-正2->-(正1+正2)
                    {
                        bignumTemp = bignum1;
                        bignumTemp.symbol = 1;
                        returnResult = bignum2 + bignumTemp;
                        returnResult.symbol = -1;
                        return returnResult;
                    }
                }
                bignum1 = bignum1Ori;
                bignum2 = bignum2Ori;
                return returnResult;
            }
        
            /// <summary>
            /// 重载“*”运算符
            /// </summary>
            /// <param name="bignum1"></param>
            /// <param name="bignum2"></param>
            /// <returns></returns>
            public static BigNum operator* (BigNum bignum1,BigNum bignum2)
            {
                int len1 = bignum1.integerNum.Length + bignum1.decimalNum.Length;
                int len2 = bignum2.integerNum.Length + bignum2.decimalNum.Length;
                int decLen = bignum1.decimalNum.Length + bignum2.decimalNum.Length;
                //第一步：去除小数点，进行单纯数乘
                int[] bignum1Whole = new int[len1];
                int[] bignum2Whole = new int[len2];
                int[] resultWhole = new int[len1 + len2];
                for (int i = 0; i < bignum1.integerNum.Length; i++)
                {
                    bignum1Whole[i] = bignum1.integerNum[i];
                }
                for (int i = 0; i < bignum1.decimalNum.Length; i++)
                {
                    bignum1Whole[i + bignum1.integerNum.Length] = bignum1.decimalNum[i];
                }
                for (int i = 0; i < bignum2.integerNum.Length; i++)
                {
                    bignum2Whole[i] = bignum2.integerNum[i];
                }
                for (int i = 0; i < bignum2.decimalNum.Length; i++)
                {
                    bignum2Whole[i + bignum2.integerNum.Length] = bignum2.decimalNum[i];
                }
                //第二步：循环进行相乘与相加
                int multiCarry = 0; //乘法进位
                int addCarry = 0;   //加法进位
                for (int i = bignum2Whole.Length - 1; i >= 0; i--)
                {
                    multiCarry = 0;
                    addCarry = 0;
                    for (int j = bignum1Whole.Length - 1; j >= 0; j--)
                    {
                        int temp1 = bignum1Whole[j] * bignum2Whole[i] + multiCarry;
                        multiCarry = temp1 / 10;
                        temp1 = temp1 % 10;
                        int temp2 = resultWhole[i + j + 1] + temp1 + addCarry;
                        addCarry = temp2 / 10;
                        resultWhole[i + j + 1] = temp2 % 10;
                    }
                    resultWhole[i] += multiCarry + addCarry;
                }
                //第三步：高位去零
                int firstNonZero = bignum1.integerNum.Length + bignum2.integerNum.Length - 1;   //第一个非零位，其中(...-1)表示初始状态
                for (int i = 0; i < bignum1.integerNum.Length + bignum2.integerNum.Length; i++)
                {
                    if (resultWhole[i] != 0)
                    {
                        firstNonZero = i;
                        break;
                    }
                }
                if (firstNonZero != 0)
                {
                    int[] zeroTemp = new int[len1 + len2];
                    zeroTemp = resultWhole;
                    resultWhole = new int[len1 + len2 - firstNonZero];
                    for (int i = 0; i < len1 + len2 - firstNonZero; i++)
                    {
                        resultWhole[i] = zeroTemp[i + firstNonZero];
                    }
                }
                //第四步：重组结果
                BigNum bignumResult = new BigNum(decLen, len1 + len2 - firstNonZero - decLen);
                for (int i = 0; i < len1 + len2 - firstNonZero - decLen; i++)
                {
                    bignumResult.integerNum[i] = resultWhole[i];
                }
                if (bignumResult.integerNum.Length == 0) bignumResult.integerNum = new int[1];
                for (int i = 0; i < decLen; i++)
                {
                    bignumResult.decimalNum[i] = resultWhole[i + len1 + len2 - firstNonZero - decLen];
                }
                bignumResult.symbol = bignum1.symbol * bignum2.symbol;
                return bignumResult;
            }

            /// <summary>
            /// 重载“/”运算符
            /// </summary>
            /// <param name="bignum1"></param>
            /// <param name="bignum2"></param>
            /// <returns></returns>
            public static BigNum operator/ (BigNum bignum1,BigNum bignum2)
            {
                int symbol= bignum1.symbol * bignum2.symbol;
                BigNum bignum1_ori = new BigNum(bignum1);
                BigNum bignum2_ori = new BigNum(bignum2);
                BigNum bignum1Abs = new BigNum();
                BigNum bignum2Abs = new BigNum();
                BigNum Ten = new BigNum("10.0");
                bignum1Abs.integerNum = bignum1.integerNum;
                bignum1Abs.decimalNum = bignum1.decimalNum;
                bignum2Abs.integerNum = bignum2.integerNum;
                bignum2Abs.decimalNum = bignum2.decimalNum;
                while (bignum2.integerNum.Length == 1 && bignum2.integerNum[0] == 0)
                {
                    bignum2 = bignum2 * Ten;
                    bignum1 = bignum1 * Ten;
                }
                //第零步：预操作
                //由于除法是一个结果小数位数不取决于输入的运算（而且可能无限），因此将小数位数截断为(精度+5)，如20+5=25。
                //小数位数从bignum1（被除数）中获取，bignum1应预先调整到一定的小数位数（~待编写，顺带把int->bignum1也编了~）
                //bignum2（除数）小数最末端的0应该先全部去除
                int len1 = bignum1.integerNum.Length + bignum1.decimalNum.Length;
                int len2 = bignum2.integerNum.Length + bignum2.decimalNum.Length;
                int decLen = bignum1.decimalNum.Length + bignum2.decimalNum.Length; //在这里应该没有卵用，到时候记得删
                int intLen1 = bignum1.integerNum.Length;
                int intLen2 = bignum2.integerNum.Length;
                //第一步：去除小数点
                int[] bignum1Whole = new int[precision + len2 + 4]; //商的长度=精度+5；被除数长度-除数长度+1=商的长度->被除数长度=商的长度+除数长度-1=精度+除数长度+4
                int[] bignum2Whole = new int[len2];
                int[] resultWhole = new int[len1 + len2];
                for (int i = 0; i < bignum1.integerNum.Length && i < precision + len2 + 4; i++)
                {
                    bignum1Whole[i] = bignum1.integerNum[i];
                }
                for (int i = 0; i < bignum1.decimalNum.Length && i + bignum1.integerNum.Length < precision + 5; i++)
                {
                    bignum1Whole[i + bignum1.integerNum.Length] = bignum1.decimalNum[i];
                }
                for (int i = 0; i < bignum2.integerNum.Length; i++)
                {
                    bignum2Whole[i] = bignum2.integerNum[i];
                }
                for (int i = 0; i < bignum2.decimalNum.Length; i++)
                {
                    bignum2Whole[i + bignum2.integerNum.Length] = bignum2.decimalNum[i];
                }
                //第二步：将去除小数点的除数转换为大数对象（在最后加上".0"，因为这样能够直接利用大数减法）
                BigNum bignum2W = new BigNum(1, len2);
                bignum2W.integerNum = bignum2Whole;
                bignum2W.decimalNum = new int[1];
                //第三步：循环除法与减法
                int[] minuendInit = new int[len2];          //初始被减数
                int[] quotient = new int[precision + 5];    //商的长度=精度+5；被除数长度-除数长度+1=商的长度->被除数长度=商的长度+除数长度-1=精度+除数长度+4
                for (int i = 0; i < len2; i++)              //设置初始被减数：和除数等长的那部分
                {
                    minuendInit[i] = bignum1Whole[i];
                }
                int len = len2;     //被减数位数（先设为除数长度）
                BigNum bignumMinuend = new BigNum(1, len);  //被减数大数对象
                bignumMinuend.integerNum = minuendInit;
                bignumMinuend.decimalNum = new int[1];

                for (int i = 0; i < precision + 4; i++) //循环求商
                {
                    while ((bignumMinuend - bignum2W).symbol == 1)
                    {
                        bignumMinuend = bignumMinuend - bignum2W;
                        quotient[i]++;
                    }
                    //当实在减不动了，加下一位当成新的被减数
                    int oldLength = bignumMinuend.integerNum.Length;
                    int[] oldMinuend = new int[oldLength];
                    for (int j = 0; j < oldLength; j++)
                    {
                        oldMinuend = bignumMinuend.integerNum;
                    }
                    bignumMinuend.integerNum = new int[oldLength + 1];
                    for (int j = 0; j < oldLength; j++)
                    {
                        bignumMinuend.integerNum[j] = oldMinuend[j];
                    }
                    bignumMinuend.integerNum[oldLength] = bignum1Whole[len2 + i];
                }
                //第四步：补回小数点：整数位=被除数整数位-除数整数位+1
                int[] quotientInt;
                int[] quotientDec;
                if ((bignum1Abs - bignum2Abs).symbol == 1)  //如果商>=1
                {
                    quotientInt = new int[intLen1 - intLen2];
                    if (quotient[0] != 0)  //首位非零，无需去零
                    {
                        quotientInt = new int[intLen1 - intLen2 + 1];
                        for (int i = 0; i < intLen1 - intLen2 + 1 && i < quotient.Length; i++)
                        {
                            quotientInt[i] = quotient[i];
                        }
                    }
                    else if (quotient[0] == 0)
                    {
                        quotientInt = new int[intLen1 - intLen2];
                        for (int i = 0; i < intLen1 - intLen2 && i + 1 < quotient.Length; i++)//
                        {
                            quotientInt[i] = quotient[i + 1];
                        }
                    }
                    if ((precision + 5) - (intLen1 - intLen2 + 1) > 0) quotientDec = new int[(precision + 5) - (intLen1 - intLen2 + 1)];
                    else quotientDec = new int[1];
                    for (int i = 0; i < (precision + 5) - (intLen1 - intLen2 + 1); i++)
                    {
                        quotientDec[i] = quotient[i + intLen1 - intLen2 + 1];
                    }
                }
                else
                {   //如果商<1
                    quotientInt = new int[1];
                    if (intLen1 == intLen2)
                    {
                        quotientDec = new int[(precision + 5) + (intLen2 - intLen1)];
                        for (int i = 0; i < (precision + 5) - 1; i++)
                        {
                            quotientDec[i + (intLen2 - intLen1)] = quotient[i + 1];
                        }
                    }
                    else
                    {
                        quotientDec = new int[(precision + 5) + (intLen2 - intLen1 - 1)];
                        for (int i = 0; i < (precision + 5); i++)
                        {
                            quotientDec[i + (intLen2 - intLen1 - 1)] = quotient[i];
                        }
                    }
                }

                BigNum bignumResult = new BigNum(50, 50);
                if (quotientInt.Length != 0) bignumResult.integerNum = quotientInt;
                else bignumResult.integerNum = new int[1];
                bignumResult.decimalNum = quotientDec;
                bignumResult.symbol = symbol;
                bignum1 = bignum1_ori;
                bignum2 = bignum2_ori;
                return bignumResult;
            }
        
            /// <summary>
            /// 重载“^”运算符
            /// </summary>
            /// <param name="bignum1"></param>
            /// <param name="exp"></param>
            /// <returns></returns>
            public static BigNum operator^ (BigNum bignum1,int exp)
            {
                BigNum One = new BigNum("1.0");
                if (exp == 0) return One;
                BigNum bignumResult = new BigNum(50,50);
                bignumResult = bignum1;
                for (int i = 1; i < exp; i++)
                {
                    bignumResult = bignumResult * bignum1;
                }
                return bignumResult;
            }
        }

        /// <summary>
        /// 检查输入的数据是否符合规范
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public int Check(string str,int type)
        {
            int numCount = 0;       //数据位个数
            int pointCount = 0;     //小数点个数
            int integerNum = 0;     //整数部分数值
            int decimalNum = 0;     //小数部分数值
            //1、若输入不合规范返回false，并计算数据位个数与小数点个数
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] >= '0' && str[i] <= '9') numCount++;
                else if (str[i] == '.') pointCount++;
                else return 0;
            }
            //2、若数据位个数与小数点个数不合规范返回false
            if (numCount <= 0 || numCount > 5 || pointCount >= 2 || str[0] == 0) return 0;
            //3、计算整数部分与小数部分数值，若取值范围不为[1,100]返回false
            if (pointCount == 1)
            {
                if (str.IndexOf('.') == 1)
                {
                    integerNum = str[0] - '0';
                    for (int i = 2; i < str.Length; i++)
                    {
                        decimalNum = 10 * decimalNum + str[i] - '0';
                    }
                }
                else if (str.IndexOf('.') == 2)
                {
                    integerNum = 10 * (str[0] - '0') + (str[1] - '0');
                    for (int i = 3; i < str.Length; i++)
                    {
                        decimalNum = 10 * decimalNum + str[i] - '0';
                    }
                }
                else if (str.IndexOf('.') == 3)
                {
                    integerNum = 100 * (str[0] - '0') + 10 * (str[1] - '0') + (str[2] - '0');
                    for (int i = 4; i < str.Length; i++)
                    {
                        decimalNum = 10 * decimalNum + str[i] - '0';
                    }
                }
                else if (str.IndexOf('.') == 4)
                {
                    integerNum = 1000 * (str[0] - '0') + 100 * (str[1] - '0') + 10 * (str[2] - '0') + (str[3] - '0');
                    for (int i = 5; i < str.Length; i++)
                    {
                        decimalNum = 10 * decimalNum + str[i] - '0';
                    }
                }
            }
            else if (pointCount == 0)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    integerNum = 10 * integerNum + (str[i] - '0');
                }
            }
            if (integerNum > 100 || integerNum < 1) return 0;
            else if (integerNum == 100 && decimalNum != 0) return 0;
            else if (integerNum == 1 && decimalNum == 0)
            {
                if (type == 1) taylorResult.Text = "0.";
                else if (type == 2) simpsonResult.Text = "0.";
                else if (type == 3) rombergResult.Text = "0.";
                else if (type == 4) lagrangeResult.Text = "0.";
                for (int i = 0; i < precision; i++)
                {
                    if (type == 1) taylorResult.Text += "0";
                    else if (type == 2) simpsonResult.Text += "0";
                    else if (type == 3) rombergResult.Text += "0";
                    else if (type == 4) lagrangeResult.Text += "0";
                }
                if (type == 1)  taylorTime.Text = "0ms";
                else if (type == 2) simpsonTime.Text = "0ms";
                else if (type == 3) rombergTime.Text = "0ms";
                else if (type == 4) lagrangeTime.Text = "0ms";
                return 1;
            }
            return 2;
        }

        /// <summary>
        /// 将每个数（整数/小数）均转化为小数形式
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string AddPoint(string str)
        {
            int pointCount = 0;     //小数点个数
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '.') pointCount++;
            }
            if (pointCount == 0) str = str + ".0";
            return str;
        }

        /// <summary>
        /// 将精度信息转换为可比较的大数形式
        /// </summary>
        /// <returns></returns>
        public BigNum Precision2BigNum(int type)
        {
            if(type==1)
            {
                string str = "0.";
                for (int i = 0; i < precision; i++)
                {
                    str = str + "0";
                }
                str = str + "1";
                BigNum bignumResult = new BigNum(str);
                return bignumResult;
            }
            else
            {
                string str = "1";
                for (int i = 0; i < precision + 1; i++)
                {
                    str = str + "0";
                }
                str = str + ".0";
                BigNum bignumResult = new BigNum(str);
                return bignumResult;
            }
        }

        /// <summary>
        /// 将精度信息转换为龙贝格算法迭代次数
        /// </summary>
        /// <returns></returns>
        public int Precision2RombergTimes()
        {
            if (precision == 0) return 2;
            else if (precision > 0 && precision <= 3) return 3;
            else if (precision > 3 && precision <= 5) return 4;
            else if (precision > 5 && precision <= 7) return 5;
            else if (precision > 7 && precision <= 10) return 6;
            else if (precision > 10 && precision <= 13) return 7;
            else if (precision > 13 && precision <= 17) return 8;
            else if (precision > 17 && precision <= 21) return 9;
            else if (precision > 21 && precision <= 26) return 10;
            else if (precision > 26 && precision <= 31) return 11;
            else return 12;
        }

        /// <summary>
        /// 将大数转换为字符串（包含四舍五入）
        /// </summary>
        /// <param name="bignum"></param>
        /// <returns></returns>
        public string BigNum2String(BigNum bignum)
        {
            BigNum bignumResult = new BigNum(precision, 1);
            bignumResult.integerNum[0] = bignum.integerNum[0];
            for (int i = 0; i < precision; i++)
            {
                bignumResult.decimalNum[i] = bignum.decimalNum[i];
            }
            if (bignum.decimalNum.Length > precision && bignum.decimalNum[precision] >= 5)
            {
                if (bignumResult.decimalNum[precision - 1] != 9) bignumResult.decimalNum[precision - 1]++;
                else
                {
                    for (int i = 0; i < precision; i++)
                    {
                        if (bignumResult.decimalNum[precision - 1 - i] == 9)
                        {
                            bignumResult.decimalNum[precision - 1 - i] = 0;
                            if (i < precision - 1)
                            {
                                if (bignumResult.decimalNum[precision - 2 - i] != 9)
                                {
                                    bignumResult.decimalNum[precision - 2 - i]++;
                                    break;
                                }
                            }
                            else if (i == precision - 1)
                            {
                                bignumResult.integerNum[0]++;
                            }
                        }
                    }
                }
            }
            int len = bignumResult.integerNum.Length;
            string str = bignumResult.integerNum[len - 1].ToString();
            str = str + ".";
            for (int i = 0; i < precision ; i++)
            {
                str = str + bignumResult.decimalNum[i];
            }
            return str;
        }

        /// <summary>
        /// Taylor展开求解
        /// </summary>
        /// <param name="bignum"></param>
        /// <returns></returns>
        public string Taylor(BigNum bignum)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            BigNum lntResult = new BigNum(50, 50);
            BigNum bignumResult = new BigNum(50, 50);
            //准备工作：1、准备1.5\ln1.5\-1的大数类；2、准备所有大数类的副本，在进行加减法运算时必须使用副本！
            BigNum OnepFive = new BigNum("1.5");        //将1.5化为大数类
            BigNum LnOnepFive = new BigNum("0.40546510810816438197801311546435");   //将ln1.5化为大数类
            BigNum onepfiveApply = new BigNum(OnepFive);
            BigNum lnonepfiveApply = new BigNum(LnOnepFive);
            BigNum bignumApply = new BigNum(bignum);    //为了在全过程中不改变原始数据，在使用时复制一个输入数据
            //第一步：将bignumApply化为bignumApply=t*1.5^exp形式
            int exp = 0;
            while ((bignumApply - (onepfiveApply ^ (exp + 1))).symbol == 1)
            {
                exp++;
            }
            BigNum t = new BigNum(50, 50);
            t = bignum / (OnepFive ^ exp);
            //第二步：Taylor展开求lnt
            for (int i = 1; i > 0; i++)
            {
                BigNum bignumI = new BigNum(AddPoint(i.ToString()));
                BigNum Add = new BigNum(50, 50);
                BigNum tApply = new BigNum(t);
                BigNum MinusOne = new BigNum("1.0"); MinusOne.symbol = -1;
                Add = (((tApply + MinusOne) ^ i) / bignumI);
                MinusOne = new BigNum("1.0"); MinusOne.symbol = -1;
                if (i % 2 == 0)
                {
                    Add.symbol = -1;
                }
                lntResult = lntResult + Add;
                //如果加数已经小于精度，则可以停止了
                Add.symbol = 1;
                if ((Add - Precision2BigNum(1)).symbol == -1) break;
            }
            //第三步：结果相加
            bignumResult=lntResult;
            for (int i = 0; i < exp; i++)
            {
                bignumResult = bignumResult + LnOnepFive;
            }
            stopwatch.Stop();
            taylorTime.Text = stopwatch.ElapsedMilliseconds.ToString() + "ms";
            return BigNum2String(bignumResult);
        }

        /// <summary>
        /// 数值积分算法1：复合辛普森公式
        /// </summary>
        /// <param name="bignum"></param>
        /// <returns></returns>
        public string Simpson(BigNum bignum)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            BigNum lntResult = new BigNum(50, 50);
            BigNum bignumResult = new BigNum(50, 50);
            //准备工作：1、准备1.5\ln1.5\-1的大数类；2、准备所有大数类的副本，在进行加减法运算时必须使用副本！
            BigNum OnepFive = new BigNum("1.5");        //将1.5化为大数类
            BigNum LnOnepFive = new BigNum("0.40546510810816438197801311546435");   //将ln1.5化为大数类
            BigNum onepfiveApply = new BigNum(OnepFive);
            BigNum lnonepfiveApply = new BigNum(LnOnepFive);
            BigNum bignumApply = new BigNum(bignum);    //为了在全过程中不改变原始数据，在使用时复制一个输入数据
            //第一步：将bignumApply化为bignumApply=t*1.5^exp形式
            int exp = 0;
            while ((bignumApply - (onepfiveApply ^ (exp + 1))).symbol == 1)
            {
                exp++;
            }
            BigNum t = new BigNum(50, 50);
            t = bignum / (OnepFive ^ exp);
            BigNum t1 = new BigNum(50, 50);
            BigNum One = new BigNum("1.0");
            t1 = t - One;
            //第二步：数值积分求lnt
            //2.1 根据误差求等分份数
            BigNum OneDiv480 = new BigNum("0.002083333333333333333333333333333333333333333");
            BigNum n4 = new BigNum(50, 50);
            n4 = (OneDiv480 * (t1 ^ 5)) * Precision2BigNum(2);
            BigNum bignumN = new BigNum("1.0");
            int n = 0;
            for (n = 1; n > 0; n++)
            {
                bignumN = new BigNum(AddPoint(n.ToString()));
                if (((bignumN ^ 4) - n4).symbol == 1) break;
            }
            n = 2 * n;
            bignumN = new BigNum(AddPoint(n.ToString()));
            //2.2 计算
            BigNum S1 = new BigNum("1.0");
            S1 = S1 + (One / t);
            BigNum OneDivTwo = new BigNum("0.5");
            BigNum OneDivSix = new BigNum("0.166666666666666666666666666666666666666666667");
            One = new BigNum("1.0");
            BigNum Two = new BigNum("2.0");
            BigNum Four = new BigNum("4.0");
            for (int i = 0; i < n; i++)
            {
                BigNum xi = new BigNum("1.0");
                BigNum xi1 = new BigNum("1.0");
                BigNum OneDivXi = new BigNum(50, 50);
                BigNum OneDivXi1 = new BigNum(50, 50);
                BigNum bignumI = new BigNum(AddPoint(i.ToString()));
                xi = xi + ((One * t1 / bignumN) * bignumI);
                xi1 = xi + (OneDivTwo * t1 / bignumN);
                OneDivXi = One / xi;
                OneDivXi1 = One / xi1;
                S1 = S1 + (Four * OneDivXi1);
                if (i != 0) S1 = S1 + (Two * OneDivXi);
            }
            BigNum h6 = new BigNum(50, 50);
            //bignumN = new BigNum(AddPoint(n.ToString()));
            h6 = t1 * OneDivSix / bignumN;
            lntResult = h6 * S1;
            //第三步：结果相加
            bignumResult = lntResult;
            for (int i = 0; i < exp; i++)
            {
                bignumResult = bignumResult + LnOnepFive;
            }
            stopwatch.Stop();
            simpsonTime.Text = stopwatch.ElapsedMilliseconds.ToString() + "ms";
            return BigNum2String(bignumResult);
        }

        /// <summary>
        /// 数值积分算法2：龙贝格算法
        /// </summary>
        /// <param name="bignum"></param>
        /// <returns></returns>
        public string Romberg(BigNum bignum)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            BigNum lntResult = new BigNum(50, 50);
            BigNum bignumResult = new BigNum(50, 50);
            //准备工作：1、准备1.5\ln1.5\-1的大数类；2、准备所有大数类的副本，在进行加减法运算时必须使用副本！
            BigNum OnepFive = new BigNum("1.5");        //将1.5化为大数类
            BigNum LnOnepFive = new BigNum("0.40546510810816438197801311546435");   //将ln1.5化为大数类
            BigNum onepfiveApply = new BigNum(OnepFive);
            BigNum lnonepfiveApply = new BigNum(LnOnepFive);
            BigNum bignumApply = new BigNum(bignum);    //为了在全过程中不改变原始数据，在使用时复制一个输入数据
            //第一步：将bignumApply化为bignumApply=t*1.5^exp形式
            int exp = 0;
            while ((bignumApply - (onepfiveApply ^ (exp + 1))).symbol == 1)
            {
                exp++;
            }
            BigNum t = new BigNum(50, 50);
            BigNum t1 = new BigNum(50, 50);
            BigNum One = new BigNum("1.0");
            BigNum Two = new BigNum("2.0");
            BigNum Four = new BigNum("4.0");
            BigNum OneDivt=new BigNum(50,50);
            t = bignum / (OnepFive ^ exp);
            OneDivt = One / t;  One = new BigNum("1.0");
            t1 = t - One;
            //第二步:数值积分求lnt
            BigNum[,] T = new BigNum[15,15];
            T[0, 0] = t1 * (One + OneDivt);
            T[0, 0] = T[0, 0] / Two;
            for (int i = 1; i < Precision2RombergTimes(); i++)
            {
                T[0, i] = T[0, i - 1] / Two;
                BigNum Areas = new BigNum();
                Areas = Two ^ i;                    //被分成的段数2^i
                for (int j = 0; j < Math.Pow(2, i); j++)
                {
                    if (j % 2 == 1)
                    {
                        BigNum bignumJ = new BigNum(AddPoint(j.ToString()));
                        BigNum xj = new BigNum();
                        BigNum OneDivXj = new BigNum();
                        BigNum Add = new BigNum();
                        One = new BigNum("1.0");
                        xj = (bignumJ * t1) / Areas;
                        xj = xj + One;
                        OneDivXj = One / xj;    One = new BigNum("1.0");
                        Add = t1 * OneDivXj;
                        Add = Add / Areas;
                        T[0, i] = T[0, i] + Add;
                    } 
                }
            }
            BigNum den = new BigNum();
            BigNum a = new BigNum();
            BigNum b = new BigNum();
            BigNum temp = new BigNum();
            int finalFlag = 0;
            for (int i = 1; i < Precision2RombergTimes()-1; i++)
            {
                den = (Four ^ i) - One; One = new BigNum("1.0");
                b = One / den;  One = new BigNum("1.0");
                a = (Four ^ i) * b;
                for (int j = 0; j < Precision2RombergTimes() - i; j++)
                {
                    T[i, j] = a * T[i - 1, j + 1];
                    temp = b * T[i - 1, j];
                    T[i, j] = T[i, j] - temp;
                }
                temp = T[i, 0] - T[i - 1, 0];
                temp.symbol = 1;
                if ((temp - Precision2BigNum(1)).symbol == -1)
                {
                    finalFlag = i;
                    break;
                }
                finalFlag = i;
            }
            lntResult = T[finalFlag, 0];

            //第三步：结果相加
            bignumResult = lntResult;
            for (int i = 0; i < exp; i++)
            {
                bignumResult = bignumResult + LnOnepFive;
            }
            stopwatch.Stop();
            rombergTime.Text = stopwatch.ElapsedMilliseconds.ToString() + "ms";
            return BigNum2String(bignumResult);
        }

        /// <summary>
        /// 拉格朗日插值多项式逼近求解
        /// </summary>
        /// <param name="bignum"></param>
        /// <returns></returns>
        public string Lagrange(BigNum bignum)
        {
            precision = precision + 10;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            BigNum lntResult = new BigNum(50, 50);
            BigNum bignumResult = new BigNum(50, 50);
            //准备工作：1、准备1.5\ln1.5\-1的大数类；2、准备所有大数类的副本，在进行加减法运算时必须使用副本！
            BigNum OnepFive = new BigNum("1.5");        //将1.5化为大数类
            BigNum LnOnepFive = new BigNum("0.40546510810816438197801311546435");   //将ln1.5化为大数类
            BigNum onepfiveApply = new BigNum(OnepFive);
            BigNum lnonepfiveApply = new BigNum(LnOnepFive);
            BigNum bignumApply = new BigNum(bignum);    //为了在全过程中不改变原始数据，在使用时复制一个输入数据
            //第一步：将bignumApply化为bignumApply=t*1.5^exp形式
            int exp = 0;
            while ((bignumApply - (onepfiveApply ^ (exp + 1))).symbol == 1)
            {
                exp++;
            }
            BigNum t = new BigNum(50, 50);
            BigNum t1 = new BigNum(50, 50);
            BigNum One = new BigNum("1.0");
            BigNum Two = new BigNum("2.0");
            BigNum Four = new BigNum("4.0");
            BigNum OneDivt = new BigNum(50, 50);
            t = bignum / (OnepFive ^ exp);
            OneDivt = One / t; One = new BigNum("1.0");
            t1 = t - One;

            BigNum[] x = new BigNum[41];
            BigNum[] y = new BigNum[41];
            x[0] = new BigNum("1.0");       y[0] = new BigNum("0.0");
            x[1] = new BigNum("1.0125");    y[1] = new BigNum("0.01242251999855715331129312863121");
            x[2] = new BigNum("1.025");     y[2] = new BigNum("0.02469261259037150101430767543669");
            x[3] = new BigNum("1.0375");    y[3] = new BigNum("0.03681397312271631120578440423248");
            x[4] = new BigNum("1.05");      y[4] = new BigNum("0.04879016416943200306537440422316");
            x[5] = new BigNum("1.0625");    y[5] = new BigNum("0.06062462181643484258060613204042");
            x[6] = new BigNum("1.075");     y[6] = new BigNum("0.07232066157962612062038681574513");
            x[7] = new BigNum("1.0875");    y[7] = new BigNum("0.08388148398070210630882945022554");
            x[8] = new BigNum("1.1");       y[8] = new BigNum("0.09531017980432486004395212328077");
            x[9] = new BigNum("1.1125");    y[9] = new BigNum("0.10660973505825822604812772161096");
            x[10] = new BigNum("1.125");    y[10] = new BigNum("0.11778303565638345453879410947052");
            x[11] = new BigNum("1.1375");   y[11] = new BigNum("0.1288328718429684288891523659496");
            x[12] = new BigNum("1.15");     y[12] = new BigNum("0.13976194237515869737152925566766");
            x[13] = new BigNum("1.1625");   y[13] = new BigNum("0.15057285847937432505472174240599");
            x[14] = new BigNum("1.175");    y[14] = new BigNum("0.16126814759612228396849497217146");
            x[15] = new BigNum("1.1875");   y[15] = new BigNum("0.17185025692665922234009894605515");
            x[16] = new BigNum("1.2");      y[16] = new BigNum("0.18232155679395462621171802515451");
            x[17] = new BigNum("1.2125");   y[17] = new BigNum("0.19268434382950120984703380264507");
            x[18] = new BigNum("1.225");    y[18] = new BigNum("0.20294084399669030735824978928564");
            x[19] = new BigNum("1.2375");   y[19] = new BigNum("0.21309321546070831458274623275129");
            x[20] = new BigNum("1.25");     y[20] = new BigNum("0.22314355131420975576629509030983");
            x[21] = new BigNum("1.2625");   y[21] = new BigNum("0.2330938821673778386145104478541");
            x[22] = new BigNum("1.275");    y[22] = new BigNum("0.24294617861038946879232415719493");
            x[23] = new BigNum("1.2875");   y[23] = new BigNum("0.25270235355575415849891449599455");
            x[24] = new BigNum("1.3");      y[24] = new BigNum("0.26236426446749105203549598688095");
            x[25] = new BigNum("1.3125");   y[25] = new BigNum("0.271933715483641758831669494533");
            x[26] = new BigNum("1.325");    y[26] = new BigNum("0.28141245943818553129201344142834");
            x[27] = new BigNum("1.3375");   y[27] = new BigNum("0.29080219978802456103471099796438");
            x[28] = new BigNum("1.35");     y[28] = new BigNum("0.30010459245033808075051213462504");
            x[29] = new BigNum("1.3625");   y[29] = new BigNum("0.30932124755526208810762863315031");
            x[30] = new BigNum("1.375");    y[30] = new BigNum("0.3184537311185346158102472135906");
            x[31] = new BigNum("1.3875");   y[31] = new BigNum("0.32750356663845252349365308889508");
            x[32] = new BigNum("1.4");      y[32] = new BigNum("0.33647223662121293050459341021699");
            x[33] = new BigNum("1.4125");   y[33] = new BigNum("0.34536118403845895631244367455713");
            x[34] = new BigNum("1.425");    y[34] = new BigNum("0.35417181372061384855181697120966");
            x[35] = new BigNum("1.4375");   y[35] = new BigNum("0.36290549368936845313782434597749");
            x[36] = new BigNum("1.45");     y[36] = new BigNum("0.37156355643248303374804845621937");
            x[37] = new BigNum("1.4625");   y[37] = new BigNum("0.38014730012387450657429009635148");
            x[38] = new BigNum("1.475");    y[38] = new BigNum("0.38865798979178314776359467611898");
            x[39] = new BigNum("1.4875");   y[39] = new BigNum("0.39709685843764777308519954225741");
            x[40] = new BigNum("1.5");      y[40] = new BigNum("0.40546510810816438197801311546435");

            BigNum temp = new BigNum("1.0");
            BigNum tempnom = new BigNum("1.0");
            BigNum tempden = new BigNum("1.0");
            BigNum Add = new BigNum("0.0");
            BigNum productTemp = new BigNum("1.0");
            BigNum index = new BigNum();
            for (int i = 0; i <= 40; i++)
            {
                productTemp = y[i];
                for (int j = 0; j <= 40; j++)
                {
                    if (i != j)
                    {
                        temp = (t - x[j]);
                        tempden = (x[i] - x[j]);
                        temp = temp / tempden;
                        productTemp = productTemp * temp;
                    }
                }
                Add = Add + productTemp;
            }
            lntResult = Add;

            bignumResult = lntResult;
            for (int i = 0; i < exp; i++)
            {
                bignumResult = bignumResult + LnOnepFive;
            }
            precision = precision - 10;
            stopwatch.Stop();
            lagrangeTime.Text = stopwatch.ElapsedMilliseconds.ToString() + "ms";
            return BigNum2String(bignumResult);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void taylorStartButton_Click(object sender, EventArgs e)
        {
            precision = (int)precisionBox.Value;
            int check = Check(xBox.Text, 1);
            if (check == 0)
            {
                MessageBox.Show("输入数值不合规范！\n请再次确保您输入的数值符合书写规范且满足以下条件：\n· 取值范围为[1,100]\n· 有效位数不大于5", "提示", MessageBoxButtons.OK);
            }
            else if (check == 2)
            {
                BigNum input = new BigNum(AddPoint(xBox.Text));
                taylorResult.Text = Taylor(input);
            }
        }

        private void simpsonStartButton_Click(object sender, EventArgs e)
        {
            precision = (int)precisionBox.Value;
            int check = Check(xBox.Text, 2);
            if (check == 0)
            {
                MessageBox.Show("输入数值不合规范！\n请再次确保您输入的数值符合书写规范且满足以下条件：\n· 取值范围为[1,100]\n· 有效位数不大于5", "提示", MessageBoxButtons.OK);
            }
            else if (check == 2)
            {
                BigNum input = new BigNum(AddPoint(xBox.Text));
                simpsonResult.Text = Simpson(input);
            }
        }

        private void rombergStartButton_Click(object sender, EventArgs e)
        {
            precision = (int)precisionBox.Value;
            int check = Check(xBox.Text, 3);
            if (check == 0)
            {
                MessageBox.Show("输入数值不合规范！\n请再次确保您输入的数值符合书写规范且满足以下条件：\n· 取值范围为[1,100]\n· 有效位数不大于5", "提示", MessageBoxButtons.OK);
            }
            else if (check == 2)
            {
                BigNum input = new BigNum(AddPoint(xBox.Text));
                rombergResult.Text = Romberg(input);
            }
        }

        private void lagrangeStartButton_Click(object sender, EventArgs e)
        {
            precision = (int)precisionBox.Value;
            int check = Check(xBox.Text, 4);
            if (check == 0)
            {
                MessageBox.Show("输入数值不合规范！\n请再次确保您输入的数值符合书写规范且满足以下条件：\n· 取值范围为[1,100]\n· 有效位数不大于5", "提示", MessageBoxButtons.OK);
            }
            else if (check == 2)
            {
                BigNum input = new BigNum(AddPoint(xBox.Text));
                lagrangeResult.Text = Lagrange(input);
            }
        }
    }
}
