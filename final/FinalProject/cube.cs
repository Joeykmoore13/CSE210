using System.Data.Common;
using System.Linq.Expressions;
using System.Diagnostics;

class Cube
{
    protected Dictionary<string, Corner> _cornerList;
    protected List<Algorithm> _algList;

    public Cube()
    {
        _cornerList = new Dictionary<string, Corner>();
        _cornerList.Add("ac", new Corner("ac", ConsoleColor.White, ConsoleColor.Red, ConsoleColor.Blue));
        _cornerList.Add("bc", new Corner("bc", ConsoleColor.White, ConsoleColor.Blue, ConsoleColor.DarkRed));
        _cornerList.Add("cc", new Corner("cc", ConsoleColor.White, ConsoleColor.DarkRed, ConsoleColor.Green));
        _cornerList.Add("dc", new Corner("dc", ConsoleColor.White, ConsoleColor.Green, ConsoleColor.Red));
        _cornerList.Add("uc", new Corner("uc", ConsoleColor.Yellow, ConsoleColor.Red, ConsoleColor.Green));
        _cornerList.Add("vc", new Corner("vc", ConsoleColor.Yellow, ConsoleColor.Green, ConsoleColor.DarkRed));
        _cornerList.Add("wc", new Corner("wc", ConsoleColor.Yellow, ConsoleColor.DarkRed, ConsoleColor.Blue));
        _cornerList.Add("xc", new Corner("xc", ConsoleColor.Yellow, ConsoleColor.Blue, ConsoleColor.Red));
        _algList = new List<Algorithm>();
    }

    // Things to implement:
    // Enable and disable pieces
    // Enabled and disabled pieces in the datastrings

