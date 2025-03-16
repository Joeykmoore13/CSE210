class SimpleGoal : Goal
{
    private bool _isComplete;
    public SimpleGoal() : base()
    {
        _isComplete = false;
    }
    public SimpleGoal(string dataString) : base()
    {
        //"Goal name","Goal description",<point value>,<is complete bool>
        string[] split = dataString.Split(",");
        _goalName = split[0];
        _goalDescription =  split[1];
        _pointValue = Convert.ToInt32(split[2]);
        _isComplete = Convert.ToBoolean(split[3]);
    }
    public SimpleGoal(int pointValue, string goalName, string goalDescripton) : base(pointValue, goalName, goalDescripton)
    {
        _isComplete = false;
    }
    public override bool IsComplete()
    {
        return _isComplete;
    }
    public override void RecordEvent()
    {
        if (_isComplete == true)
        {
            Console.WriteLine("Event already completed");
        }
        else
        {
            Console.WriteLine($"Event Recorded! You earned {_pointValue} more points!");
            _isComplete = true;
        }
    }
    public override void Display()
    {
        Console.Write("[");
        if (_isComplete != false)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\u2713");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"x");
            Console.ResetColor();
        }
        Console.WriteLine($"] {_goalName} ({_goalDescription}) ({_pointValue} points)");
    }
    public override int GetEarnedPoints()
    {
        if (_isComplete)
        {
            return _pointValue;
        }
        return 0;
    }
    public override string GetDataString()
    {
        return $"1;{_goalName},{_goalDescription},{_pointValue},{_isComplete}";
        // (<goalType> : 1|2|3|4);"Goal name","Goal description",<point value>,<is complete bool>
    }
}