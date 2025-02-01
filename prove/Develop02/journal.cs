using System.Security.Cryptography.X509Certificates;
using System.Xml;

class Journal
{
    public string _name;
    public string _fileName;
    public List<Entry> _entryList = new List<Entry>();
    public Entry _currentEntry;

    public void Menu()
    {
        int choice;
        bool quit = false;

        _fileName = _name + ".txt";
        CreateEntryList();

        Console.WriteLine($"{_name} loaded successfully!");
        while (quit == false)
        {
            
            Console.WriteLine("");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1) Load entry");
            Console.WriteLine("2) Create entry");
            Console.WriteLine("3) Delete entry");
            Console.WriteLine("4) Display journal");
            Console.WriteLine("5) Save");
            choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1) // Load entry
        // only display this if there are entries to load
            {
                LoadEntry();
            }
            else if (choice == 2) // Create entry
            {
                List<string> promptList = new List<string>();
                promptList.Add("Who was the most interesting person I interacted with today?");
                promptList.Add("What was the best part of my day?");
                promptList.Add("How did I see the hand of the lord in my life today?");
                promptList.Add("What was the strongest emotion I felt today?");
                promptList.Add("If I had one thing I could do over today what would it be?");
                promptList.Add("What was something I acomplised today?");
                promptList.Add("Was thare anything I didn't get done today that I should have?");
                
                _currentEntry = new Entry();
                _entryList.Add(_currentEntry);

                DateTime today = DateTime.Today;
                _currentEntry._date = today.ToString("d");

                Random promptnumber = new Random();
                _currentEntry._prompt = promptList[promptnumber.Next(0,6)];
                Console.WriteLine("Your prompt for this entry is:");
                Console.WriteLine(_currentEntry._prompt);
                Console.WriteLine("What would you like to add for the entry text?: ");
                _currentEntry._text = Console.ReadLine();
                
                
            }
            else if (choice == 3) // Delete entry
            {
                DeleteEntry();
            }
            else if (choice == 4) // Display whole journal
            {
                Console.WriteLine("");
                foreach (Entry entry in _entryList)
                {
                    entry.Display();
                }
            }
            else if (choice == 5) // save
            {
                SaveJournal();
                quit = true;
            }
            else
            {
                Console.WriteLine("Please make a valid selection");
            }
        }
        // options:
        // Load entry
        // Save entry
        // Create entry
        // 
        
    }

    public void CreateEntryList()
    {
        _entryList = [];
        string[] lines = System.IO.File.ReadAllLines($"{_name}.txt");
        foreach (string line in lines)
        {
            if (line != "")
            {
            Entry newEntry = new Entry();
            string[] entry_attributes = line.Split(",");
            _entryList.Add(newEntry);
            _entryList.Last()._prompt = entry_attributes[0];
            _entryList.Last()._date = entry_attributes[1];
            _entryList.Last()._text = entry_attributes[2];
            }
        }
    }
    
    public void LoadEntry()
    {
        bool done = false;
            while (done == false)
            {                    
                CreateEntryList();
                Console.WriteLine("Which entry would you like to use?");
                int i = 0;
                foreach (var entry in _entryList)
                {
                    i += 1;
                    Console.WriteLine($"{i}) {entry._date}");
                }
                Console.Write("Choice: ");
                Console.WriteLine(_entryList.Count());
                int secondChoice = Convert.ToInt32(Console.ReadLine());
                if (secondChoice > _entryList.Count() | secondChoice < 1)
                {
                    Console.WriteLine("Please select a valid option");
                }
                else
                {
                    Console.WriteLine("");
                    _entryList[secondChoice - 1].Display();
                    done = true;
                }
            }
    }

    public void DeleteEntry()
    {
        int choice;
        CreateEntryList();
        int i = 0;
        foreach (Entry entry in _entryList)
        {
            i += 1;
            Console.WriteLine($"{i}) {entry._date}");
        }
        choice = Convert.ToInt32(Console.ReadLine());
        if (choice > _entryList.Count() | choice < 0)
        {
            Console.WriteLine("Choose a valid option");
        }
        else
        {
        _currentEntry = _entryList[choice-1];
        _entryList.Remove(_currentEntry);
        // Add a a possibility of having no entrys here.
        _currentEntry = _entryList.Last();
        }
    }

    public void SaveJournal()
    {
        File.WriteAllText($"{_name}.txt", "");
        using (StreamWriter outputFile = new StreamWriter($"{_name}.txt", true))
        foreach (Entry entry in _entryList)
        {
            outputFile.WriteLine($"{entry._prompt},{entry._date},{entry._text}");
        }
    }
}