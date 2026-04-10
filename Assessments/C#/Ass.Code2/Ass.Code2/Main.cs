using System;

namespace Ass.code
{
    abstract class Student
    {
        public string Name;
        public int StudentId;
        public double Grade;

        public abstract bool IsPassed(double grade);
    }

    class Undergraduate : Student
    {
        public override bool IsPassed(double grade)
        {
            return grade > 70;
        }
    }

    class Graduate : Student
    {
        public override bool IsPassed(double grade)
        {
            return grade > 80;
        }
    }

   internal class Prgm4
    {
        public static void stu()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Student ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Grade: ");
            double grade = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Student Type (UG/G): ");
            string type = Console.ReadLine();

            Student student;

            if (type == "UG")
                student = new Undergraduate();
            else
                student = new Graduate();

            student.Name = name;
            student.StudentId = id;
            student.Grade = grade;

            if (student.IsPassed(grade))
                Console.WriteLine("Student Passed");
            else
                Console.WriteLine("Student Failed");
        }

      public  static void Main()
        {
            stu();
            Console.ReadLine();
            Prgm2.Prod();
            Prgm3.chknum();
            Prgm4.Calc();
        }

    }
}
