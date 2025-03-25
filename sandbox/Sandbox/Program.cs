using System;
using System.Text.RegularExpressions;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        // var cornerSearch = new Regex(@"\w{1}[c]");
        // string algName = "testing";
        // if (cornerSearch.IsMatch(algName))
        // {
        //     Console.WriteLine("Worked");
        // }
        // else
        // {
        //     Console.WriteLine("Didn't work");
        // }

        // var cornerSearch = new Regex(@"\w{1}[c]");
        // if (cornerSearch.IsMatch("ca"))
        // {
        //     Console.WriteLine("Worked");
        // }

        Process myProcess = new Process();
        try
        {
            // true is the default, but it is important not to set it to false
            myProcess.StartInfo.UseShellExecute = true;
            myProcess.StartInfo.FileName = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";
            myProcess.Start();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }


        // int myInt = 1;
        // int Testing = 10;

        // #if !Testing 
        // Console.WriteLine("Testing is not defined");
        // #endif



    }
}