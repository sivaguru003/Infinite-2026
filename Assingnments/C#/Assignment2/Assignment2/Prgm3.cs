using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
internal class Prog3
    {
        public static void PrintArray()
        {
        Console.Write("Enter number of elements: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int[] arr = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter value: ");
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }
        int sum = 0;
        int min = arr[0];
        int max = arr[0];
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];

            if (arr[i] > max)
            {
                max = arr[i];
            }

           else if(arr[i] < min)
            {
                min = arr[i];
            }
        }
        float avg = (float)sum / arr.Length;
        Console.WriteLine("Average value is : " + avg);
        Console.WriteLine("Minimum value is : " + min);
        Console.WriteLine("Maximum value is : " + max);
 
    }
}