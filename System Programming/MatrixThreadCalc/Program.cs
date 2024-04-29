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

double[,] MultipleMatrix(int dim, double[,] a, double[,] b, Action<int> progress)
{
    var result = new double[dim, dim];
    for (int i = 0; i < dim; i++)
    {
        progress?.Invoke(i);
        for (int j = 0; j < dim; j++)
        {
            MultiplreOneElement(new MatrixParams(dim, i, j, a, b, result, null));
        }
    }
    return result;
}

// Є однопоточний варіант розрахунку множення матриць.
// Метод MultiplreOneElement адаптований для виконання в багатопоточному режимі
//  - Написати метод заповнення матриці зандомними значеннями.
//  - Написати метод розрахуеку матриці в потоках в кількості ядер
//  - Написати метод розрахунку матриці в окремих потоках по одному на один рядок
//  - Написати метод розрахунку матриці кожної клітинки в окремому потоці
//  - Зробити порівняння швидкості виконання кожного варіанта для матриць 100,1000,5000
//  - Зробити висновки з даних результатів