class ChecklistGoal : Goal
{
    private int _completedCount;
    private int _targetCount;
    private int _bonusPoints;
    public ChecklistGoal() : base()
    {
        _completedCount = 0;
        _targetCount = 0;
        _bonusPoints = 0;
    }
    public ChecklistGoal(string dataString) : base()
    {
        //<completed count int>,<target count int>,<bonus points int>
        string[] split = dataString.Split(",");
        _goalName = split[0];
        _goalDescription =  split[1];
        _pointValue = Convert.ToInt32(split[2]);
        _completedCount = Convert.ToInt32(split[3]);
        _targetCount = Convert.ToInt32(split[4]);
        _bonusPoints = Convert.ToInt32(split[5]);
    }
    public ChecklistGoal(int targetCount, int bonusPoints, int pointValue, string goalName, string goalDescripton) : base(pointValue, goalName, goalDescripton)
    {
        _completedCount = 0;
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
    }
    public override bool IsComplete()
    {
        if (_completedCount == _targetCount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public override int GetEarnedPoints()
    {
        if (_targetCount == _completedCount)
        {
            return (_completedCount * _pointValue) + _bonusPoints;
        }
        else
        {
            return _completedCount * _pointValue;
        }
    }
    public override void Display()
    {
        if (_completedCount == _targetCount)
        {
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{_completedCount}/{_targetCount}");
            Console.ResetColor();
            Console.WriteLine($"] {_goalName} ({_goalDescription}) (worth {(_pointValue * _targetCount) + _bonusPoints} points total)");
        }
        else
        {
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"{_completedCount}/{_targetCount}");
            Console.ResetColor();
            Console.WriteLine($"] {_goalName} ({_goalDescription}) (worth {(_pointValue * _completedCount) + _bonusPoints} points total)");
        }
    }
    public override void RecordEvent()
    {
        if (_completedCount == _targetCount)
        {
            Console.WriteLine("Event already completed");
        }
        else
        {
            _completedCount++;
            if (_completedCount == _targetCount)
            {
                Console.WriteLine($"Event Recorded! You earned {_pointValue + _bonusPoints} more points!");
            }
            else
            {
                Console.WriteLine($"Event Recorded! You earned {_pointValue} more points!");
            }
        }
    }
    public override string GetDataString()
    {
        return $"3;{_goalName},{_goalDescription},{_pointValue},{_completedCount},{_targetCount},{_bonusPoints}";
        //<completed count int>,<target count int>,<bonus points int>
    }
}