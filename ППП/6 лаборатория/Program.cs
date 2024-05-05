/*using System; 

class Program {
    static void MakePermutations(int[] permutation, int position List<int[]> result)
    {
        if (position == permutation.Length) {
            // доделать 
        }
        else {
            for (int i = 0; i<permutation.Length; i++) 
            {
                var index = Array.IndexOf(permutation, i, 0, position);
                // если i встречается среди первых position элементов масссива permutation, то index == -1
                //иначе index  - это номерп позиции элемента i в массиве 
                if (index == -1) {
                    //если число i еще не было использовано, то. ..
                    // доделать 
                }
            }
        }
    }
}*/
using System;
using System.Collections.Generic;

class Program {
    static void MakePermutations(int[] permutation, int position, List<int[]> result)
    {
        if (position == permutation.Length) {
            // Добавляем текущую перестановку в список результатов
            result.Add((int[])permutation.Clone());
        }
        else {
            for (int i = 0; i < permutation.Length; i++) 
            {
                // Проверяем, было ли число i уже использовано в текущей перестановке
                var index = Array.IndexOf(permutation, i, 0, position);
                if (index == -1) {
                    // Если число i еще не было использовано, то добавляем его в текущую перестановку и рекурсивно вызываем MakePermutations для следующей позиции
                    permutation[position] = i;
                    MakePermutations(permutation, position + 1, result);
                }
            }
        }
    }
    
    public static void Main()
    {
        TestOnSize(1);
        TestOnSize(2);
        TestOnSize(0);
        TestOnSize(3);
        TestOnSize(4);
    }

    static void TestOnSize(int size)
    {
        var result = new List<int[]>();
        MakePermutations(new int[size], 0, result); // вызов перестановки, которая выводит 0 1 1 0
        foreach (var permutation in result)
            WritePermutation(permutation);
    }

    static void WritePermutation(int[] permutation)
    {
        foreach (var i in permutation)
            Console.Write(i + " ");
        Console.WriteLine();
    }
}
