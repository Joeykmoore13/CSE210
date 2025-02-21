using System.Text.RegularExpressions;

class Scripture
{
    private List<Verse> _verses = new List<Verse>();
    private List<Verse> _visibleVerses = new List<Verse>();
    private string _reference;

    public Scripture()
    {
        _reference = "";
    }

    public Scripture(string referenceText)
    {
        string[] splitVerses = Regex.Split(referenceText, @"(?=\d+)");
        foreach (string verse in splitVerses)
        {
            _verses.Add(new Verse(verse));
            _visibleVerses.Add(_verses.Last());
        }
    }

    public Scripture(string referenceText, string reference)
    {
        string[] splitVerses = Regex.Split(referenceText, @"(?=\d[0-9]{1,3})");
        foreach (string verse in splitVerses)
        {
            _verses.Add(new Verse(verse));
            _visibleVerses.Add(_verses.Last());
            
        }

        _reference = reference;
    }

    public void Display()
    {
        foreach (Verse verse in _verses)
        {
            verse.DisplayVerse();
            Console.WriteLine();
        }
    }

    public void HideWords()
    {
        Random rand = new Random();
        int range = rand.Next(0,3);
        int randVerse;
        for (int i = 0; _visibleVerses.Count() > 0 && i <= range; i++)
        {
            randVerse = rand.Next(0,_visibleVerses.Count());
            
            if (_visibleVerses[randVerse].IsHidden() == true)
            {
                i--;
                _visibleVerses.Remove(_visibleVerses[randVerse]);
            }
            else
            {
                _visibleVerses[randVerse].HideWord();
                if (_visibleVerses[randVerse].IsHidden() == true)
                {
                    _visibleVerses.Remove(_verses[randVerse]);
                }
            }
        }

    }

    public bool IsHidden()
    {
        if (_visibleVerses.Count() > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public string GetReference()
    {
        return _reference;
    }

}