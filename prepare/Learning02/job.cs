public class Job
{
    public string _company;
    public string _jobTitle;
    public string _startYear;
    public string _endYear;

    public void Display()
    {
        Console.Write(_jobTitle);
        Console.Write($" ({_company})");
        Console.Write($" {_startYear}-");
        Console.WriteLine(_endYear);
    }
}