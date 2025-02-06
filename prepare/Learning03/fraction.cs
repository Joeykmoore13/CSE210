class Fraction
{
    private int numerator;
    private int denominator;
    public Fraction()
    {
        numerator = 1;
        denominator = 1;
    }

    public Fraction(int top)
    {
        numerator = top;
        denominator = 1;
    }

    public Fraction(int top, int bottom)
    {
        numerator = top;
        denominator = bottom;
    }

    public int GetNumerator()
    {
        return numerator;
    }

    public void SetNumerator(int top)
    {
        numerator = top;
    }

    public int GetDenominator()
    {
        return denominator;
    }

    public void SetDenominator(int bottom)
    {
        if (bottom != 0)
        {
            denominator = bottom;
        }
        else
        {
            Console.WriteLine("Please select a non-zero denominator");
            return;
        }
    }

    public string GetFractionString()
    {
        return $"{numerator}/{denominator}";
    }

    public double GetDecimalValue()
    {
        double decimalValue = Convert.ToDouble(numerator) / Convert.ToDouble(denominator);
        return decimalValue;
    }
}