//есть массив с повторяющимися элементами - нужно вывести уникальный массив
using System;

class Program {
    static void Main() {
        int[] nums = {1, 1, 2, 3, 4, 5, 6, 7, 7, 8, 9};

        int[] uniqueNums = GetUniqueElements(nums);

        Console.WriteLine("Исходные числа: " + string.Join(",", nums));
        Console.WriteLine("Уникальные элементы: " + string.Join(",", uniqueNums));

    }

    static int[] GetUniqueElements(int[] inputNums) {
        int[] result = new int[inputNums.Length];
        int resultIndex = 0;

        for (int i = 0; i < inputNums.Length; i++) {
            bool isUnique = true;
            for (int j = i + 1; j < inputNums.Length; j++) {
                if (inputNums[i] == inputNums[j]) {
                    isUnique = false;
                    break;
                }
            }
            if (isUnique) {
                result[resultIndex++] = inputNums[i];
            }
        }

        // Создаем новый массив
        int[] uniqueNums = new int[resultIndex];
        Array.Copy(result, uniqueNums, resultIndex);
        return uniqueNums;
    }
}
