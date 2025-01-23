using System;

class Program
{
    static void Main(string[] args)
    {
        Resume MyResume = new Resume();
        MyResume._name = "John";
        
        MyResume._JobList.Add(new Job());
        MyResume._JobList[0]._company = "Microsoft";
        MyResume._JobList[0]._startYear = "2019";
        MyResume._JobList[0]._endYear = "2022";
        MyResume._JobList[0]._jobTitle = "Software engineer";

        MyResume._JobList.Add(new Job());
        MyResume._JobList[1]._company = "Apple";
        MyResume._JobList[1]._startYear = "2022";
        MyResume._JobList[1]._endYear = "2023";
        MyResume._JobList[1]._jobTitle =  "Manager";

        MyResume.Display();

    }
}