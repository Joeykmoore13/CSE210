class Word
{
    private string _word;
    private bool _hidden = false;

    public Word()
    {
        _word = "";
    }

    public Word(string text)
    {
        _word = text;
    }

    public void DisplayWord()
    {
        if (_hidden == true)
        {
            char[] characters = _word.ToCharArray();
            for(int i = characters.Count(); i > 0; i--)
            {
                Console.Write("_");
            }
        }
        else
        {
            Console.Write(_word);
        }
    }

    public void HideWord()
    {
        _hidden = true;
    }

    public bool isVisible()
    {
        if (_hidden == true)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public string getWord()
    {
        return _word;
    }

}