using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
internal class Emp
{
    public int Id {get;set;}
    public string FName {get;set;}
    public string LName {get;set;}
    public string Role {get;set;}
    public DateTime Dob { get;set;}
    public DateTime Doj {get;set;}
    public string City {get;set;}
}
internal class Prgm3
{
    public static void Main(string[] args)
    {
        List<Emp> list = new List<Emp>
            {
                new Emp{Id = 1001,FName = "Malcolm",LName = "Daruwalla", Role = "Manager", Dob = new DateTime(1984,11,16), Doj = new DateTime(2011,6,8), City = "Mumbai" },
                new Emp{Id = 1002,FName = "Asdin",LName = "Dhalla", Role = "AsstManager", Dob = new DateTime(1984,8,20), Doj = new DateTime(2012,7,7), City = "Mumbai" },
                new Emp{Id = 1003,FName = "Madhavi",LName = "Oza", Role = "Consultant", Dob = new DateTime(1987,11,14), Doj = new DateTime(2015,4,12), City = "Pune" },
                new Emp{Id = 1004,FName = "Saba", LName = "Shaikh", Role = "SE", Dob = new DateTime(1990,6,3), Doj = new DateTime(2016,2,2), City = "Pune" },
                new Emp{Id = 1005,FName = "Nazia", LName = "Shaikh", Role = "SE", Dob = new DateTime(1991,3,8), Doj = new DateTime(2016,2,2), City = "Mumbai" },
                new Emp{Id = 1006,FName = "Amit", LName = "Pathak", Role = "Consultant", Dob = new DateTime(1989,11,7), Doj = new DateTime(2014,8,8), City = "Chennai" },
                new Emp{Id = 1007,FName = "Vijay", LName = "Natrajan", Role = "Consultant", Dob = new DateTime(1989,12,2), Doj = new DateTime(2015,6,1), City = "Mumbai" },
                new Emp{Id = 1008,FName = "Rahul", LName = "Dubey", Role = "Associate", Dob = new DateTime(1993,11,11), Doj = new DateTime(2014,11,6), City = "Chennai" },
                new Emp{Id = 1009,FName = "Suresh", LName = "Mistry", Role = "Associate", Dob = new DateTime(1992,8,12), Doj = new DateTime(2014,12,3), City = "Chennai" },
                new Emp{Id = 1010,FName = "Sumit", LName = "Shah", Role = "Manager", Dob = new DateTime(1991,4,12), Doj = new DateTime(2016,1,2), City = "Pune" }
            };
            Console.WriteLine("All the Employees:");
            list.ForEach(Print);
            Console.WriteLine("--------------------");

            Console.WriteLine("Employees are not from the Mumbai:");
            list.Where(e => e.City != "Mumbai").ToList().ForEach(Print);
            Console.WriteLine("--------------------");

            Console.WriteLine("AsstManager:");
            list.Where(e => e.Role == "AsstManager").ToList().ForEach(Print);

            Console.WriteLine("--------------------");

            Console.WriteLine("Last Name of the Employees starts with 'S':");
            list.Where(e => e.LName.StartsWith("S")).ToList().ForEach(Print);
            Console.ReadLine();
        }
        public static void Print(Emp e)
        {
            Console.WriteLine(e.Id + " " + e.FName + " " + e.LName + " " + e.Role + " " + e.City);
        }
    }
