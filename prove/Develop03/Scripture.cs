using System;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void HideRandomWords(int count)
    {
        Random random = new Random();
        var visibleWords = _words.Where(word => !word.IsHidden()).ToList();

        foreach (var word in visibleWords.OrderBy(_ => random.Next()).Take(count))
        {
            word.Hide();
        }
    }

    public string GetDisplayText()
    {
        string scriptureText = string.Join(" ", _words.Select(word => word.GetDisplayText()));
        return $"{_reference.GetDisplayText()} - {scriptureText}";
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }
}


