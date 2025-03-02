class Reflection : Activity
{
    private List<string> _promptList = new List<string>{"Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult.", "Think of a time when you helped someone in need.", "Think of a time when you did something truly selfless"};
    private List<string> _questionList  = new List<string>{"Why was this experience meaningful to you?", "Have you ever done anything like this before", "How did you get started?", "How did you feel when it was complete?", "What made this time different than other times when you were not as successful?", "What is your favorite thing about this experience?", "What could you learn from this experience that applies to other situations?", "What did you learn about yourself through this experience?", "How can you keep this experience in mind in the future?"};
    public Reflection() : base()
    {

    }

    public Reflection(int duration) : base(duration, "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you regognize the power you have and how you can use it in other aspects of your life.", "reflection")
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
        ShowAnimation(1);
        while (DateTime.Now < _endTime)
        {
            Console.Clear();
            if (_promptList.Count() == 0)
            {
                _promptList = new List<string>{"Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult.", "Think of a time when you helped someone in need.", "Think of a time when you did something truly selfless"};
            }
            randomPrompt = randPrompt.Next(_promptList.Count());
            Console.WriteLine(_promptList[randomPrompt]);
            _promptList.RemoveAt(randomPrompt);
            ShowAnimation(6);
            if (_questionList.Count() == 0)
            {
                _questionList = new List<string>{"Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult.", "Think of a time when you helped someone in need.", "Think of a time when you did something truly selfless"};
            }
            randomPrompt = randPrompt.Next(_questionList.Count());
            Console.Clear();
            Console.WriteLine(_questionList[randomPrompt]);
            _questionList.RemoveAt(randomPrompt);

            ShowAnimation(6);
        }
        EndingMessage(_startTime);
    }
}