using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        Display();
        DisplaySecond();
        Clear();
        System.Console.WriteLine("Ran the things");   
    }

    static void Display()
    {
        Console.WriteLine("Hello world");
    }

    static void DisplaySecond()
    {
        Console.WriteLine("Goodbye world");
    }

    static void Clear()
    {
        Console.Clear();
    }

    
}