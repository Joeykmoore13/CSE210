using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade? (Percentage): ");
        int grade = Convert.ToInt32(Console.ReadLine());
        string letterGrade = "";
        string letterModifier = "";

        if (grade >= 90)
        {
            letterGrade = "A";
        }
        else if (grade >= 80)
        {
            letterGrade = "B";
        }
        else if (grade >= 70)
        {
            letterGrade = "C";
        }
        else if (grade >= 60)
        {
            letterGrade = "D";
        }
        else if (grade < 60)
        {
            letterGrade = "F";
        }

        if (grade >=60 && grade < 93)
        {
            if (grade%10 >= 7)
            {
                letterModifier = "+";
            }
            else if (grade%10 < 3)
            {
                letterModifier = "-";
            }
        }

        Console.WriteLine($"Your grade is: {letterGrade}{letterModifier}");
        if (grade < 70)
        {
            Console.WriteLine("You unfortunatly need a C or better to pass. Good luck next time");
        }
        else
        {
            Console.WriteLine("You passed!");
        }

    }
}