using System;

class Program
{
    static List<Scripture> _scriptureList = new List<Scripture>();
    static void Main(string[] args)
    {
        string[] lines = System.IO.File.ReadAllLines("..\\..\\..\\scriptures.txt");
        string[] components;
        foreach (var line in lines)
        {
            components = line.Split("/");
            _scriptureList.Add(new Scripture(components[1], components[0]));
        }
        // scriptureList.Add(new Scripture("11 And he shall go forth, suffering pains and afflictions and temptations of every kind; and this that the word might be fulfilled which saith he will take upon him the pains and the sicknesses of his people. 12 And he will take upon him death, that he may loose the bands of death which bind his people; and he will take upon him their infirmities, that his bowels may be filled with mercy, according to the flesh, that he may know according to the flesh how to succor his people according to their infirmities. 13 Now the Spirit knoweth all things; nevertheless the Son of God suffereth according to the flesh that he might take upon him the sins of his people, that he might blot out their transgressions according to the power of his deliverance; and now behold, this is the testimony which is in me."));
        // scriptureList.Add(new Scripture("12 This is a test scripture. Please erase the words correctly"));
        // scriptureList.Add(new Scripture("24 And see that ye have faith, hope, and charity, and then ye will always abound in good works."));
        Menu();
    }

    static void Menu()
    {
        int i = 0;
        int loadedScriptureIndex;
        foreach (Scripture scripture in _scriptureList)
        {
            i++;
            System.Console.WriteLine($"{i}) {scripture.GetReference()}");
        }
        System.Console.WriteLine("Which scripture would you like to load?: ");
        loadedScriptureIndex = Convert.ToInt32(Console.ReadLine()) - 1;
        bool quit;

        Console.Clear();
        Console.WriteLine($"Reference: {_scriptureList[loadedScriptureIndex].GetReference()}");
        _scriptureList[loadedScriptureIndex].Display();
        Console.WriteLine("\nPress enter to remove words or press 'quit' to quit.\n");
        quit = IsFinished(Console.ReadLine(), loadedScriptureIndex);
        
        while (quit == false)
        {
            HideWords(_scriptureList[loadedScriptureIndex]);
            Console.Clear();
            Console.WriteLine($"Reference: {_scriptureList[loadedScriptureIndex].GetReference()}");
            _scriptureList[loadedScriptureIndex].Display();
            Console.WriteLine("\nPress enter to remove words or press 'quit' to quit.\n");
            quit = IsFinished(Console.ReadLine(), loadedScriptureIndex);
        } 
        Console.WriteLine("Exited scripture memorizer");
    }

    static void HideWords(Scripture scripture)
    {
        scripture.HideWords();
    }

    static bool IsFinished(string quit, int loadedScriptureIndex)
    {
        if (quit == "quit")
        {
            return true;
        }
        else if (_scriptureList[loadedScriptureIndex].IsHidden() == true)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}