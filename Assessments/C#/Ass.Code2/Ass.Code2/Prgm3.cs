//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//internal class Prgm3
//{
//    static void Checknumber(int num)
//    {
//        if (num < 0)
//        {
//            throw new Exception("Number is negative");
//        }
//        else
//        {
//            Console.WriteLine("Number is Positive : " + num);
//        }
//    }
//    public static void chknum()
//    {
//        try
//        {
//            Console.Write("Enter a Number: ");
//            int number = int.Parse(Console.ReadLine());

//            Checknumber(number);
//        }
//        catch (Exception ex)
//        {
//            Console.WriteLine(ex.Message);
//        }
//        Console.ReadLine();
//    }

//}

