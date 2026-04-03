using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
internal class Prgm2
{
    public static void str2()
    {
        Console.Write("Enter string: ");
        string str = Console.ReadLine();
        string res = "";
        int len = str.Length;
        if (len <= 1)
        {
            res = str;
        }
        else
        {
            char a = str[0];
            char b= str[len - 1];
            res += b;
            for (int i = 1; i < len - 1; i++)
            {
                res += str[i];
            }
            res += a;
        }
        Console.WriteLine(res);
        Console.WriteLine("--------------------");
    }
}

