using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        int duration = 7;
        Console.WriteLine("This is placeholder text");
        Console.Write($"/ {duration}");
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (endTime > DateTime.Now)
        {
        Thread.Sleep(250);
        Console.Write("\b\b\b\b\b\b\b\b");
        Console.Write($"- {duration}");
        Thread.Sleep(250);
        Console.Write("\b\b\b\b\b\b\b\b");
        Console.Write(@"\" + $" {duration}");
        Thread.Sleep(250);
        Console.Write("\b\b\b\b\b\b\b\b");
        Console.Write($"| {duration}");
        Thread.Sleep(250);
        Console.Write("\b\b\b\b\b\b\b\b");
        duration--;
        Console.Write($"/ {duration}");
        }
    }
}