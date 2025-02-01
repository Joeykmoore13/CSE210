using System.Security.Cryptography.X509Certificates;
using System.Xml;

class Journal
{
    public string name;
    public string fileName;
    public List<Entry> entryList = new List<Entry>();
    public Entry currentEntry;
    public bool quit = false;
    public int choice;

    public void Menu()
    {

        fileName = name + ".txt";
        createEntryList();

        Console.WriteLine($"{name} loaded successfully!");
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
                loadEntry();
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
                
                currentEntry = new Entry();
                entryList.Add(currentEntry);

                DateTime today = DateTime.Today;
                currentEntry.date = today.ToString("d");

                Random promptnumber = new Random();
                currentEntry.prompt = promptList[promptnumber.Next(0,6)];
                Console.WriteLine("Your prompt for this entry is:");
                Console.WriteLine(currentEntry.prompt);
                Console.WriteLine("What would you like to add for the entry text?: ");
                currentEntry.text = Console.ReadLine();
                
                
            }
            else if (choice == 3) // Delete entry
            {
                deleteEntry();
            }
            else if (choice == 4) // Display whole journal
            {
                Console.WriteLine("");
                foreach (Entry entry in entryList)
                {
                    entry.display();
                }
            }
            else if (choice == 5) // save
            {
                saveJournal();
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

    public void createEntryList()
    {
        entryList = [];
        string[] lines = System.IO.File.ReadAllLines($"{name}.txt");
        foreach (string line in lines)
        {
            if (line != "")
            {
            Entry newEntry = new Entry();
            string[] entry_attributes = line.Split(",");
            entryList.Add(newEntry);
            entryList.Last().prompt = entry_attributes[0];
            entryList.Last().date = entry_attributes[1];
            entryList.Last().text = entry_attributes[2];
            }
        }
    }
    
    public void loadEntry()
    {
        bool done = false;
            while (done == false)
            {                    
                createEntryList();
                Console.WriteLine("Which entry would you like to use?");
                int i = 0;
                foreach (var entry in entryList)
                {
                    i += 1;
                    Console.WriteLine($"{i}) {entry.date}");
                }
                Console.Write("Choice: ");
                Console.WriteLine(entryList.Count());
                int secondChoice = Convert.ToInt32(Console.ReadLine());
                if (secondChoice > entryList.Count() | secondChoice < 1)
                {
                    Console.WriteLine("Please select a valid option");
                }
                else
                {
                    Console.WriteLine("");
                    entryList[secondChoice - 1].display();
                    done = true;
                }
            }
    }

    public void deleteEntry()
    {
        createEntryList();
        int i = 0;
        foreach (Entry entry in entryList)
        {
            i += 1;
            Console.WriteLine($"{i}) {entry.date}");
        }
        choice = Convert.ToInt32(Console.ReadLine());
        if (choice > entryList.Count() | choice < 0)
        {
            Console.WriteLine("Choose a valid option");
        }
        else
        {
        currentEntry = entryList[choice-1];
        entryList.Remove(currentEntry);
        // Add a a possibility of having no entrys here.
        currentEntry = entryList.Last();
        }
    }

    public void saveJournal()
    {
        File.WriteAllText($"{name}.txt", "");
        using (StreamWriter outputFile = new StreamWriter($"{name}.txt", true))
        foreach (Entry entry in entryList)
        {
            outputFile.WriteLine($"{entry.prompt},{entry.date},{entry.text}");
        }
    }
}