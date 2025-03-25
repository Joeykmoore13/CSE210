class ThreeXThree : Cube
{
    private Center _center;
    private Dictionary<string, Edge> _edgeList;

    public ThreeXThree() : base()
    {
        _center = new Center(ConsoleColor.White);
        _edgeList = new Dictionary<string, Edge>();
        _edgeList.Add("A", new Edge("A", ConsoleColor.White, ConsoleColor.Blue));
        _edgeList.Add("B", new Edge("B", ConsoleColor.White, ConsoleColor.DarkRed));
        _edgeList.Add("C", new Edge("C", ConsoleColor.White, ConsoleColor.Green));
        _edgeList.Add("D", new Edge("D", ConsoleColor.White, ConsoleColor.Red));
        _edgeList.Add("L", new Edge("L", ConsoleColor.Green, ConsoleColor.Red));
        _edgeList.Add("J", new Edge("J", ConsoleColor.Green, ConsoleColor.DarkRed));
        _edgeList.Add("R", new Edge("R", ConsoleColor.Blue, ConsoleColor.Red));
        _edgeList.Add("T", new Edge("T", ConsoleColor.Blue, ConsoleColor.DarkRed));
        _edgeList.Add("U", new Edge("U", ConsoleColor.Yellow, ConsoleColor.Green));
        _edgeList.Add("V", new Edge("V", ConsoleColor.Yellow, ConsoleColor.DarkRed));
        _edgeList.Add("W", new Edge("W", ConsoleColor.Yellow, ConsoleColor.Blue));
        _edgeList.Add("X", new Edge("X", ConsoleColor.Yellow, ConsoleColor.Red));
    }

    public override void SetCubeState()
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
                cubeDataStrings = System.IO.File.ReadAllLines("..\\..\\..\\3x3cubestates.txt");
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
                    Console.WriteLine("Possible moves: R, U, F, L, B, D");
                    Console.WriteLine("Possible move modifiers: ' and 2");
                    Console.WriteLine("Which moves would you like to make?(Seperate moves with commas): ");
                    string alg = Console.ReadLine();
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
                List<string> moveList = new List<string>(["R", "U", "F", "L", "D", "B"]);
                List<string> moveModifier = new List<string>(["", "2", "'"]);
                Random randomMove = new Random();
                string scramble = moveList[randomMove.Next(0, moveList.Count)];
                moveList.Remove(scramble);
                string nextMove = $"{moveList[randomMove.Next(0, moveList.Count)]}";
                scramble = $"{scramble}, {nextMove}{moveModifier[randomMove.Next(0, 2)]}";
                for (int i = 0; i < 20; i++)
                {
                    moveList = new List<string>(["R", "U", "F", "L", "D", "B"]);
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
    public override void SaveCubeState()
    {
        Console.WriteLine("What would you like to call this cube state?: ");
        string input = Console.ReadLine();
        Console.Clear();
        using (StreamWriter outputFile = new StreamWriter("..\\..\\..\\3x3cubestates.txt", false))
        {
            outputFile.WriteLine($"{input}:" + GenerateCubeState().GetDataString());
        }
    }
    public override void InputAlgorithm()
    {
        Console.WriteLine("Possible moves: R, U, F, L, B, D, Rw, Lw, M");
        Console.WriteLine("Possible move modifiers: ' and 2");
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
    public override void SaveAlgorithms()
    {
        if (_algList.Count() < 1)
        {
            Console.WriteLine("No algorithms loaded to save");
            Console.WriteLine();
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
                    using (StreamWriter outputFile = new StreamWriter("..\\..\\..\\3x3algs.txt", false))
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
    public override void LoadAlgorithms()
    {
        _algList.Clear();
        string[] lines = System.IO.File.ReadAllLines("..\\..\\..\\3x3algs.txt");
        foreach (string line in lines)
        {
            _algList.Add(new Algorithm(line));
        }
    }
    public override string ParseAlgorithm(string rawAlg)
    {
        Dictionary<string, System.Action> movesDict = new Dictionary<string, System.Action> { { "r", R }, { "r'", Rp }, { "r2", R2 }, { "u", U }, { "u'", Up }, { "u2", U2 }, { "f", F }, { "f'", Fp }, { "f2", F2 }, { "l", L }, { "l'", Lp }, { "l2", L2 }, { "b", B }, { "b'", Bp }, { "b2", B2 }, { "d", D }, { "d'", Dp }, { "d2", D2 }, { "rw", Rw }, { "rw'", Rwp }, { "rw2", Rw2 }, { "lw", Lw }, { "lw'", Lwp }, { "lw2", Lw2 }, { "m", M }, { "m'", Mp }, { "m2", M2 } };
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
    public override void ModifyCubeState(string dataString)
    {
        string[] pieces = dataString.Trim().Split("|");
        string[] components;
        foreach (string piece in pieces)
        {
            components = piece.Split(";");
            if (components[0] == "1")
            {
                _edgeList[components[1].Trim()] = new Edge(components[2]);
            }
            else if (components[0] == "2")
            {
                _cornerList[components[1].Trim()] = new Corner(components[2]);
            }
            else if (components[0] == "3")
            {
                _center = new Center(components[2]);
            }
        }
    }
    public override void ResetCube()
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

        _edgeList.Clear();
        _edgeList.Add("A", new Edge("A", ConsoleColor.White, ConsoleColor.Blue));
        _edgeList.Add("B", new Edge("B", ConsoleColor.White, ConsoleColor.DarkRed));
        _edgeList.Add("C", new Edge("C", ConsoleColor.White, ConsoleColor.Green));
        _edgeList.Add("D", new Edge("D", ConsoleColor.White, ConsoleColor.Red));
        _edgeList.Add("L", new Edge("L", ConsoleColor.Green, ConsoleColor.Red));
        _edgeList.Add("J", new Edge("J", ConsoleColor.Green, ConsoleColor.DarkRed));
        _edgeList.Add("R", new Edge("R", ConsoleColor.Blue, ConsoleColor.Red));
        _edgeList.Add("T", new Edge("T", ConsoleColor.Blue, ConsoleColor.DarkRed));
        _edgeList.Add("U", new Edge("U", ConsoleColor.Yellow, ConsoleColor.Green));
        _edgeList.Add("V", new Edge("V", ConsoleColor.Yellow, ConsoleColor.DarkRed));
        _edgeList.Add("W", new Edge("W", ConsoleColor.Yellow, ConsoleColor.Blue));
        _edgeList.Add("X", new Edge("X", ConsoleColor.Yellow, ConsoleColor.Red));

        _center = new Center(ConsoleColor.White);
    }


    public override void Display()
    {
        Console.WriteLine("\n");
        List<(string, int)> displayLocationList = new List<(string, int)>();
        string[] centerColors = _center.GetColors();
        displayLocationList.AddRange([("blank", 0), ("blank", 0), ("blank", 0), ("xc", 2), ("W", 2), ("wc", 3), ("blank", 0), ("blank", 0), ("blank", 0), ("newline", 0), ("blank", 0), ("blank", 0), ("blank", 0), ("R", 1), (centerColors[0], 0), ("T", 1), ("blank", 0), ("blank", 0), ("blank", 0), ("newline", 0), ("blank", 0), ("blank", 0), ("blank", 0), ("ac", 3), ("A", 2), ("bc", 2), ("blank", 0), ("blank", 0), ("blank", 0), ("newline", 0), ("xc", 3), ("R", 2), ("ac", 2), ("ac", 1), ("A", 1), ("bc", 1), ("bc", 3), ("T", 2), ("wc", 2), ("newline", 0), ("X", 2), ("orange", 0), ("D", 2), ("D", 1), (centerColors[1], 0), ("B", 1), ("B", 2), ("red", 0), ("V", 2), ("newline", 0), ("uc", 2), ("L", 2), ("dc", 3), ("dc", 1), ("C", 1), ("cc", 1), ("cc", 2), ("J", 2), ("vc", 3), ("newline", 0), ("blank", 0), ("blank", 0), ("blank", 0), ("dc", 2), ("C", 2), ("cc", 3), ("blank", 0), ("blank", 0), ("blank", 0), ("newline", 0), ("blank", 0), ("blank", 0), ("blank", 0), ("L", 1), (centerColors[2], 0), ("J", 1), ("blank", 0), ("blank", 0), ("blank", 0), ("newline", 0), ("blank", 0), ("blank", 0), ("blank", 0), ("uc", 3), ("U", 2), ("vc", 2), ("blank", 0), ("blank", 0), ("blank", 0), ("newline", 0), ("blank", 0), ("blank", 0), ("blank", 0), ("uc", 1), ("U", 1), ("vc", 1), ("blank", 0), ("blank", 0), ("blank", 0), ("newline", 0), ("blank", 0), ("blank", 0), ("blank", 0), ("X", 1), (centerColors[3], 0), ("V", 1), ("blank", 0), ("blank", 0), ("blank", 0), ("newline", 0), ("blank", 0), ("blank", 0), ("blank", 0), ("xc", 1), ("W", 1), ("wc", 1), ("blank", 0), ("blank", 0), ("blank", 0)]);
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
    public override CubeState GenerateCubeState()
    {
        return new CubeState(_cornerList, _edgeList, _center);
    }

    //The same applies to these move methods as in the cube class. The odd formatting is on purpose to match notation.
    //Like in the cube class, all of the methods below corespond to a move on the rubik's cube. The R, F, and U methods are being overwritten to include moving edge pieces around
    public override void R()
    {
        ClockwiseTurn("cc", "bc", "wc", "vc", "B", "T", "V", "J");
        _cornerList["cc"].TwistCounterClockwise();
        _cornerList["bc"].TwistClockwise();
        _cornerList["wc"].TwistCounterClockwise();
        _cornerList["vc"].TwistClockwise();
    }
    public override void Rp()
    {
        CounterClockwiseTurn("cc", "bc", "wc", "vc", "B", "T", "V", "J");
        _cornerList["cc"].TwistCounterClockwise();
        _cornerList["bc"].TwistClockwise();
        _cornerList["wc"].TwistCounterClockwise();
        _cornerList["vc"].TwistClockwise();
    }
    public override void R2()
    {
        DoubleTurn("cc", "bc", "wc", "vc", "B", "T", "V", "J");
    }
    public override void U()
    {
        ClockwiseTurn("ac", "bc", "cc", "dc", "A", "B", "C", "D");
    }
    public override void Up()
    {
        CounterClockwiseTurn("ac", "bc", "cc", "dc", "A", "B", "C", "D");
    }
    public override void U2()
    {
        DoubleTurn("ac", "bc", "cc", "dc", "A", "B", "C", "D");
    }
    public override void F()
    {
        ClockwiseTurn("dc", "cc", "vc", "uc", "C", "J", "U", "L");
        _cornerList["dc"].TwistCounterClockwise();
        _cornerList["cc"].TwistClockwise();
        _cornerList["vc"].TwistCounterClockwise();
        _cornerList["uc"].TwistClockwise();

        _edgeList["C"].FlipEdge();
        _edgeList["J"].FlipEdge();
        _edgeList["U"].FlipEdge();
        _edgeList["L"].FlipEdge();
    }
    public override void Fp()
    {
        CounterClockwiseTurn("dc", "cc", "vc", "uc", "C", "J", "U", "L");
        _cornerList["dc"].TwistCounterClockwise();
        _cornerList["cc"].TwistClockwise();
        _cornerList["vc"].TwistCounterClockwise();
        _cornerList["uc"].TwistClockwise();

        _edgeList["C"].FlipEdge();
        _edgeList["J"].FlipEdge();
        _edgeList["U"].FlipEdge();
        _edgeList["L"].FlipEdge();
    }
    public override void F2()
    {
        DoubleTurn("dc", "cc", "vc", "uc", "C", "J", "U", "L");
    }
    public void M()
    {
        _center.M();
        Edge tempEdge1 = _edgeList["C"];
        Edge tempEdge2 = _edgeList["A"];
        Edge tempEdge3 = _edgeList["W"];
        Edge tempEdge4 = _edgeList["U"];

        _edgeList["A"] = tempEdge3;
        _edgeList["W"] = tempEdge4;
        _edgeList["U"] = tempEdge1;
        _edgeList["C"] = tempEdge2;

        _edgeList["A"].FlipEdge();
        _edgeList["W"].FlipEdge();
        _edgeList["U"].FlipEdge();
        _edgeList["C"].FlipEdge();

    }
    public void Mp()
    {
        _center.Mp();
        Edge tempEdge1 = _edgeList["C"];
        Edge tempEdge2 = _edgeList["A"];
        Edge tempEdge3 = _edgeList["W"];
        Edge tempEdge4 = _edgeList["U"];

        _edgeList["A"] = tempEdge1;
        _edgeList["W"] = tempEdge2;
        _edgeList["U"] = tempEdge3;
        _edgeList["C"] = tempEdge4;

        _edgeList["A"].FlipEdge();
        _edgeList["W"].FlipEdge();
        _edgeList["U"].FlipEdge();
        _edgeList["C"].FlipEdge();
    }
    public void M2()
    {
        _center.M2();
        Edge tempEdge1 = _edgeList["C"];
        Edge tempEdge2 = _edgeList["A"];
        Edge tempEdge3 = _edgeList["W"];
        Edge tempEdge4 = _edgeList["U"];

        _edgeList["A"] = tempEdge4;
        _edgeList["W"] = tempEdge1;
        _edgeList["U"] = tempEdge2;
        _edgeList["C"] = tempEdge3;
    }
    public void L()
    {
        ClockwiseTurn("ac", "dc", "uc", "xc", "D", "L", "X", "R");
        _cornerList["ac"].TwistCounterClockwise();
        _cornerList["dc"].TwistClockwise();
        _cornerList["uc"].TwistCounterClockwise();
        _cornerList["xc"].TwistClockwise();
    }
    public void Lp()
    {
        CounterClockwiseTurn("ac", "dc", "uc", "xc", "D", "L", "X", "R");
        _cornerList["ac"].TwistCounterClockwise();
        _cornerList["dc"].TwistClockwise();
        _cornerList["uc"].TwistCounterClockwise();
        _cornerList["xc"].TwistClockwise();
    }
    public void L2()
    {
        DoubleTurn("ac", "dc", "uc", "xc", "D", "L", "X", "R");
    }
    public void B()
    {
        ClockwiseTurn("bc", "ac", "xc", "wc", "A", "R", "W", "T");
        _cornerList["bc"].TwistCounterClockwise();
        _cornerList["ac"].TwistClockwise();
        _cornerList["xc"].TwistCounterClockwise();
        _cornerList["wc"].TwistClockwise();

        _edgeList["A"].FlipEdge();
        _edgeList["R"].FlipEdge();
        _edgeList["W"].FlipEdge();
        _edgeList["T"].FlipEdge();
    }
    public void Bp()
    {
        CounterClockwiseTurn("bc", "ac", "xc", "wc", "A", "R", "W", "T");
        _cornerList["bc"].TwistCounterClockwise();
        _cornerList["ac"].TwistClockwise();
        _cornerList["xc"].TwistCounterClockwise();
        _cornerList["wc"].TwistClockwise();

        _edgeList["A"].FlipEdge();
        _edgeList["R"].FlipEdge();
        _edgeList["W"].FlipEdge();
        _edgeList["T"].FlipEdge();
    }
    public void B2()
    {
        DoubleTurn("bc", "ac", "xc", "wc", "A", "R", "W", "T");
    }
    public void D()
    {
        ClockwiseTurn("uc", "vc", "wc", "xc", "U", "V", "W", "X");
    }
    public void Dp()
    {
        CounterClockwiseTurn("uc", "vc", "wc", "xc", "U", "V", "W", "X");
    }
    public void D2()
    {
        DoubleTurn("uc", "vc", "wc", "xc", "U", "V", "W", "X");
    }
    public void Rw()
    {
        R();
        Mp();
    }
    public void Rwp()
    {
        Rp();
        M();
    }
    public void Rw2()
    {
        R2();
        M2();
    }
    public void Lw()
    {
        L();
        M();
    }
    public void Lwp()
    {
        Lp();
        Mp();
    }
    public void Lw2()
    {
        L2();
        M2();
    }
    public override void ClockwiseTurn(params string[] pieces)
    {
        base.ClockwiseTurn(pieces);
        Edge tempEdge1 = _edgeList[pieces[4]];
        Edge tempEdge2 = _edgeList[pieces[5]];
        Edge tempEdge3 = _edgeList[pieces[6]];
        Edge tempEdge4 = _edgeList[pieces[7]];

        _edgeList[pieces[5]] = tempEdge1;
        _edgeList[pieces[6]] = tempEdge2;
        _edgeList[pieces[7]] = tempEdge3;
        _edgeList[pieces[4]] = tempEdge4;
    }
    public override void CounterClockwiseTurn(params string[] pieces)
    {
        base.CounterClockwiseTurn(pieces);

        Edge tempEdge1 = _edgeList[pieces[4]];
        Edge tempEdge2 = _edgeList[pieces[5]];
        Edge tempEdge3 = _edgeList[pieces[6]];
        Edge tempEdge4 = _edgeList[pieces[7]];

        _edgeList[pieces[5]] = tempEdge3;
        _edgeList[pieces[6]] = tempEdge4;
        _edgeList[pieces[7]] = tempEdge1;
        _edgeList[pieces[4]] = tempEdge2;
    }
    public override void DoubleTurn(params string[] pieces)
    {
        base.DoubleTurn(pieces);
        Edge tempEdge1 = _edgeList[pieces[4]];
        Edge tempEdge2 = _edgeList[pieces[5]];
        Edge tempEdge3 = _edgeList[pieces[6]];
        Edge tempEdge4 = _edgeList[pieces[7]];

        _edgeList[pieces[5]] = tempEdge4;
        _edgeList[pieces[6]] = tempEdge1;
        _edgeList[pieces[7]] = tempEdge2;
        _edgeList[pieces[4]] = tempEdge3;
    }
    public override bool IsSolved()
    {
        foreach (var corner in _cornerList)
        {
            if (corner.Key != corner.Value.GetHomePosition())
            {
                return false;
            }
        }
        foreach (var edge in _edgeList)
        {
            if (edge.Key != edge.Value.GetHomePosition())
            {
                return false;
            }
        }
        if (_center.GetOrientation() != 0)
        {
            return false;
        }
        return true;
    }
}