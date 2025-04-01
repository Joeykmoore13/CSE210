using System;

class Program
{
    static Cube _mainCube;

    static void Main(string[] args)
    {
        // This looks funny but I added the InitMenu method so I could have a nearly empty Main to help with debugging
        InitMenu();
    }
    static void InitMenu()
    {
        string input;
        while (true)
        {
            Console.Clear();
            Console.WriteLine("1) Create new cube");
            Console.WriteLine("2) Quit");
            Console.WriteLine("What would you like to do?: ");
            input = Console.ReadLine();
            Console.Clear();

            if (input == "1")
            {
                while (true)
                {
                    Console.WriteLine("1) 2x2");
                    Console.WriteLine("2) 3x3");
                    Console.WriteLine("Which cube would you like to create?: ");
                    input = Console.ReadLine();
                    Console.Clear();
                    if (input == "1")
                    {
                        _mainCube = new Cube();
                        Menu();
                    }
                    else if (input == "2")
                    {
                        _mainCube = new ThreeXThree();
                        Menu();
                    }
                    else
                    {
                        Console.WriteLine("Please make a valid selection");
                        Console.ReadLine();
                        Console.Clear();
                        continue;
                    }

                    break;
                }
            }
            else if (input == "2")
            {
                break;
            }
            else
            {
                Console.WriteLine("Please make a valid selection");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
    static void Menu()
    {
        int counter;
        bool loadedAlgs = false;
        List<(string, System.Action)> menuOptions = new List<(string, System.Action)> { };
        string input;
        while (true)
        {
            menuOptions.Clear();
            menuOptions.Add(("Set cube state", _mainCube.SetCubeState));
            if (!_mainCube.IsSolved())
            {
                menuOptions.Add(("Save cube state", _mainCube.SaveCubeState));
            }
            menuOptions.Add(("Input algorithm", _mainCube.InputAlgorithm));
            menuOptions.Add(("Load algorithms", _mainCube.LoadAlgorithms));
            if (loadedAlgs)
            {
                menuOptions.Add(("Save algorithms", _mainCube.SaveAlgorithms));
                menuOptions.Add(("Execute algorithm", _mainCube.ExecuteAlgorithm));
            }
            if (_mainCube.GetAlgList().Count >= 1)
            {
                menuOptions.Add(("Delete algorithm", _mainCube.DeleteAlgorithm));
            }
            menuOptions.Add(("Help", _mainCube.Help));
            menuOptions.Add(("Quit", null));

            counter = 1;
            Console.WriteLine("\r\r\r");
            _mainCube.Display();
            Console.WriteLine("\r");
            foreach (var option in menuOptions)
            {
                Console.WriteLine($"{counter}) {option.Item1}");
                counter++;
            }
            Console.WriteLine("What would you like to do?: ");
            input = Console.ReadLine().ToLower().Trim();
            Console.Clear();
            try
            {
                if (Convert.ToInt32(input) == counter)
                {
                    return;
                }
                else
                {
                    if (menuOptions[Convert.ToInt32(input) - 1].Item1 == "Quit")
                    {
                        return;
                    }
                    try
                    {
                        menuOptions[Convert.ToInt32(input) - 1].Item2();
                    }
                    catch
                    {
                        Console.WriteLine("Internal Error running function");
                        Console.ReadLine();
                        Console.Clear();
                    }

                    if (menuOptions[Convert.ToInt32(input) - 1].Item1 == "Load algorithms")
                    {
                        loadedAlgs = true;
                    }
                }
            }
            catch
            {
                Console.WriteLine("Please make a valid selection");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}