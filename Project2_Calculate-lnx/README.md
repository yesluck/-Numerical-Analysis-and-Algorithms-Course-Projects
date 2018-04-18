# Project2 Calculate ln(x) with accuracy of 32 decimal digits
This is my course project on "Numerical Analysis and Algorithms" course taken in my junior year in Tsinghua University. The aim of this project is to apply several function approximation and numerical integration methods into calculation procedures.

Note: As a course project, this project's notes, report and readme were originally written in Chinese. You can also see my report and readme in Chinese if needed.

## Executable program
LnX.exe file in src folder.

## Programming language and IDE
This program was written in C# language with Visual Studio 2013 Community.

## Program function and the way to use it
### Input X
Input the variable X into the blank after “X=”. You must ensure that:
1. This is a valid variable;
2. The variable should not be larger than 100 or less than 1;
3. The number of the input’s significance digits should not exceed 5.

### Choose the precision you need
Adjust the precision you need (the number of decimal digits) in the numerical box after ”Precision(所需精度)”. You can change the number between 0 and 32.
Notice: The precision will affect iterating times of the algorithm. By using ”Taylor(Taylor展开求解)”, “Romberg Algorithm(数值积分(龙贝格算法)求解)” and “Lagrange Interpolation Polynomial(拉格朗日插值多项式求解)”methods, the software will be able to output the result in 5 seconds. But when using “Compound Simpson Formula(复化辛普生公式)”, the calculating time would be really long, especially when the number of required decimal digits exceeds 21. So please be careful when you want to test this method.

### Start calculating!
Click on “Start Calculating(开始计算)” button and observe the output in the column.