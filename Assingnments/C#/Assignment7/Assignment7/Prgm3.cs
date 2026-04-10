using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Employee
{
    public int EmpId;
    public string EmpName;
    public string EmpCity;
    public int EmpSalary;
}
internal class Prgm3
{
public static void emp()
    {
        List<Employee> employees = new List<Employee>();
        Console.WriteLine("Enter number of employees:");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Employee e = new Employee();
            Console.WriteLine("Enter EmpId:");
            e.EmpId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter EmpName:");
            e.EmpName = Console.ReadLine();
            Console.WriteLine("Enter EmpCity:");
            e.EmpCity = Console.ReadLine();
            Console.WriteLine("Enter EmpSalary:");
            e.EmpSalary = int.Parse(Console.ReadLine());
            employees.Add(e);
        }

        Console.WriteLine("All the Employees:");
        foreach (Employee e in employees)
        {
            Console.WriteLine(e.EmpId + " " + e.EmpName + " " + e.EmpCity + " " + e.EmpSalary);
        }
        Console.WriteLine("Salary > 45000:");
        foreach (Employee e in employees)
        {
            if (e.EmpSalary > 45000)
            {
                Console.WriteLine(e.EmpId + " " + e.EmpName + " " + e.EmpCity + " " + e.EmpSalary);
            }
        }
        Console.WriteLine("Employees from the Bangalore:");
        foreach (Employee e in employees)
        {
            string city = e.EmpCity.ToLower();
            if (city == "bangalore")
            {
                Console.WriteLine(e.EmpId + " " + e.EmpName + " " + e.EmpCity + " " + e.EmpSalary);
            }
        }

        for (int i = 0; i < employees.Count - 1; i++)
        {
            for (int j = i + 1; j < employees.Count; j++)
            {
                string a = employees[i].EmpName.ToLower();
                string b = employees[j].EmpName.ToLower();

                if (string.Compare(a, b) > 0)
                {
                    Employee temp = employees[i];
                    employees[i] = employees[j];
                    employees[j] = temp;
                }
            }
        }
        Console.WriteLine("Sorted by their Names:");
        foreach (Employee e in employees)
        {
            Console.WriteLine(e.EmpId + " " + e.EmpName + " " + e.EmpCity + " " + e.EmpSalary);
        }
    }
}
    

