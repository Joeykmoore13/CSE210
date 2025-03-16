class TimedGoal : Goal
{
    private bool _isComplete;
    private string _completionDeadline;
    private bool _pastDeadline;
    public TimedGoal() : base()
    {
        _isComplete = false;
        _completionDeadline = "";
        _pastDeadline = false;
    }
    public TimedGoal(string dataString) : base()
    {
        //"Goal name","Goal description",<point value>,<is complete bool>,"completionDate", <past deadline bool>
        string[] split = dataString.Split(",");
        _goalName = split[0];
        _goalDescription = split[1];
        _pointValue = Convert.ToInt32(split[2]);
        _isComplete = Convert.ToBoolean(split[3]);
        _completionDeadline = split[4];
        _pastDeadline = Convert.ToBoolean(split[5]);

    }
    public TimedGoal(int pointValue, string goalName, string goalDescripton, string completionDeadline) : base(pointValue, goalName, goalDescripton)
    {
        _isComplete = false;
        _completionDeadline = completionDeadline;
        _pastDeadline = false;
    }
    public override void Display()
    {
        Console.Write("[");
        if (_isComplete && !_pastDeadline)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\u2713");
            Console.ResetColor();
        }
        else if (_isComplete && _pastDeadline)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"x");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"x");
            Console.ResetColor();
        }
        Console.WriteLine($"] {_goalName} ({_goalDescription}) (Deadline: {_completionDeadline}) ({_pointValue} points)");
    }
    public override string GetDataString()
    {
        return $"4;{_goalName},{_goalDescription},{_pointValue},{_isComplete},{_completionDeadline},{_pastDeadline}";
        //"Goal name","Goal description",<point value>,<is complete bool>,"completionDate", <past deadline bool>
    }
    public override int GetEarnedPoints()
    {
        if (_pastDeadline)
        {
            return 0;
        }
        else if (_isComplete)
        {
            return _pointValue;
        }
        else
        {
            return 0;
        }
    }
    public override bool IsComplete()
    {
        return _isComplete;
    }
    public override void RecordEvent()
    {
        while (true)
        {
            if (_isComplete)
            {
                Console.WriteLine("Event already completed");
                return;
            }
            else
            {
                Console.WriteLine("Was this event completed on time?(true/false): ");
                try
                {
                    _pastDeadline = !Convert.ToBoolean(Console.ReadLine().ToLower());
                    _isComplete = true;
                    return;
                }
                catch
                {
                    Console.WriteLine("Please type either true or false");
                    continue;
                }
            }
        }
    }
}