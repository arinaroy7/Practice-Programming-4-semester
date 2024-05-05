//все элементы массива в обратном порядке через рекурсию 
using System;
class Program {
    static void Main() {

        int[] inputArray = {5, 4, 3, 2, 1, 0};
        ReverseArray(inputArray, 0); //вызыв метод для обращения массива
    }
    static void ReverseArray(int[] items, int startIndex)
    {
        if (startIndex < items.Length)
        {
            ReverseArray(items, startIndex+1);
            Console.Write(items[startIndex] + " "); //вывод элементов для рекурсивного вызова
        }
    }
}