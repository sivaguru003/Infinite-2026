using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
internal class Prgm2
{
    public static void Stu()
    {
        Student s1 = new Student(1, "Sivaguru S", "BE", 2, "CSE");
        s1.GetMarks();
        s1.DisplayResult();
        s1.DisplayData();
    }
}

class Student
{
    int rollno;
    string name;
    string cls;
    int sem;
    string branch;
    int[] marks = new int[5];

    public Student(int r, string n, string c, int s, string b)
    {
        rollno = r;
        name = n;
        cls = c;
        sem = s;
        branch = b;
    }

    public void GetMarks()
    {
        for (int i = 0; i < 5; i++)
        {
            marks[i] = Convert.ToInt32(Console.ReadLine());
        }
    }

    public void DisplayResult()
    {
        int total = 0;
        bool fail = false;

        for (int i = 0; i < 5; i++)
        {
            if (marks[i] < 35)
                fail = true;

            total += marks[i];
        }

        double avg = total / 5.0;

        if (fail)
            Console.WriteLine("Failed");
        else if (avg < 50)
            Console.WriteLine("Failed");
        else
            Console.WriteLine("Passed");
    }

    public void DisplayData()
    {
        Console.WriteLine("Roll No: "+rollno);
        Console.WriteLine("Student Name: "+name);
        Console.WriteLine("Dept: "+cls);
        Console.WriteLine("Semester: "+sem);
        Console.WriteLine("Branch: "+branch);

        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine(marks[i]);
        }
        Console.WriteLine("--------------");

    }

}

