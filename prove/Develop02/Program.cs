using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Net.Quic;
using System.Security.Cryptography.X509Certificates;

class Program
{
    
    

    static void Main(string[] args)
    {
        Menu();
    }

    static void Menu()
    {
        bool quit = false;
        int choice;
        Console.WriteLine("Welcome to the Journal manager!");
        Journal loadedJournal = new Journal();
        loadedJournal.name = "";
        while (quit == false)
        {
            Console.WriteLine("What would you like to do? ");
            Console.WriteLine("1) Load Journal");
            Console.WriteLine("2) Create Journal");
            Console.WriteLine("3) Delete Journal");    
            Console.WriteLine("4) Quit");
            Console.Write("Choice: ");
            choice = Convert.ToInt32(Console.ReadLine());
            
            if (choice == 1) //load journal
            {
                loadedJournal = LoadJournal(false);
            }
            else if (choice == 2) // create journal
            {
                CreateJournal();
            }
            else if (choice == 3) // delete journal
            {
                DeleteJournal();   
            }
            else if (choice == 4) // quit
            {
                quit = true;
            }
            else
            {
                Console.WriteLine("Please make a valid selection");
                Console.WriteLine("");
            }

        }
    }

    static Journal LoadJournal(bool init)
    {
        List<string> journalNames;
        journalNames = CreateJournalList();
        while (true)
        {
        System.Console.WriteLine("Which journal would you like to use?");
        int i = 0;
        foreach (string journal in journalNames)
        {
            i += 1;
            Console.WriteLine($"{i}) {journal}");
        }
        Console.WriteLine($"Journal count: {journalNames.Count()}");
        Console.Write("Choice: ");

        int secondChoice = Convert.ToInt32(Console.ReadLine());
        secondChoice -= 1;
        if (secondChoice <= (journalNames.Count() - 1) && secondChoice >= 0)
        {
            Journal currentJournal = new Journal();
            currentJournal.name = journalNames[secondChoice].Replace(" ","");
            if (init == false)
            {
                currentJournal.Menu();
            }
            return currentJournal;
        }
        else
        {
            Console.WriteLine("I'm sorry. An invalid selection was made.");
            Console.WriteLine("");
        }
        }
                    
    }

    static void CreateJournal()
    {
        Console.Write("What would you like the journal to be called? (Any whitespace will be removed): ");
        string newJournalName = Console.ReadLine().Replace(" ","");
        using (StreamWriter outputFile = new StreamWriter("journalList.txt", true))
        {
            outputFile.WriteLine($", {newJournalName}");
        }
        newJournalName = newJournalName + ".txt";
        using(StreamWriter sw = File.CreateText(newJournalName))
        {
            sw.WriteLine("");
        }
        
    }

    static void DeleteJournal()
    {
        List<string> journalNames;
        journalNames = CreateJournalList();
        while (true)
        {
            System.Console.WriteLine("Which journal would you like to delete?");
            int i = 0;
            foreach (string journal in journalNames)
            {
                i += 1;
                Console.WriteLine($"{i}) {journal}");
            }

            Console.Write("Choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            string confirm = "";
            while (confirm != "Y" && confirm != "N")
            {
                Console.Write("Are you sure you would like to delete this file? (Y/N): ");
                confirm = Console.ReadLine().ToUpper();
                if (confirm != "Y" && confirm != "N")
                {
                    Console.WriteLine("I'm sorry. Please type a valid option");
                    Console.WriteLine("");
                }
            }
            Console.WriteLine(journalNames[choice-1]);

            if (confirm == "Y")
            {
                System.IO.File.Delete($"{journalNames[choice-1].Replace(" ","")}.txt");
                // remove from journalList
                
                string text = File.ReadAllText("journalList.txt");
                Console.WriteLine($",{journalNames[choice-1]}");
                text = text.Replace($",{journalNames[choice-1]}", "");
                File.WriteAllText("journalList.txt", text);
                
            }
            break;
        }
    }

    static List<string> CreateJournalList()
    {
        List<string> journalListReturn = [];
        string[] lines = System.IO.File.ReadAllLines("journalList.txt");
        
        foreach (string line in lines)
        {
            string[] journals = line.Split(",");
            int i = 0;
            foreach (string journal in journals)
            {
                if (i != 0 && journal != "")
                {
                    journalListReturn.Add(journal);
                }
                i++;
            }
        }

        return journalListReturn;
    }
    

}