using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    internal class Prgm4
    {
        const int TotalFare = 500;

    public    static void ticket()
        {
            Console.WriteLine("Enter Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Age:");
            int age = int.Parse(Console.ReadLine());
            Travel t = new Travel();
            Console.WriteLine(name);
            Console.WriteLine(t.CalculateConcession(name,age, TotalFare));
        }
internal class Travel
{
    public string CalculateConcession(String name, int age, int totalFare)
    {
            if (age <= 5)
            {
                return "Little Champs - Free Ticket";
            }
            else if (age > 60)
            {
                int fare = totalFare - (totalFare * 30/100);
                return "Senior Citizen " +" - "+ fare;
            }
            else
            { 
                return "Ticket Booked "+" - "+ totalFare;
            }
    }
}
}

