using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class CricketTeam
{
    public void Pointscalculation(int no_of_matches)
    {
        int sum = 0;

        for (int i = 1; i <= no_of_matches; i++)
        {
            Console.Write("Enter score for match " + i + ": ");
            int score = Convert.ToInt32(Console.ReadLine());
            sum = sum + score;
        }

        float avg = (float)sum / no_of_matches;

        Console.WriteLine("\nPlayed Match Count : " + no_of_matches);
        Console.WriteLine("Team Total Score: " + sum);
        Console.WriteLine("Team Average Score: " + avg);
    }
}

internal class Prgm1
{
    public static void ipl()
    {
        Console.Write("Enter Number of Matches Played: ");
        int mat = Convert.ToInt32(Console.ReadLine());
        CricketTeam team = new CricketTeam();
        team.Pointscalculation(mat);
        Console.WriteLine("------------------");
    }
}