using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
internal class Prog8
    {
    public  static void String3()
    {
        Console.Write("Enter first word: ");
        string str1 = Console.ReadLine();

        Console.Write("Enter second word: ");
        string str2 = Console.ReadLine();

        if (str1.Equals(str2))
        {
            Console.WriteLine("The words are the same");
        }
        else
        {
            Console.WriteLine("The words are the different");
        }
    }
}

