using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;

        string[] wordTexts = Regex.Split(text, @"\s+");
        foreach (var wordText in wordTexts)
        {
            if (!string.IsNullOrWhiteSpace(wordText))
            {
                _words.Add(new Word(wordText.Trim()));
            }
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        int hiddenCount = 0;
        while (hiddenCount < numberToHide)
        {
            int index = _random.Next(_words.Count);
            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                hiddenCount++;
            }
        }
    }

    public string GetDisplayText()
    {
        return $"{_reference.GetDisplayText()}\n" + string.Join(" ", _words.ConvertAll(word => word.GetDisplayText()));
    }

    public bool IsCompletelyHidden()
    {
        foreach (var word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}