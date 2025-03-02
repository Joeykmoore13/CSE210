using System;

class Program
{
    static void Main(string[] args)
    {
        string userInput = "";
        while (userInput != "4")
        {
            Console.Clear();
            Console.WriteLine("1) Breathing");
            Console.WriteLine("2) Reflection");
            Console.WriteLine("3) Listing");
            Console.WriteLine("4) Quit");
            Console.WriteLine("Which activity would you like to do?: ");
            userInput = Console.ReadLine();
            if (userInput == "1")
            {
                Breathe breathe = new Breathe(GetDuration());
                breathe.ActivityLoop();
            }
            else if (userInput == "2")
            {
                Reflection reflection = new Reflection(GetDuration());
                reflection.ActivityLoop();
            }
            else if (userInput == "3")
            {
                Listing listing = new Listing(GetDuration());
                listing.ActivityLoop();
            }
        }
    }
    static int GetDuration()
    {
        Console.Clear();
        Console.WriteLine("How long would you like this activity to go for?(In seconds): ");
        return Convert.ToInt32(Console.ReadLine());
    }
}