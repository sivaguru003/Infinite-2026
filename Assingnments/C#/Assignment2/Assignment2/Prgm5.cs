using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
internal class Prog5
    {
    public static void CopyArray()
    {
        Console.Write("\nEnter number of elements: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int[] arr1 = new int[n];
        int[] arr2 = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter value for first array: ");
            arr1[i] = Convert.ToInt32(Console.ReadLine());
        }
        for (int i = 0; i < n; i++)
        {
            arr2[i] = arr1[i];
        }

        Console.WriteLine("First Array elements:");
        for (int i = 0; i < n; i++)
        {
            Console.Write(arr1[i] + " ");
        }

        Console.WriteLine("\nCopied Array elements :");
        for (int i = 0; i < n; i++)
        {
            Console.Write(arr2[i] + " ");
 
        }
    }


}

