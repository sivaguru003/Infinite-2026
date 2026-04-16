using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

internal class Prgm2
{
    public static void txt()
    {
        string filePath = "MyFile.txt";
        Console.Write("Enter Text to append: ");
        string text = Console.ReadLine();
        StreamWriter writer = new StreamWriter(filePath, true);
        writer.WriteLine(text);
        Console.WriteLine("Text Successfully Written to the file.");
        Console.WriteLine("------------------");

    }
}