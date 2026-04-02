using System;

struct Dob
{
    public int day;
    public int month;
    public int year;
}

struct EmployeeDetails
{
    public string name;
    public Dob dob;
}

internal class Prgm2
{
   public  static void Emp2()
    {
        EmployeeDetails[] emp = new EmployeeDetails[2];

        for (int i = 0; i < emp.Length; i++)
        {
            Console.WriteLine("Employee " + (i + 1));

            Console.Write("Name: ");
            emp[i].name = Console.ReadLine();

            Console.Write("Day of Birth: ");
            emp[i].dob.day = Convert.ToInt32(Console.ReadLine());

            Console.Write("Month of Birth: ");
            emp[i].dob.month = Convert.ToInt32(Console.ReadLine());

            Console.Write("Year of Birth: ");
            emp[i].dob.year = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();
        }

        Console.WriteLine("Employee Details");

        for (int i = 0; i < emp.Length; i++)
        {
            Console.WriteLine("Name: " + emp[i].name);
            Console.WriteLine("DOB: " +
                emp[i].dob.day + "/" +
                emp[i].dob.month + "/" +
                emp[i].dob.year);
            Console.WriteLine();
        }
    }
}