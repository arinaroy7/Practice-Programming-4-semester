//лексикографический порядок 
using System;

internal class Program 
{
    static void Main() {
        int length = 4; //длина комбинации символов
        GenerateCombinations(length, " "); 
    }

    static void GenerateCombinations(int dlina, string current) //принимает 2 параметра - длина комбинации и текущая комбинация символов
    {
        if (current.Length == dlina) 
        {
            Console.WriteLine(current);  
            return; //заверш фун-ии 
        }

        GenerateCombinations(dlina, current + "a");
        GenerateCombinations(dlina, current + "b");
        GenerateCombinations(dlina, current + "c");
    }
}