class Entry
{
    public string text;
    public string prompt;
    public string date;

    public void display()
    {
        Console.WriteLine("");
        Console.WriteLine($"Date: {date}");
        Console.WriteLine($"Prompt: {prompt}");
        Console.WriteLine($"Text: {text}");
        
    }
}


