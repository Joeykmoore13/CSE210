using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1,11);
        Console.WriteLine(magicNumber);
        Console.WriteLine("Guess the magic number");

        string userGuess;
        int guessCount = 0;
        
        while (true)
        {
            Console.Write("Your guess: ");
            userGuess = Console.ReadLine();
            guessCount++;
            if (Convert.ToInt32(userGuess) == magicNumber)
            {
                Console.WriteLine($"Congrats! You guessed the magic number in {guessCount} guesses!");
                break;
            }
            else if (Convert.ToInt32(userGuess) > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("Higher");
            }
            
        }
    }
}