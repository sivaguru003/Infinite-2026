using System;
namespace Ass.code
{
    internal class Employee
    {
        public int Id;
        public string Name;
        public string Department;
        public double Salary;
    }
    internal class Prgm1
    {
        public static void Emp1()
        {
            Employee[] emp = new Employee[100];
            int count = 0;
            int choice = 0;

            while (choice != 6)
            {
                Console.WriteLine("\n===== Employee Management Menu =====");
                Console.WriteLine("1. Add New Employee");
                Console.WriteLine("2. View All Employees");
                Console.WriteLine("3. Search Employee by ID");
                Console.WriteLine("4. Update Employee Details");
                Console.WriteLine("5. Delete Employee");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    emp[count] = new Employee();
                    Console.Write("Enter Employee ID: ");
                    emp[count].Id = int.Parse(Console.ReadLine());
                    Console.Write("Enter Employee Name: ");
                    emp[count].Name = Console.ReadLine();
                    Console.Write("Enter Department: ");
                    emp[count].Department = Console.ReadLine();
                    Console.Write("Enter Salary: ");
                    emp[count].Salary = double.Parse(Console.ReadLine());
                    count++;
                    Console.WriteLine("Employee added successfully!");
                }
                else if (choice == 2)
                {
                    if (count == 0)
                    {
                        Console.WriteLine("No employees to display.");
                    }
                    for (int i = 0; i < count; i++)
                    {
                        Console.WriteLine($"{emp[i].Id} {emp[i].Name} {emp[i].Department} {emp[i].Salary}");
                    }
                }
                else if (choice == 3)
                {
                    Console.Write("Enter Employee ID to search: ");
                    int id = int.Parse(Console.ReadLine());
                    bool found = false;
                    for (int i = 0; i < count; i++)
                    {
                        if (emp[i].Id == id)
                        {
                            Console.WriteLine($"{emp[i].Id} {emp[i].Name} {emp[i].Department} {emp[i].Salary}");
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        Console.WriteLine("Employee not found.");
                    }
                }
                else if (choice == 4)
                {
                    Console.Write("Enter Employee ID to update: ");
                    int id = int.Parse(Console.ReadLine());
                    bool found = false;
                    for (int i = 0; i < count; i++)
                    {
                        if (emp[i].Id == id)
                        {
                            Console.Write("Enter new Name: ");
                            emp[i].Name = Console.ReadLine();
                            Console.Write("Enter new Department: ");
                            emp[i].Department = Console.ReadLine();
                            Console.Write("Enter new Salary: ");
                            emp[i].Salary = double.Parse(Console.ReadLine());
                            Console.WriteLine("Employee details updated successfully!");
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        Console.WriteLine("Employee not found.");
                    }
                }
                else if (choice == 5)
                {
                    Console.Write("Enter Employee ID to delete: ");
                    int id = int.Parse(Console.ReadLine());
                    bool found = false;
                    for (int i = 0; i < count; i++)
                    {
                        if (emp[i].Id == id)
                        {
                            for (int j = i; j < count - 1; j++)
                            {
                                emp[j] = emp[j + 1];
                            }
                            count--;
                            Console.WriteLine("Employee deleted successfully!");
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        Console.WriteLine("Employee not found.");
                    }
                }
                else if (choice == 6)
                {
                    Console.WriteLine("Exiting program...");
                }
                else
                {
                    Console.WriteLine("Invalid choice, please try again.");
                }
            }
        }
    }
}