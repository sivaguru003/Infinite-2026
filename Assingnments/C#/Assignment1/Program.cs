using System;

namespace Assignment
{
    class Progm
    {
        static void Main(string[] args)
        {
            DoOperations();
            CheckPositiveOrNegative();

            CheckEqual();

            MultiplicationTable();
            CheckValues();
        }

        static void CheckEqual()
        {
            Console.WriteLine("Enter first number:");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter second number:");
            int b = Convert.ToInt32(Console.ReadLine());

            if (a == b)
            {
                Console.WriteLine("Equal");
            }
            else
            {
                Console.WriteLine("Not Equal");
            }
        }

        static void CheckPositiveOrNegative()
        {
            Console.WriteLine("Enter a number:");
            int a = Convert.ToInt32(Console.ReadLine());

            if (a > 0)
            {
                Console.WriteLine("Positive");
            }
            else
            {
                Console.WriteLine("Negative");
            }
        }

        static void DoOperations()
        {
            Console.WriteLine("Enter first number:");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter second number:");
            int b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Sum = " + (a + b));
            Console.WriteLine("Difference = " + (a - b));
            Console.WriteLine("Multiplication = " + (a * b));

            if (b != 0)
            {
                Console.WriteLine("Division = " + (a / b));
            }
            else
            {
                Console.WriteLine("Division not possible");
            }
        }

        static void MultiplicationTable()
        {
            Console.WriteLine("Enter a number:");
            int num = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(num + " * " + i + " = " + (num * i));
            }
        }

        static void CheckValues()
        {
            Console.WriteLine("Enter first number:");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter second number:");
            int b = Convert.ToInt32(Console.ReadLine());

            if (a == b)
            {
                Console.WriteLine("Result = " + 3 * (a + b));
            }
            else
            {
                Console.WriteLine("Not same");
            }
        }
    }
}