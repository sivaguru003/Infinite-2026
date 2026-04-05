using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
internal class Prgm2
{

    class InvalidMarksException : ApplicationException
    {
        public InvalidMarksException(string message) : base(message) { }
    }

    public static void scholarship()
    {
        try
        {
            Console.Write("Entery Your Marks: ");
            int marks = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Your Fees: ");
            double fees = Convert.ToDouble(Console.ReadLine());
            double scholarship = 0;
            if (marks >= 70)
            {
                if (marks <= 80)
                {
                    scholarship = fees * 0.20;
                }
                else if (marks <= 90)
                {
                    scholarship = fees * 0.30;
                }
                else
                {
                    scholarship = fees * 0.50;
                }
                Console.WriteLine("Scholarship: " + scholarship);
            }
            else
            {
                throw new InvalidMarksException("No Scholarship");
            }
        }
        catch (InvalidMarksException e)
        {
            Console.WriteLine(e.Message);
        }
        catch
        {
            Console.WriteLine("Invalid input");
        }
        Console.WriteLine("-------------");
    }

}

