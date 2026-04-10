using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD
=======
internal class Prgm4
{
   delegate int Calculator(int a, int b);
   static int Add(int x, int y)
   {
       return x + y;
   }
   static int Sub(int x, int y)
   {
       return x - y;
   }
   static int Mul(int x, int y)
   {
       return x * y;
   }
   static void Calculate(int a, int b, Calculator cal)
   {
       int res = cal(a, b);
       Console.WriteLine(res);
   }
   public static void calc()
   {
       Console.Write("Enter first number: ");
       int num1 = int.Parse(Console.ReadLine());
       Console.Write("Enter second number: ");
       int num2 = int.Parse(Console.ReadLine());
       Console.Write("Addition : ");
       Calculate(num1, num2, Add);
       Console.Write("Subtraction : ");
       Calculate(num1, num2, Sub);
       Console.Write("Multiplication : ");
       Calculate(num1, num2, Mul);
       Console.ReadLine();
   }
}
>>>>>>> 62b4e7977153d6046c84db1dda5b68d8c99ac8a8

internal class Prgm4
{
    delegate int Calculator(int a, int b);

    static int Add(int x, int y)
    {
        return x + y;
    }

    static int Sub(int x, int y)
    {
        return x - y;
    }

    static int Mul(int x, int y)
    {
        return x * y;
    }

    static void Calculate(int a, int b, Calculator cal)
    {
        int res = cal(a, b);
        Console.WriteLine(res);
    }

    public static void Calc()
    {
        Console.Write("Enter first number: ");
        int num1 = int.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        int num2 = int.Parse(Console.ReadLine());

        Console.Write("Addition : ");
        Calculate(num1, num2, Add);

        Console.Write("Subtraction : ");
        Calculate(num1, num2, Sub);

        Console.Write("Multiplication : ");
        Calculate(num1, num2, Mul);

        Console.ReadLine();
    }
}