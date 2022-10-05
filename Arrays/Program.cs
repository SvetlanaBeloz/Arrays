using System.Drawing;
using System.Runtime.CompilerServices;

class Program
{
    static void Main()
    {
        Console.WriteLine("Exersize 1");

        string[] units = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
        string[] dozens = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
        string[] hundreds = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
        string[] thousands = { "", "M", "MM", "MMM" };

        Console.WriteLine("Enter number");
        int number = Convert.ToInt32(Console.ReadLine());
        int digit = 0;
        int count = 0;
        int temp = number;
        int thousand = 1000;
        int humndred = 100;
        int dozen = 10;

        while (temp > 0)
        {
            digit = temp % dozen;
            temp /= dozen;
            count++;
        }
        if (count == 4)
            Console.WriteLine(thousands[number / thousand] + hundreds[number / humndred % dozen] + dozens[number / dozen % dozen]
                + units[number % dozen]);
        else if (count == 3)
            Console.WriteLine(hundreds[number / humndred] + dozens[number / dozen % dozen] + units[number % dozen]);
        else if (count == 2)
            Console.WriteLine(dozens[number / dozen] + units[number % dozen]);
        else if (count == 1)
            Console.WriteLine(units[number]);

        int numerals = 4000;
        string[] roman = new string[numerals];
        for (int i = 0; i < numerals; i++)
        {
            if (i > 0 && i < dozen)
                roman[i] = units[i];

            else if (i >= dozen && i < humndred)
                roman[i] = dozens[i / dozen] + units[i % dozen];

            else if (i >= humndred && i < thousand)
                roman[i] = hundreds[i / humndred] + dozens[i / dozen % dozen] + units[i % dozen];

            else if (i >= thousand && i < numerals)
                roman[i] = thousands[i / thousand] + hundreds[i / humndred % dozen] + dozens[i / dozen % dozen] + units[i % dozen];
        }

        for (int i = 0; i < numerals; i++)
            Console.Write(roman[i] + " ");
        Console.WriteLine("\n");

        Console.WriteLine("Exersize 2");

        Console.WriteLine("Enter number");
        int N = Convert.ToInt32(Console.ReadLine());
        string initial = "1";
        string next = "";
        for (int i = 0; i < N - 1; i++)
        {
            char digitt = '0';
            int countOfSameNumbers = 1;
            int lenght = initial.Length;
            for (int k = 0; k < lenght; k++)
            {
                if (initial[k] != digitt)
                {
                    if (k != 0)
                    {
                        next = next + countOfSameNumbers.ToString() + digitt;
                    }
                    countOfSameNumbers = 1;
                    digitt = initial[k];
                }
                else
                {
                    countOfSameNumbers++;
                }
                if (k == lenght - 1)
                {
                    next = next + countOfSameNumbers.ToString() + digitt;
                }
            }
            initial = next;
            next = "";
        }
        Console.WriteLine(initial);

        Console.WriteLine("Exersize 3");

        Console.WriteLine("Enter number");
        int M = Convert.ToInt32(Console.ReadLine());
        int[,] arr = new int[M,M];
        int direction = 1;
        int current = M * M;
        int x = 0;
        int y = 0;

        for (int i = M * M; i > 0; i--)
        {
            arr[y,x] = current--;
            if (direction == 1) x++;
            else if (direction == 2) y++;
            else if (direction == 3) x--;
            else if (direction == 4) y--;

            if (direction == 1 && (x == M - 1 || arr[y,x + 1] != 0)) direction = 2;
            else if (direction == 2 && (y == M - 1 || arr[y + 1,x] != 0)) direction = 3;
            else if (direction == 3 && (x == 0 || arr[y,x - 1] != 0)) direction = 4;
            else if (direction == 4 && (y == 1 || arr[y - 1,x] != 0)) direction = 1;

            Console.Clear();

            for (int a = 0; a < M; a++)
            {
                for (int b = 0; b < M; b++)
                    Console.Write(arr[a, b] + "\t");
                Console.WriteLine("\n");
            }
            Thread.Sleep(1000);
        }
    }
}
