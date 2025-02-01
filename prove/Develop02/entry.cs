class Entry
{
    public string _text;
    public string _prompt;
    public string _date;

    public void Display()
    {
        Console.WriteLine("");
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Text: {_text}");
        
    }
}


