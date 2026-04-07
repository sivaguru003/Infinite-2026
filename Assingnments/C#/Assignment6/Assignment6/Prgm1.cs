using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
internal class Prgm1
{
    public static void Displaybooks()
    {
        DisplayBookShelf();
        Console.ReadLine();
    }
    static void DisplayBookShelf()
    {
        string[] bookNames =
        {
            "Anilaadum Mundril",
            "Veedu Script",
            "Nayakan Script",
            "Neelam",
            "Vada Chennai Script"
        };
        string[] authorNames =
        {
            "Na.Muthukumar",
            "Balu Mahendra",
            "Mani Ratnam",
            "Pa.Ranjith",
            "Vetrimaaran"
        };
        Console.WriteLine("Books" + "       " + "Author's Name");
        for (int i = 0; i < bookNames.Length; i++)
        {
            Console.WriteLine(bookNames[i] + " - " + authorNames[i]);
        }
     }
}