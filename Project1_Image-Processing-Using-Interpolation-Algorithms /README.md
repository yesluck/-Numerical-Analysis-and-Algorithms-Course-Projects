# Project1 Image Processing Using Interpolation Algorithms (Rotate & Distort & TPS)
This is my course project on "Numerical Analysis and Algorithms" course taken in my junior year in Tsinghua University. The aim of this project is to apply several interpolation methods into image processing procedures.

Note: As a course project, this project's notes, report and readme were originally written in Chinese. You can also see my report and readme in Chinese if needed.

## Executable program
Image Warping.exe file in src folder (including test set).

## Programming language and IDE
This program was written in C# language with Visual Studio 2013 Community.

## Program function and the way to use it
### Select the picture
Click the "Select Picture (选择图片)" button, select the picture from the dialog box and click the "Open (打开)" button to import your picture into the program.
### Selection of image deformation mode
Select one of the three methods including "Rotate (旋转扭曲)", "Image Distortion (图像畸变)" and "TPS" in the "Mode (扭曲变形方式)" column.
### Setting parameters and attributes
#### Set rotation parameters
In the rotation mode, two parameters, maximum rotation radius and rotation angle, should be set. The maximum rotation radius should not exceed half of the image size. The rotation angle can be selected from -360 to 360 degrees. The negative number represents anticlockwise rotation, and the positive number represents clockwise rotation.
#### Set the image distortion parameters
In the distortion mode, we need to select the properties of convex or concave, and set the degree of image distortion. When you use, click on "Center Concave (中心内凹)" or "Center Convex (中心外凸)", and set the degree of distortion between 1~7.
#### Set TPS parameters
In the TPS mode, we need to set the number of control points. (Note: when the number of control points is more than 6, the operation time may be VERY LONG, be careful). If you need to clear the control points, click the "Clear Control Points (清除特征点)" button, then the control points will be cleared.
Then, we need to click on the original picture to set control points. The number of them should match the number of control points we set just now. The red dot represents the control point, and the blue point represents the target point. Each control point and target point are connected by green line.
#### Select interpolation method
You can select one of the three interpolation methods, "Nearest Neighbor Interpolation (最近邻插值)", "Biliner Interpolation (双线性插值)" and "Bicubic Interpolation (双三次插值)", in the "Interpolation Method (插值方法)" column.
#### Process images
After the parameters and methods are set, click the "Process Image (处理图片)" button below to process the image.
#### Save pictures
After processing the image, click the "Save Image (保存图片)" button below to save the image.
