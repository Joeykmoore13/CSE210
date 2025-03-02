class Listing : Activity
{
    private int _count;
    private List<string> _promptList = new List<string>{"Who are people that you appreciate?", "What are personal strengths of yours?", "Who are people that you have helped this week?", "When have you felt the Holy Ghost this month?", "Who are some of your personal heroes?"};
    public Listing() : base()
    {

    }
    public Listing(int duration) : base (duration, "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", "listing")
    {
        _duration = duration;
    }
    public override void ActivityLoop()
    {
        base.ActivityLoop();
        var _startTime = DateTime.Now;
        var _endTime = _startTime.AddSeconds(_duration);
        Random randPrompt = new Random();
        int randomPrompt = randPrompt.Next(_promptList.Count());
        Console.Clear();
        Console.WriteLine(_promptList[randomPrompt]);
        _promptList.RemoveAt(randomPrompt);
        ShowAnimation(3);
        Console.WriteLine("You may begin listing items");
        while (DateTime.Now < _endTime)
        {
            Console.ReadLine();
            _count++;
        }
        Console.WriteLine($"You listed {_count} things.");
        ShowAnimation(7);
        EndingMessage(_startTime);
    }

}