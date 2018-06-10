/*If the repeated sum of squares of the digits of a number is equal to 1, it is considered to be happy.

For Example:
23 is a happy number, as:
2 ^ 2 + 3 ^ 2 = 13
1 ^ 2 + 3 ^ 2 = 10
1 ^ 2 + 0 ^ 2 = 1

Sequence of happy numbers: 1, 7, 10, 13, 19, 23, ...

If the sum of squares of digits reaches 4, 1 can never be reached thus making the number unhappy or sad.

Tasks:
(Easy) Write a program to verify whether a given number is happy or not.
(Medium) Write a program to find all the happy numbers in a range.
(Hard) Given a number, write a program to verify whether it's happy or not and to display every sum of squares operation performed till the result is obtained.*/

using System;
/*using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/

namespace HappyNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number or range separated by space: ");

            while (true)
            {
                string[] numbers = Console.ReadLine().Split(' ');
                int num1 = 0;
                int num2 = 0;
                int nums = 0; //0 - no numbers, 1 - we have one number, 2 - we have range
                nums += ReadNumber(numbers[0], ref num1);
                if (nums > 0 && numbers.Length > 1)
                    nums += ReadNumber(numbers[1], ref num2);

                switch (nums)
                {
                    case 0: Console.WriteLine("There are no numbers"); break;
                    case 1:
                        if (IsHappy(num1, true)) Console.WriteLine("Number {0} is happy", num1);
                        else Console.WriteLine("Number {0} is not happy", num1); break;
                    case 2: WriteHNFromRange(num1, num2); break;
                }
                Console.WriteLine();
                //Console.ReadKey();
            }
        }

        static int ReadNumber(string num_str, ref int num)
        {
            int ret_value = 1; //0 - no numbers, 1 - we have one number
            try
            {
                num = Convert.ToInt32(num_str);
            }
            catch (OverflowException)
            {
                Console.WriteLine("{0} is outside the range of the Int32 type.", num_str);
                ret_value = 0;
            }
            catch (FormatException)
            {
                Console.WriteLine("The {0} value '{1}' is not in a recognizable format.", num_str.GetType().Name, num_str);
                ret_value = 0;
            }

            return ret_value;
        }

        static bool IsHappy(int num, bool display)
        {
            if (num == 0) return false;

            bool happy = false;
            /*if (display)
            {
                Console.WriteLine();
                Console.WriteLine(num);
            }*/
            do
            {
                int sum = 0;
                int dig_num = num.ToString().Length;
                bool minus = false;
                foreach (char ch in num.ToString())
                {
                    if (ch == '-')
                    {
                        minus = true;
                        continue;
                    }
                    int dig = Convert.ToInt32(ch.ToString());
                    if (minus)
                    {
                        dig *= -1;
                        minus = false;
                    }
                    sum += dig * dig;
                    if (display)
                    {
                        Console.Write("{0} ^2", dig);
                        if (--dig_num > 0) Console.Write(" + ");
                    }
                }
                if (display) Console.WriteLine("= {0}", sum);
                if (sum == 1) { happy = true; break; }
                if (sum == 4) break;
                num = sum;
            }
            while (!happy);

            return happy;
        }

        static void WriteHNFromRange(int num1, int num2)
        {
            Console.WriteLine("Happy numbers from range between {0} and {1}:", num1, num2);
            bool happy = false;

            for (int i = num1; i < num2 + 1; i++)
                if (IsHappy(i, false))
                {
                    happy = true;
                    Console.WriteLine(i);
                }

            if (!happy) Console.WriteLine("no");
        }
    }
}