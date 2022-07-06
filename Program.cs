/* Задача 54: Задайте двумерный массив. Напишите программу, которая
упорядочит по убыванию элементы каждой строки двумерного массива. */

int[] SizeRequeryArray(int dimensionArray)
{
    int[] arraySize = new int[dimensionArray];
    for (int i = 0; i < dimensionArray; i++)
    {
        arraySize[i] = -1;
        while (arraySize[i] < 1)
        {
            Console.WriteLine($"Enter the size for {i + 1} dimension of array as positive integer:");
            arraySize[i] = int.Parse(Console.ReadLine());
        }
    }
    return arraySize;
}

double[,] CreateArrayDblTwoDimension(int rows, int columns)
{
    double[,] array = new double[rows, columns];
    var random = new Random();
    int integerPart = 0;
    int doubleSwitch = 0;
    double doublePart = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            integerPart = random.Next(-1000, 1001);
            doubleSwitch = random.Next(0, 3);
            if (doubleSwitch > 0) doublePart = Math.Round(random.NextDouble(), 1);
            else doublePart = 0;
            array[i, j] = integerPart + doublePart;
        }
    }
    return array;
}

void PrintArrayTwoDimension(double[,] array)
{
    int maxSymbols = 0;
    int currentSymbols = 0;
    string spaceEmpty;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            currentSymbols = array[i, j].ToString().Length;
            if (maxSymbols < currentSymbols) maxSymbols = currentSymbols;
        }
    }

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {

            currentSymbols = array[i, j].ToString().Length;
            spaceEmpty = "    ";
            for (int k = currentSymbols; k < maxSymbols; k++)
            {
                spaceEmpty += " ";
            }
            Console.Write(array[i, j] + spaceEmpty);
        }
        Console.WriteLine();
    }
}

void RowSortDescending(double[,] array)
{
    int posMax;
    double temporary;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1) - 1; j++)
        {
            posMax = j;
            for (int k = j + 1; k < array.GetLength(1); k++)
            {
                if (array[i, posMax] < array[i, k]) posMax = k;
            }
            if (posMax != j)
            {
                temporary = array[i, j];
                array[i, j] = array[i, posMax];
                array[i, posMax] = temporary;
            }
        }
    }
}

Console.WriteLine("Task 54");
int[] sizeArray = SizeRequeryArray(2);
double[,] twoDimensionArray = CreateArrayDblTwoDimension(sizeArray[0], sizeArray[1]);
Console.WriteLine();
Console.WriteLine("Original array:");
PrintArrayTwoDimension(twoDimensionArray);
Console.WriteLine();
RowSortDescending(twoDimensionArray);
Console.WriteLine("Sorted descending array:");
PrintArrayTwoDimension(twoDimensionArray);
Console.WriteLine();

/* Задача 56: Задайте прямоугольный двумерный массив. Напишите
программу, которая будет находить строку с наименьшей суммой элементов. */

int SearchRowMinSum(double[,] array)
{
    double minSumRow = 0;
    double sumCurrentRow;
    int numberRow = 1;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        sumCurrentRow = 0;
        for (int j = 0; j < array.GetLength(1); j++)
        {
            sumCurrentRow += array[i, j];
        }
        if (i == 0) minSumRow = sumCurrentRow;
        else if (sumCurrentRow < minSumRow)
        {
            minSumRow = sumCurrentRow;
            numberRow = i + 1;
        }
    }
    return numberRow;
}

Console.WriteLine("Task 56");
Console.WriteLine($"The row {SearchRowMinSum(twoDimensionArray)} has smallest sum of elements.");
Console.WriteLine();

/* Задача 58: Задайте две матрицы. Напишите программу, которая будет
находить произведение двух матриц. */

double[,] matrixProduct(double[,] array1, double[,] array2)
{
    double sum;
    int rows = array1.GetLength(0);
    int columns = array2.GetLength(1);
    double[,] matrixProduct = new double[rows, columns];
    for (int i = 0; i < array1.GetLength(0); i++)
    {
        for (int j = 0; j < array2.GetLength(1); j++)
        {
            sum = 0;
            for (int k = 0; k < array1.GetLength(1); k++)
            {
                sum += array1[i, k] * array2[k, j];
            }
            matrixProduct[i, j] = Math.Round(sum, 1);
        }
    }
    return matrixProduct;
}

Console.WriteLine("Task 58");
double[,] matrix1 = twoDimensionArray;
sizeArray = SizeRequeryArray(2);
Console.WriteLine();
double[,] matrix2 = CreateArrayDblTwoDimension(sizeArray[0], sizeArray[1]);
Console.WriteLine($"The second matrix:");
PrintArrayTwoDimension(matrix2);
Console.WriteLine();

if (matrix1.GetLength(1) != matrix2.GetLength(0)) Console.WriteLine($"Multiplication is impossible.");
else
{
    Console.WriteLine("The matrix product:");
    PrintArrayTwoDimension(
        matrixProduct(matrix1, matrix2));
}









