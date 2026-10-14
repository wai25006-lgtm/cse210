using System;
using System.Collections.Generic;
using System.IO;

class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("Your journal is empty.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(
                    $"{entry._date}~|~{entry._prompt}~|~{entry._response}~|~{entry._mood}"
                );
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        string[] lines = File.ReadAllLines(filename);
        
        List<Entry> loadedEntries = new List<Entry>();

        foreach (string line in lines)
        {
            string[] parts = line.Split(
               new string[] { "~|~" },
               StringSplitOptions.None 
            );

            Entry entry = new Entry(
                parts[0], 
                parts[1], 
                parts[2], 
                parts[3]  
            );

            loadedEntries.Add(entry);
        }

        _entries = loadedEntries;

        Console.WriteLine("Journal loaded successfully!");
    }
}