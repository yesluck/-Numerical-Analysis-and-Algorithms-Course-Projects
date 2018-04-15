## This 

Executable program is Image Warping.exe file in executable program (including test set).

This program is written in C# language, and uses Visual Studio 2013 Community compiler. The supporting running environment is Windows 7 to Windows 10 versions.


Program function and use method

*****************************************************************************

3.1 select the picture
When you use it, click the "select picture" button, select the picture dialog box from pop-up, select the picture from it, and click the "open" button to import the picture into the program.

*****************************************************************************

3.2 selection of image deformation mode
When used, one of the three kinds of "twisting", "image distortion" and "TPS mesh deformation" in the "distortion mode" column, select different image deformation methods to process the image.

*****************************************************************************

3.3 setting parameters and attributes
3.3.1 set rotation twist parameters
In the rotary distortion mode, two parameters of maximum rotation radius and rotation angle should be set. The maximum rotation radius should not exceed half of the image size. The rotation angle can be selected from -360 to 360 degrees, and each selection can increase by 5 degrees. The negative angle represents the anticlockwise rotation and distortion, and the positive angle represents clockwise rotation and distortion.

*****************************************************************************

3.3.2 set the image distortion property
In the way of image distortion and distortion, we need to select the properties of image convex or concave, and set the degree of image distortion. When you use, click on the two parts of the center of the image distortion property, the center concave and the center concave, and set the degree of distortion between 1~7.

*****************************************************************************

3.3.3 set TPS grid deformable properties
In the way of TPS mesh deformation, we need to set the number of control points. (Note: when the number of control points is more than 6, the operation time may be very long, be careful). If you need to clear the feature points, click the "clear feature point" button, then the feature point information will be cleared.
Then, we need to click the feature points that match the number of control points on the original image. Among them, the red dot represents the control point, and the blue point represents the target point. Each control point and target point are connected by green line.

*****************************************************************************

3.4 selection interpolation method
When using, one of the three kinds of "nearest neighbor interpolation", "bilinear interpolation" and "double three interpolation" in the "interpolation method" column are selected to interpolate the processed images by different interpolation methods.

*****************************************************************************

3.5 processing pictures
After the attribute is set, click the "processing picture" button below to do the picture processing.

*****************************************************************************

3.6 save the picture
After processing the picture, click the save image button below to save the picture. When using, click the "select picture" button and pop up the dialog box to select the picture. Select the picture from it and click the "save" button to save the picture to the corresponding position.

*****************************************************************************
