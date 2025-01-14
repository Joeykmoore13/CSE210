using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        List<int> listOfNumbers;
        listOfNumbers = new List<int>();
        string input = "";

        Console.Write("Choose an integer (add 0 to end): ");
        while (input != "0")
        {
            input = Console.ReadLine();
            listOfNumbers.Add(Convert.ToInt32(input));
            Console.Write("Choose an integer (add 0 to end): ");
        }
        listOfNumbers.Remove(listOfNumbers.Last());
        int sum = 0;
        float average = 0;
        foreach (int number in listOfNumbers)
        {
            sum = sum + number;
        }
        average = sum / listOfNumbers.Count();
        Console.WriteLine($"Length: {listOfNumbers.Count()}");
        listOfNumbers.Sort();
        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Average: {average}");
        Console.WriteLine($"Smallest: {listOfNumbers[0]}");
        Console.WriteLine($"Largest: {listOfNumbers.Last()}");
        int closeZero = listOfNumbers.Last();
        foreach (int number in listOfNumbers)
        {
            if (number > 0 && number < closeZero)
            {
                closeZero = number;
            }
        }
        Console.WriteLine($"Number closest positive int to zero: {closeZero}");
    }
}