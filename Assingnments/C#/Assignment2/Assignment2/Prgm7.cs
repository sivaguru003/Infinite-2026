using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    internal class Prog7
    {
    public static void String2()
    {
        Console.Write("Enter a word: ");
        string word = Console.ReadLine();

        char[] chars = word.ToCharArray();
        Array.Reverse(chars);
        string rev = new string(chars);

        Console.WriteLine("Reversed word: " + rev);
    }

}

