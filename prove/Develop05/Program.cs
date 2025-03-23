using System;

class Program
{
    static List<Goal> _goalList = new List<Goal>();
    static int _pointTotal = 0;
    static string _input;
    static void Main(string[] args)
    {
        Console.Clear();
        bool done = false;
        while (done != true)
        {
            Console.WriteLine();
            CalculatePoints();
            Console.WriteLine();
            Console.WriteLine("1) Create new goal");
            Console.WriteLine("2) Delete goal");
            Console.WriteLine("3) List goals");
            Console.WriteLine("4) Load goals");
            Console.WriteLine("5) Save goals");
            Console.WriteLine("6) Record event");
            Console.WriteLine("7) Quit");
            Console.WriteLine("What would you like to do?: ");
            _input = Console.ReadLine();
            if (_input == "1")
            {
                CreateGoal();
            }
            else if (_input == "2")
            {
                DeleteGoal();
            }
            else if (_input == "3")
            {
                List();
            }
            else if (_input == "4")
            {
                Load();
            }
            else if (_input == "5")
            {
                Save();
            }
            else if (_input == "6")
            {
                RecordEvent();
            }
            else if (_input == "7")
            {
                done = true;
            }
            else
            {
                Console.WriteLine("Please make a valid selection");
            }
        }
    }
    static void CreateGoal()
    {
        string name;
        string description;
        int points = 0;

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("1) Simple goal");
            Console.WriteLine("2) Eternal goal");
            Console.WriteLine("3) Checklist goal");
            Console.WriteLine("4) Timed goal");
            Console.WriteLine("What type of goal would you like to create?: ");
            _input = Console.ReadLine();
            if (_input == "1")
            {
                Console.WriteLine("What would you like the goal to be?: ");
                name = Console.ReadLine();
                Console.WriteLine("What would you like the goal description to be?: ");
                description = Console.ReadLine();
                points = GetIntInput("What would you like the earned points to be?: ");

                _goalList.Add(new SimpleGoal(points, name, description));
                break;
            }
            else if (_input == "2")
            {
                Console.WriteLine("What would you like the goal to be?: ");
                name = Console.ReadLine();
                Console.WriteLine("What would you like the goal description to be?: ");
                description = Console.ReadLine();
                points = GetIntInput("What would you like the earned points to be?: ");

                _goalList.Add(new EternalGoal(points, name, description));
                break;
            }
            else if (_input == "3")
            {
                int bonus = -1;
                int totalCompleteions = -1;
                Console.WriteLine();
                Console.WriteLine("What would you like the goal to be?: ");
                name = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("What would you like the goal description to be?: ");
                description = Console.ReadLine();
                Console.WriteLine();
                points = GetIntInput("What would you like the earned points to be?: ");
                Console.WriteLine();
                bonus = GetIntInput("What would you like the bonus earned points to be?: ");
                Console.WriteLine();
                totalCompleteions = GetIntInput("What would you like the total number of completions to be?: ");
                _goalList.Add(new ChecklistGoal(totalCompleteions, bonus, points, name, description));
                break;
            }
            else if (_input == "4")
            {
                Console.WriteLine("What would you like the goal to be?: ");
                name = Console.ReadLine();
                Console.WriteLine("What would you like the goal description to be?: ");
                description = Console.ReadLine();
                points = GetIntInput("What would you like the earned points to be?: ");
                Console.WriteLine("When would you like this goal to be completed by?: ");
                string completeDate = Console.ReadLine();

                _goalList.Add(new TimedGoal(points, name, description, completeDate));
                break;
            }
            else
            {
                Console.WriteLine("Please make a valid selection");
            }
        }
        Console.WriteLine("Goal created!");
    }
    static void DeleteGoal()
    {
        while (true)
        {
            Console.WriteLine();
            ListGoals();
            try
            {
                _goalList.RemoveAt(GetIntInput("Which goal would you like to delete?: ") - 1);
            }
            catch
            {
                Console.WriteLine("Please choose a valid goal number");
                continue;
            }
            return;
        }
    }
    static void List()
    {
        Console.WriteLine();
        if (_goalList.Count() != 0)
        {
            foreach (Goal goal in _goalList)
            {
                goal.Display();
            }
        }
        else
        {
            Console.WriteLine("No goals to display");
        }
    }
    static void ListGoals()
    {
        if (_goalList.Count() != 0)
        {
            int i = 1;
            foreach (Goal goal in _goalList)
            {
                Console.Write($"{i})");
                i++;
                goal.Display();
            }
        }
        else
        {
            Console.WriteLine("No goals to display");
        }
    }
    static void Load()
    {
        _goalList = new List<Goal>();
        string[] split;
        string[] lines = System.IO.File.ReadAllLines("..\\..\\..\\goals.txt");
        foreach (string line in lines)
        {
            split = line.Split(";");
            if (split[0] == "1")
            {
                _goalList.Add(new SimpleGoal(split[1]));
            }
            else if (split[0] == "2")
            {
                _goalList.Add(new EternalGoal(split[1]));
            }
            else if (split[0] == "3")
            {
                _goalList.Add(new ChecklistGoal(split[1]));
            }
            else if (split[0] == "4")
            {
                _goalList.Add(new TimedGoal(split[1]));
            }
        }
        Console.WriteLine("Goals loaded!");
    }
    static void Save()
    {
        while (true)
        {
            Console.WriteLine("Are you sure you would like to save?(This overwrites all previous data)(Y/N): ");
            _input = Console.ReadLine();
            if (_input == "Y")
            {
                using (StreamWriter outputFile = new StreamWriter("..\\..\\..\\goals.txt", false))
                {
                    foreach (Goal goal in _goalList)
                    {
                        outputFile.WriteLine($"{goal.GetDataString()}");
                    }
                }
                Console.WriteLine("Goals saved!");
                return;
            }
            else if (_input == "N")
            {
                return;
            }
            else
            {
                Console.WriteLine("Please make a valid selection");
            }
        }
    }
    static void RecordEvent()
    {
        while (true)
        {
            Console.WriteLine();
            ListGoals();
            int intInput = GetIntInput("While goal would you like to record an event for?: ");
            try
            {
                _goalList[intInput - 1].RecordEvent();
                return;
            }
            catch
            {
                Console.WriteLine("Please choose a valid goal");
                continue;
            }
        }
    }
    static int GetIntInput(string writeText)
    {
        int number;
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine($"{writeText}");
            _input = Console.ReadLine();
            try
            {
                number = Convert.ToInt32(_input);
            }
            catch
            {
                Console.WriteLine("Please make a valid selection");
                continue;
            }
            return number;
        }
    }
    static void CalculatePoints()
    {
        _pointTotal = 0;
        foreach (Goal goal in _goalList)
        {
            _pointTotal += goal.GetEarnedPoints();
        }
        Console.WriteLine($"You have {_pointTotal} points!");
    }

}