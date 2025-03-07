class Activity
{
    protected int _duration;
    private string _description;
    private string _name;
    public Activity()
    {
        _duration = 0;
        _description = "";
        _name = "none";
    }
    public Activity(int duration, string description, string name)
    {
        _duration = duration;
        _description = description;
        _name = name;
    }
    public void ShowAnimation(int duration)
    {
        Console.Write($"/ {duration}");
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (endTime > DateTime.Now)
        {
            Thread.Sleep(250);
            Console.Write("\b\b\b\b\b\b\b\b");
            Console.Write($"- {duration}");
            Thread.Sleep(250);
            Console.Write("\b\b\b\b\b\b\b\b");
            Console.Write(@"\" + $" {duration}");
            Thread.Sleep(250);
            Console.Write("\b\b\b\b\b\b\b\b");
            Console.Write($"| {duration}");
            Thread.Sleep(250);
            Console.Write("\b\b\b\b\b\b\b\b");
            duration--;
            Console.Write($"/ {duration}");
        }
        Console.Write("\b\b\b\b\b\b\b\b");
    }
    public virtual void ActivityLoop()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name} activity!");
        Console.WriteLine(_description);
        Console.WriteLine("Prepare to start the activity");
        ShowAnimation(7);
    }
    public void EndingMessage(DateTime startTime)
    {
        Console.Clear();
        Console.WriteLine($"Great work! You completed the {_name} activity in {DateTime.Now - startTime}");
    }
}