using System.IO;
using System.IO.Enumeration;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry _entry in _entries)
        {
            _entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file, true))
        {
            foreach (Entry fileEntry in _entries)
            {
                outputFile.WriteLine($"{fileEntry._date},\"{fileEntry._promptText}\",\"{fileEntry._entryText}\"");
            }
            
        }
    }

    public void LoadFromFile(string file)
    {
        string[] lines = File.ReadAllLines(file);
        
        foreach (string line in lines)
        {
            Console.WriteLine(line);
        }
    }
}