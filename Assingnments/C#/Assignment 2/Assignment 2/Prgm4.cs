using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
internal class Prog4
    {
    public static void Marks()
        {
            int[] marks = new int[10];
        for (int i = 0; i < 10; i++)
            {
                Console.Write("Enter mark: ");
                marks[i] = Convert.ToInt32(Console.ReadLine());
            }
            int tot = 0;
            int min = marks[0];
            int max = marks[0];
            for (int i = 0; i < 10; i++)
            {
                tot += marks[i];

            if (marks[i] < min)
            {
                min = marks[i];
            }

            else
            {
                max = marks[i];
            }
            }

            float avg = (float)tot / 10;

            Array.Sort(marks);

            Console.WriteLine("Total = " + tot);
            Console.WriteLine("Average = " + avg);
            Console.WriteLine("Minimum = " + min);
            Console.WriteLine("Maximum = " + max);
            Console.WriteLine("Ascending Order:");
            for (int i = 0; i < 10; i++)
            {
                Console.Write(marks[i] + " ");
            }
        Console.WriteLine();
        Console.WriteLine("Descending Order:");
        for (int i = 9; i >= 0; i--)
        {
            Console.Write(marks[i] + " ");
 
        }
    }

    
}
