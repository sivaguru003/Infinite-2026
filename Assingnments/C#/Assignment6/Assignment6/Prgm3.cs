using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    internal class Prgm3
    {

    public static void CountLinesInFile()
    {
        Console.WriteLine("\n--- Count Lines in the File ---");
        string filePath = "books.txt";
        int cnt = File.ReadAllLines(filePath).Length; 
        Console.WriteLine("Total lines: " + cnt);
        Console.ReadLine();
    }
}

    

