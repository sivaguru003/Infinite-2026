using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
internal class Prgm3
{
  public  static void stack()
    {
        Console.Write("Enter a Number :");
        Stack<int> s = new Stack<int>();
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
            s.Push(int.Parse(Console.ReadLine()));
        Stack<int> t = new Stack<int>();
        while (s.Count > 0)
        {
            int x = s.Pop();

            while (t.Count > 0)
            {
                int y = t.Pop();
                if (y > x)
                    s.Push(y);
                else
                {
                    t.Push(y);
                    break;
                }
            }
            t.Push(x);
        }
        while (t.Count > 0)
            Console.Write(t.Pop() + " ");
    }
}

