// See https://aka.ms/new-console-template for more information
using MatrixThreadCalc;

Console.WriteLine("Hello, World!");
void MultiplreOneElement(object? param)
{
    if (param == null)
        throw new ArgumentNullException(nameof(param));
    MatrixParams matrixParams = (MatrixParams)param;
    double result = 0;
    for (int mi = 0; mi < matrixParams.dim; mi++)
    {
        result = result + matrixParams.a[matrixParams.i, mi] * matrixParams.b[mi, matrixParams.j];
    }
    matrixParams.c[matrixParams.i, matrixParams.j] = result;
}