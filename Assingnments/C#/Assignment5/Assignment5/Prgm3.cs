using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    internal class Prgm3
    {
    public static void book()
    {
        Console.Write("Enter number of books: ");
        int n = Convert.ToInt32(Console.ReadLine());
        string[] book = new string[n];
        string[] author = new string[n];
        int i = 0;
        while (i < n)
        {
            Console.Write("Enter Book Name: ");
            book[i] = Console.ReadLine();

            Console.Write("Enter Author Name: ");
            author[i] = Console.ReadLine();

            i++;
        }
        Console.WriteLine("Book Details:");
        i = 0;
        while (i < n)
        {
            Console.WriteLine(book[i] + " - " + author[i]);
            i++;
        }
    }
}
