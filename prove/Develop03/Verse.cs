class Verse
{
    private List<Word> _text = new List<Word>();
    private List<Word> _visibleText = new List<Word>();

    public Verse()
    {

    }

    public Verse(string text)
    {
        string[] splitText = text.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        foreach (string i in splitText)
        {
            _text.Add(new Word(i));
            _visibleText.Add(_text.Last());
        }
    }

    public void DisplayVerse()
    {
        foreach (Word word in _text)
        {
            word.DisplayWord();
            Console.Write(" ");
        }
    }

    public void HideWord()
    {
        Random rand = new Random();
        int wordIndex = rand.Next(0,_visibleText.Count());
        _text[_text.IndexOf(_visibleText[wordIndex])].HideWord();
        _visibleText.Remove(_visibleText[wordIndex]);

    }

    public bool IsHidden()
    {
        if (_visibleText.Count() > 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}