using System;

class Program
{
    static void Main()
    {
        int count = 0;
        int ticketNumber = 0;
        
        while (count < 100)
        {
            if (IsLuckyTicket(ticketNumber))
            {
                Console.WriteLine(ticketNumber.ToString().PadLeft(6, '0'));
                count++;
            }
            ticketNumber++;
        }

        {
        int count = CountHappyTickets();
        Console.WriteLine($"Общее количество счастливых билетов: {count}");
    }

    static int CountHappyTickets()
    {
        int count = 0;

        for (int i = 0; i <= 999999; i++)
        {
            int sumFirstHalf = i / 100000 + i / 10000 % 10 + i / 1000 % 10;
            int sumSecondHalf = i / 100 % 10 + i / 10 % 10 + i % 10;

            if (sumFirstHalf == sumSecondHalf)
            {
                count++;
            }
        }

        return count;
    }
    }

    static bool IsLuckyTicket(int ticketNumber)
    {
        string ticket = ticketNumber.ToString().PadLeft(6, '0');
        int sumFirstHalf = 0;
        int sumSecondHalf = 0;

        for (int i = 0; i < 6; i++)
        {
            if (i < 3)
                sumFirstHalf += int.Parse(ticket[i].ToString());
            else
                sumSecondHalf += int.Parse(ticket[i].ToString());
        }

        return sumFirstHalf == sumSecondHalf;
    }

    
}
