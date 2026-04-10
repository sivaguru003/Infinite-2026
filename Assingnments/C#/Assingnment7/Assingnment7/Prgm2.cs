using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    internal class Prgm2
    {
        public static void str()
        {
            Console.WriteLine("Enter the Words:");
            string s1 = Console.ReadLine();
            string s2 = "";
            for (int i = 0; i <= s1.Length; i++)
            {
                if (i == s1.Length || s1[i] == ',')
                {
                    if (s2.Length > 0)
                    {
                        if (s2[0] == 'a' && s2[s2.Length - 1] == 'm')
                        {
                            Console.WriteLine(s2);
                        }
                    }
                    s2 = "";
                }
                else if (s1[i] != ' ')
                {
                    s2 += s1[i];
                }
            }
        }

    }
