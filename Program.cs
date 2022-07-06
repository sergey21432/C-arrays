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
            Console.WriteLine($"Enter the size for {i + 1} dimension as positive integer:");
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

void PrintArrayTwoSize(double[,] array)
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

int[] sizeArray = SizeRequeryArray(2);

double[,] twoDimensionArray = CreateArrayDblTwoDimension(sizeArray[0], sizeArray[1]);

Console.WriteLine("Original array:");
PrintArrayTwoSize(twoDimensionArray);
Console.WriteLine();
RowSortDescending(twoDimensionArray);
Console.WriteLine("Sorted descending array:");
PrintArrayTwoSize(twoDimensionArray);
Console.WriteLine();







