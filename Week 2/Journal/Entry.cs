using System;

public class Entry
{
    public string _date { get; set; }
    public string _promptText { get; set; }
    public string _entryText { get; set; }
    public string _mood { get; set; }

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Prompt: {_promptText}");
        Console.WriteLine($"Mood Rating: {_mood}");
        Console.WriteLine($"Response: {_entryText}");
        Console.WriteLine(new string('-', 45)); // Đường kẻ phân tách
    }
}