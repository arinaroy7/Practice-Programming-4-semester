//от 1 до 3999
using System; 
using System.Text;

partial class Program {
    public static string NumberToRoman(int nums)
    {

        //проверка, чтобы число было от 0 до 3999

        if (nums < 0 || nums > 3999) 
            throw new ArgumentException("Диапозон подходящих значений от 0 до 3999");
        
        if (nums == 0) return "Недопустимое значение"; 
        
        int[] values = new int[] {1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1};

        string[] romanNums = new string[] {"M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

        //Console.WriteLine("Обычные числа: " + string.Join(",", nums));
        //Console.WriteLine("Римские цифры: " + String.Join(",", ronamNums));

        StringBuilder result = new StringBuilder();

        for (int i = 0; i < values.Length; i++)
		{
    		while (nums >= values[i]) {
        		nums -= values[i];
        		result.Append(romanNums[i]);
    		}
		}
		
		return result.ToString();
	    }
	
		
	    public static void Main()
	    {
		    Console.WriteLine(NumberToRoman(2024));
	    }	
}