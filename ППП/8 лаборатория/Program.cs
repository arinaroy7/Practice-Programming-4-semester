using System;

class QueensProblem
{
    static int solutionsCount = 0;

    static void Main(string[] args)
    {
        int n = 8; 

        int[,] board = new int[n, n];
        SolveQueensProblem(board, 0, n);
        Console.WriteLine($"Общее количество мирных расстановок для {n} ферзей на доске {n}x{n}: {solutionsCount}");
    }

    static void SolveQueensProblem(int[,] board, int col, int n)
    {
        if (col >= n)
        {
            PrintBoard(board, n);
            solutionsCount++;
            return;
        }

        for (int i = 0; i < n; i++)
        {
            if (IsSafe(board, i, col, n))
            {
                board[i, col] = 1;
                SolveQueensProblem(board, col + 1, n);
                board[i, col] = 0;
            }
        }
    }

    static bool IsSafe(int[,] board, int row, int col, int n)
    {
        int i, j;

        // Проверяем эту строку слева от ферзя
        for (i = 0; i < col; i++)
            if (board[row, i] == 1)
                return false;

        // Проверяем верхнюю диагональную линию слева от ферзя
        for (i = row, j = col; i >= 0 && j >= 0; i--, j--)
            if (board[i, j] == 1)
                return false;

        // Проверяем нижнюю диагональную линию слева от ферзя
        for (i = row, j = col; j >= 0 && i < n; i++, j--)
            if (board[i, j] == 1)
                return false;

        return true;
    }

    static void PrintBoard(int[,] board, int n)
    {
        Console.WriteLine("Расстановка ферзей:");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
                Console.Write(board[i, j] + " ");
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}
