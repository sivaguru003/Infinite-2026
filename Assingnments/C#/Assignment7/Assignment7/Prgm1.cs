using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
internal class Prgm1
    {
   public static void Num()
    {
        Console.WriteLine("Enter the Numbers :");
        string s1 = Console.ReadLine();
        string num = "";
        for (int i = 0; i <= s1.Length; i++)
        {
            if (i == s1.Length || s1[i] == ' ')
            {
                if (num != "")
                {
                    int n = 0;
                    for (int j = 0; j < num.Length; j++)
                    {
                        n = n*10+(num[j]-'0');
                    }
                    int sqr =n*n;
                    if (sqr > 20)
                    {
                        Console.WriteLine(n + " - " + sqr);
                    }
                    num = "";
                }
            }
            else
            {
                num = num + s1[i];
            }
        }
    }
}
