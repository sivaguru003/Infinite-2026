using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
internal class Prgm2
{
    public static void WriteAndReadFromFile()
    {
        Console.WriteLine("\n--- Write and Read from the File ---");
        string filePath = "books.txt";
        string[] books =
        {
            "Anilaadum Mundril -  Na.Muthukumar",
            "Veedu Script - Balu Mahendra",
            "Nayakan Script - Mani Ratnam",
            "Neelam - Pa. Ranjith",
            "Vada Chennai - Vetrimaaran"
        };
        File.WriteAllLines(filePath,books);
        Console.WriteLine("Data Successfully written to the file \n");
        Console.WriteLine("Reading data from file:");
        string[] fileData = File.ReadAllLines(filePath);
        foreach (string line in fileData)
        {
            Console.WriteLine(line);
        }
        Console.ReadLine();
    }
}