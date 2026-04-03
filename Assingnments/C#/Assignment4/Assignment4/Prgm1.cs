using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
internal class Prgm1
{
    public static void str1()
    {
        Console.Write("Enter a string: ");
        string str = Console.ReadLine();
        Console.Write("Enter a position: ");
        int pos = int.Parse(Console.ReadLine());
        string res = "";
        for (int i = 0; i < str.Length; i++)
        {
            if (i != pos)
            {
                res += str[i];
            }
        }
        Console.WriteLine(res);
        Console.WriteLine("--------------------");

    }
}

