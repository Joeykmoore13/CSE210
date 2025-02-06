using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fractionOne = new Fraction();
        Console.WriteLine(fractionOne.GetFractionString());

        Fraction fractionTwo = new Fraction(3);
        Console.WriteLine(fractionTwo.GetFractionString());

        Fraction fractionThree = new Fraction(5,7);
        Console.WriteLine(fractionThree.GetFractionString());
        Console.WriteLine(fractionThree.GetDecimalValue());
        Console.WriteLine(fractionThree.GetNumerator());
        Console.WriteLine(fractionThree.GetDenominator());
        
    }
}