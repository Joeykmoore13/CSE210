using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment myAssignment = new Assignment("John", "Math");
        Console.WriteLine(myAssignment.GetSummary());
        Math myMathAssignment = new Math("Section 4", "32, 34, 56, 80","John", "Math");
        Console.WriteLine(myAssignment.GetSummary());
        Console.WriteLine(myMathAssignment.GetHomeworkList());
        Writing myWritingAssignment = new Writing("History of mathmatics", "John", "Math");
        Console.WriteLine(myAssignment.GetSummary());
        Console.WriteLine(myWritingAssignment.GetWritingInformaton());
    }
}