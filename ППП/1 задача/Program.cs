using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int[] inputArray = { 4, 3, 2, 1 };

        int[] reversedArray = ReverseArray(inputArray);

        // Вывод результата
        Console.WriteLine("Исходный массив: " + string.Join(", ", inputArray));
        Console.WriteLine("Развернутый массив: " + string.Join(", ", reversedArray));
    }

    static int[] ReverseArray(int[] array)
    {
        Stack<int> stack = new Stack<int>();

        foreach (var element in array)
        {
            stack.Push(element);
        }

        int[] reversedArray = new int[array.Length];
        for (int i = 0; i < array.Length; i++)
        {
            reversedArray[i] = stack.Pop();
        }

        return reversedArray;
    }
}