    public virtual void SetCubeState()
    {
        int input;
        string[] cubeDataStrings;
        string currentLoad;
        int counter = 1;
        while (true)
        {
            Console.WriteLine("How would you like to set the cube state?: ");
            Console.WriteLine("1) Reset cube");
            Console.WriteLine("2) Load cube state");
            Console.WriteLine("3) Algorithm");
            Console.WriteLine("4) Scramble cube");
            try
            {
                input = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
            }
            catch
            {
                Console.WriteLine("Please make a valid selection");
                Console.WriteLine();
                Console.Clear();
                continue;
            }
            if (input == 1)
            {
                ResetCube();
                return;
            }
            else if (input == 2)
            {
                counter = 1;
                cubeDataStrings = System.IO.File.ReadAllLines("..\\..\\..\\2x2cubestates.txt");
                List<string[]> names = new List<string[]>();
                foreach (string line in cubeDataStrings)
                {
                    names.Add(line.Split(":"));
                    Console.WriteLine($"{counter}) {names.Last()[0]}");
                    counter++;
                }
                if (names.Count() == 0)
                {
                    Console.WriteLine("No states to load");
                    Console.WriteLine();
                    Console.Clear();
                    return;
                }
                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Which cube state would you like to load?");
                    try
                    {
                        currentLoad = names[Convert.ToInt32(Console.ReadLine()) - 1][1];
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Please make a valid selection");
                        Console.WriteLine();
                        Console.Clear();
                        continue;
                    }
                }
                ModifyCubeState(currentLoad);
                return;
            }
            else if (input == 3)
            {
                while (true)
                {
                    Console.WriteLine("Possible moves: R, R', R2, F, F', F2, U, U', U2");
                    Console.WriteLine("Which moves would you like to make?(Seperate moves with commas): ");
                    string alg = Console.ReadLine();
                    Console.Clear();
                    if (ParseAlgorithm(alg) == "")
                    {
                        continue;
                    }
                    ResetCube();
                    ParseAlgorithm(alg);
                    return;
                }
            }
            else if (input == 4)
            {
                List<string> moveList = new List<string>(["R", "U", "F"]);
                List<string> moveModifier = new List<string>(["", "2", "'"]);
                Random randomMove = new Random();
                string scramble = moveList[randomMove.Next(0, moveList.Count)];
                moveList.Remove(scramble);
                string nextMove = $"{moveList[randomMove.Next(0, moveList.Count)]}";
                scramble = $"{scramble}, {nextMove}{moveModifier[randomMove.Next(0, 2)]}";
                for (int i = 0; i < 20; i++)
                {
                    moveList = new List<string>(["R", "U", "F"]);
                    moveList.Remove(nextMove);
                    nextMove = moveList[randomMove.Next(0, moveList.Count)];
                    scramble = $"{scramble}, {nextMove}{moveModifier[randomMove.Next(0, 2)]}";
                }
                ParseAlgorithm(scramble);
                return;
            }
            else
            {
                Console.WriteLine("Please make a valid selection");
                Console.WriteLine();
                Console.Clear();
            }
        }
    }
    public virtual void SaveCubeState()
    {
        Console.WriteLine("What would you like to call this cube state?: ");
        string input = Console.ReadLine();
        Console.Clear();
        using (StreamWriter outputFile = new StreamWriter("..\\..\\..\\2x2cubestates.txt", false))
        {
            outputFile.WriteLine($"{input}:" + GenerateCubeState().GetDataString());
        }
    }

    public virtual void InputAlgorithm()
    {
        Console.WriteLine("Possible moves: R, R', R2, F, F', F2, U, U', U2");
        Console.WriteLine("Which moves would you like to make?(Seperate moves with commas): ");
        string alg = Console.ReadLine();
        Console.Clear();
        string input;
        while (true)
        {
            Console.WriteLine("Would you like to add this algorithm the the loaded list?(Y/N): ");
            input = Console.ReadLine();
            Console.Clear();
            if (input.ToLower() == "y")
            {
                Console.WriteLine("What would you like to call the algorithm?: ");
                alg = ParseAlgorithm(alg);
                if (alg == "")
                {
                    return;
                }
                _algList.Add(new Algorithm(Console.ReadLine(), alg));
            }
            else if (input.ToLower() == "n")
            {
                ParseAlgorithm(alg);
            }
            else
            {
                Console.WriteLine("Please make a valid selection");
                Console.WriteLine();
                Console.Clear();
                continue;
            }
            return;
        }
    }

    public virtual void SaveAlgorithms()
    {
        if (_algList.Count() < 1)
        {
            Console.WriteLine("No algorithms loaded to save");
            Console.ReadLine();
            Console.Clear();
        }
        else
        {
            string input;
            while (true)
            {
                Console.WriteLine("Are you sure you would like to save?(This overrides previous saved data)(Y/N): ");
                input = Console.ReadLine().ToLower();
                Console.Clear();
                if (input == "y")
                {
                    using (StreamWriter outputFile = new StreamWriter("..\\..\\..\\2x2algs.txt", false))
                    {
                        string dataString;
                        foreach (Algorithm alg in _algList)
                        {
                            dataString = $"{alg.GetAlgName()}; {alg.GetMoves().ToUpper()}";
                            outputFile.WriteLine(dataString);
                        }
                    }
                    return;
                }
                else if (input == "n")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Please make a valid selection.");
                    Console.WriteLine();
                    Console.Clear();
                }
            }
        }
    }
    public virtual void LoadAlgorithms()
    {
        _algList.Clear();
        string[] lines = System.IO.File.ReadAllLines("..\\..\\..\\2x2algs.txt");
        foreach (string line in lines)
        {
            _algList.Add(new Algorithm(line));
        }
    }
    public void ExecuteAlgorithm()
    {
        if (_algList.Count() == 0)
        {
            Console.WriteLine("No algorithms loaded");
            Console.ReadLine();
            Console.Clear();
            return;
        }
        else
        {
            int counter;
            string input;
            Algorithm currentAlg;
            while (true)
            {
                counter = 1;
                foreach (Algorithm alg in _algList)
                {
                    Console.WriteLine($"{counter}) {alg.GetAlgName()}: {alg.GetMoves()}");
                    counter++;
                }
                Console.WriteLine("Which algorithm would you like to execute?: ");
                input = Console.ReadLine();
                Console.Clear();
                try
                {
                    currentAlg = _algList[Convert.ToInt32(input) - 1];
                }
                catch
                {
                    Console.WriteLine("Please make a valid selection");
                    Console.WriteLine();
                    Console.Clear();
                    continue;
                }
                ParseAlgorithm(currentAlg.GetMoves());
                return;
            }
        }
    }
    public void DeleteAlgorithm()
    {
        int counter = 0;
        string input;
        string confirm;
        while (true)
        {
            foreach (Algorithm alg in _algList)
            {
                counter++;
                Console.WriteLine($"{counter}) {alg.GetAlgName()}: {alg.GetMoves()}");
            }
            Console.WriteLine("Which algorithm would you like to delete?: ");
            input = Console.ReadLine();
            Console.Clear();
            try
            {
                if (Convert.ToInt32(input) > _algList.Count())
                {
                    Console.WriteLine("Please make a valid selection");
                    Console.ReadLine();
                    Console.Clear();
                    return;
                }
            }
            catch
            {
                Console.WriteLine("Please make a valid selection");
                Console.ReadLine();
                Console.Clear();
                return;
            }
            while (true)
            {
                Console.WriteLine("Are you sure you would like to delete this?(Y/N): ");
                confirm = Console.ReadLine();
                Console.Clear();
                if (confirm.ToLower() == "y")
                {
                    try
                    {
                        _algList.RemoveAt(Convert.ToInt32(input) - 1);
                        return;
                    }
                    catch
                    {
                        Console.WriteLine("Please make a valid seleection");
                        Console.WriteLine();
                        Console.Clear();
                        break;
                    }
                }
                else if (confirm.ToLower() == "n")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Please make a valid selection");
                    Console.WriteLine();
                    Console.Clear();
                }
            }
        }
    }
    public void Help()
    {
        Console.Clear();
        Console.WriteLine("1) Set Cube State");
        Console.WriteLine("This function has 4 options. 'Reset' simply solves the cube. 'Load cube state' takes a cubestate that was saved previously and sets the current cube to that state.'Algorithm' resets the cube and then executes the moves that were input. This is useful for importing scrambles from cube timers. 'Scramble cube' simply picks 20 random moves and executes them");
        Console.WriteLine();
        Console.WriteLine("2)Save Cube State");
        Console.WriteLine("This function takes the current state of the cube and saves it to a text file. This is where the load cube state function reads from.");
        Console.WriteLine();
        Console.WriteLine("3) InputAlgorithm");
        Console.WriteLine("This function uses cube notation to execute moves on the cube. Type 'read' to take you to my website which covers how to read cube notation if interested. Here are some example algorithms to use:");
        Console.WriteLine("Checkerboard pattern (3x3): L2, R2, F2, B2, D2, U2");
        Console.WriteLine("Checkerboard pattern (2x2): R2, F2, R2, U2");
        Console.WriteLine("J-perm: R, U, R', U', R', F, R2, U', R', U', R, U, R', F'");
        Console.WriteLine("Cube in a cube in a cube (3x3): U', L', U', F', R2, B', R, F, U, B2, U, B', L, U', F, U, R, F");
        Console.WriteLine("Cube in a cube (2x2): R, F, U', R2, U, F', R, U, F2, R2");
        Console.WriteLine();
        Console.WriteLine("4) Load Algorithms");
        Console.WriteLine("This function loads algorithms from a text file and puts them into the algorithm list. When this is done the 'Execute Algorithms' and 'Save Algorithms' functions become available.");
        Console.WriteLine();
        Console.WriteLine("5) ExecuteAlgorithms");
        Console.WriteLine("This function simply runs the algorithm that was chosen.");
        Console.WriteLine();
        Console.WriteLine("6) DeleteAlgorithm");
        Console.WriteLine("This function deletes an algorithm from the loaded algorithms list.");
        string input = Console.ReadLine();
        if (input.ToLower() == "read")
        {
            Process myProcess = new Process();
            try
            {
                myProcess.StartInfo.UseShellExecute = true;
                myProcess.StartInfo.FileName = "https://joeykmoore13.github.io/wdd130/3x3_tutorial/notation_page.html";
                myProcess.Start();
            }
            catch
            {
                Console.WriteLine("Internal Error. Try again later.");
            }
        }
    }
    public virtual string ParseAlgorithm(string rawAlg)
    {
        Dictionary<string, System.Action> movesDict = new Dictionary<string, System.Action> { { "r", R }, { "r'", Rp }, { "r2", R2 }, { "u", U }, { "u'", Up }, { "u2", U2 }, { "f", F }, { "f'", Fp }, { "f2", F2 } };
        string[] splitAlg = rawAlg.ToLower().Split(",");
        List<string> moves = new List<string>(movesDict.Keys);
        foreach (string alg in splitAlg)
        {
            if (!moves.Contains(alg.Trim()))
            {
                Console.WriteLine("Failed to parse algorithm. An invalid move was detected.");
                Console.ReadLine();
                Console.Clear();
                return "";
            }
        }

        foreach (string alg in splitAlg)
        {
            movesDict[alg.Trim()]();
        }

        string cleanAlg = splitAlg[0];
        foreach (string alg in splitAlg.Skip(1))
        {
            cleanAlg = cleanAlg + $",{alg}";
        }
        return cleanAlg;
    }
    public virtual void ModifyCubeState(string dataString)
    {
        string[] pieces = dataString.Trim().Split("|");
        string[] components;
        foreach (string piece in pieces)
        {
            components = piece.Split(";");
            if (components[0] == "2")
            {
                _cornerList[components[1].Trim()] = new Corner(components[2]);
            }
        }
    }
    public virtual void ResetCube()
    {
        _cornerList.Clear();
        _cornerList.Add("ac", new Corner("ac", ConsoleColor.White, ConsoleColor.Red, ConsoleColor.Blue));
        _cornerList.Add("bc", new Corner("bc", ConsoleColor.White, ConsoleColor.Blue, ConsoleColor.DarkRed));
        _cornerList.Add("cc", new Corner("cc", ConsoleColor.White, ConsoleColor.DarkRed, ConsoleColor.Green));
        _cornerList.Add("dc", new Corner("dc", ConsoleColor.White, ConsoleColor.Green, ConsoleColor.Red));
        _cornerList.Add("uc", new Corner("uc", ConsoleColor.Yellow, ConsoleColor.Red, ConsoleColor.Green));
        _cornerList.Add("vc", new Corner("vc", ConsoleColor.Yellow, ConsoleColor.Green, ConsoleColor.DarkRed));
        _cornerList.Add("wc", new Corner("wc", ConsoleColor.Yellow, ConsoleColor.DarkRed, ConsoleColor.Blue));
        _cornerList.Add("xc", new Corner("xc", ConsoleColor.Yellow, ConsoleColor.Blue, ConsoleColor.Red));
    }

    public virtual CubeState GenerateCubeState()
    {
        return new CubeState(_cornerList);
    }

    public virtual void Display()
    {
        Console.WriteLine("\n");
        List<(string, int)> displayLocationList = new List<(string, int)>();
        displayLocationList.AddRange([("blank", 0), ("blank", 0), ("xc", 2), ("wc", 3), ("blank", 0), ("blank", 0), ("newline", 0), ("blank", 0), ("blank", 0), ("ac", 3), ("bc", 2), ("blank", 0), ("blank", 0), ("newline", 0), ("xc", 3), ("ac", 2), ("ac", 1), ("bc", 1), ("bc", 3), ("wc", 2), ("newline", 0), ("uc", 2), ("dc", 3), ("dc", 1), ("cc", 1), ("cc", 2), ("vc", 3), ("newline", 0), ("blank", 0), ("blank", 0), ("dc", 2), ("cc", 3), ("blank", 0), ("blank", 0), ("newline", 0), ("blank", 0), ("blank", 0), ("uc", 3), ("vc", 2), ("blank", 0), ("blank", 0), ("newline", 0), ("blank", 0), ("blank", 0), ("uc", 1), ("vc", 1), ("blank", 0), ("blank", 0), ("newline", 0), ("blank", 0), ("blank", 0), ("xc", 1), ("wc", 1), ("blank", 0), ("blank", 0)]);
        CubeState cubeState = GenerateCubeState();

        foreach ((string, int) key in displayLocationList)
        {
            switch (key.Item1)
            {
                case "blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("\u2588\u2588");
                    break;
                case "orange":
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\u2588\u2588");
                    break;
                case "white":
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\u2588\u2588");
                    break;
                case "red":
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("\u2588\u2588");
                    break;
                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("\u2588\u2588");
                    break;
                case "yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\u2588\u2588");
                    break;
                case "newline":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("");
                    break;
                case "blank":
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write("\u2588\u2588");
                    break;
                default:
                    if (key.Item2 == 1)
                    {
                        Console.ForegroundColor = cubeState.GetPieces()[key.Item1].GetColor();
                    }
                    else if (key.Item2 == 2)
                    {
                        Console.ForegroundColor = cubeState.GetPieces()[key.Item1].GetColorTwo();
                    }
                    else if (key.Item2 == 3)
                    {
                        Console.ForegroundColor = cubeState.GetPieces()[key.Item1].GetColorThree();
                    }

                    Console.Write("\u2588\u2588");
                    break;
            }
        }
        Console.ResetColor();
    }

    //All of the methods below corespond to a move on the rubik's cube. The p stands for 'prime' which means it is counterclockwise. The 2 means twice. No p or 2 means clockwise.
    //Each letter coresponds to a face of the rubik's cube. R means right, U for up, F for front.
    //These were not named with cammel case on purpose. Rubik's cube notation uses capital letters and 2's for moves so I formated the methods that perform moves to match.
    public virtual void R()
    {
        ClockwiseTurn("cc", "bc", "wc", "vc");
        _cornerList["cc"].TwistCounterClockwise();
        _cornerList["bc"].TwistClockwise();
        _cornerList["wc"].TwistCounterClockwise();
        _cornerList["vc"].TwistClockwise();
    }
    public virtual void Rp()
    {
        CounterClockwiseTurn("cc", "bc", "wc", "vc");
        _cornerList["cc"].TwistCounterClockwise();
        _cornerList["bc"].TwistClockwise();
        _cornerList["wc"].TwistCounterClockwise();
        _cornerList["vc"].TwistClockwise();
    }
    public virtual void R2()
    {
        DoubleTurn("cc", "bc", "wc", "vc");
    }
    public virtual void U()
    {
        ClockwiseTurn("ac", "bc", "cc", "dc");
    }
    public virtual void Up()
    {
        CounterClockwiseTurn("ac", "bc", "cc", "dc");
    }
    public virtual void U2()
    {
        DoubleTurn("ac", "bc", "cc", "dc");
    }
    public virtual void F()
    {
        ClockwiseTurn("dc", "cc", "vc", "uc");
        _cornerList["dc"].TwistCounterClockwise();
        _cornerList["cc"].TwistClockwise();
        _cornerList["vc"].TwistCounterClockwise();
        _cornerList["uc"].TwistClockwise();
    }
    public virtual void Fp()
    {
        CounterClockwiseTurn("dc", "cc", "vc", "uc");
        _cornerList["dc"].TwistCounterClockwise();
        _cornerList["cc"].TwistClockwise();
        _cornerList["vc"].TwistCounterClockwise();
        _cornerList["uc"].TwistClockwise();
    }
    public virtual void F2()
    {
        DoubleTurn("dc", "cc", "vc", "uc");
    }
    //These are to simplify moving pieces around
    public virtual void ClockwiseTurn(params string[] pieces)
    {
        Corner tempCorner1 = _cornerList[pieces[0]];
        Corner tempCorner2 = _cornerList[pieces[1]];
        Corner tempCorner3 = _cornerList[pieces[2]];
        Corner tempCorner4 = _cornerList[pieces[3]];

        _cornerList[pieces[1]] = tempCorner1;
        _cornerList[pieces[2]] = tempCorner2;
        _cornerList[pieces[3]] = tempCorner3;
        _cornerList[pieces[0]] = tempCorner4;

    }
    public virtual void CounterClockwiseTurn(params string[] pieces)
    {
        Corner tempCorner1 = _cornerList[pieces[0]];
        Corner tempCorner2 = _cornerList[pieces[1]];
        Corner tempCorner3 = _cornerList[pieces[2]];
        Corner tempCorner4 = _cornerList[pieces[3]];

        _cornerList[pieces[1]] = tempCorner3;
        _cornerList[pieces[2]] = tempCorner4;
        _cornerList[pieces[3]] = tempCorner1;
        _cornerList[pieces[0]] = tempCorner2;
    }
    public virtual void DoubleTurn(params string[] pieces)
    {
        Corner tempCorner1 = _cornerList[pieces[0]];
        Corner tempCorner2 = _cornerList[pieces[1]];
        Corner tempCorner3 = _cornerList[pieces[2]];
        Corner tempCorner4 = _cornerList[pieces[3]];

        _cornerList[pieces[1]] = tempCorner4;
        _cornerList[pieces[2]] = tempCorner1;
        _cornerList[pieces[3]] = tempCorner2;
        _cornerList[pieces[0]] = tempCorner3;
    }
    public virtual bool IsSolved()
    {
        foreach (var corner in _cornerList)
        {
            if (corner.Key != corner.Value.GetHomePosition())
            {
                return false;
            }
        }
        return true;
    }
    public List<Algorithm> GetAlgList()
    {
        return _algList;
    }
}