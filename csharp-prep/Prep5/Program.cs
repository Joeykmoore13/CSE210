using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayMessage();
        string name = ReturnName();
        int FavoriteNumberint = PromptUserNumber();
        int squared = FavoriteNumber(FavoriteNumberint);
        DisplayResult(squared, name);
    }
    static void DisplayMessage()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string ReturnName()
    {
        Console.Write("What is your name?: ");
        return Console.ReadLine();
    }

    static int PromptUserNumber()
    {
        Console.Write("What is your favorite number?: ");
        return Convert.ToInt32(Console.ReadLine());
    }

    static int FavoriteNumber(int number)
    {
        int square = number * number;
        return square;
    }

    static void DisplayResult(int number, string name)
    {
        Console.WriteLine($"Name, the square of your favorite number is {number}");
    }
}