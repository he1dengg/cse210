using System;
using System.Collections.Generic;

public class Comment
{
    public string Name { get; set; }
    public string Text { get; set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }
    
    public List<Comment> Comments { get; set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        LengthInSeconds = length;
        Comments = new List<Comment>();
    }

    public int GetCommentCount()
    {
        return Comments.Count;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Video> videosList = new List<Video>();

        Video video1 = new Video("C# Tutorial for Beginners", "ProgrammingKnowledge", 3600);
        video1.Comments.Add(new Comment("Alice", "Great tutorial, very easy to understand!"));
        video1.Comments.Add(new Comment("Bob", "Thanks for the help, saved my assignment."));
        video1.Comments.Add(new Comment("Charlie", "Can you make an advanced one?"));
        videosList.Add(video1);

        Video video2 = new Video("Top 10 Tech Trends in 2026", "Tech Insider", 950);
        video2.Comments.Add(new Comment("Dave", "AI is taking over everything."));
        video2.Comments.Add(new Comment("Eve", "I can't wait for quantum computing."));
        video2.Comments.Add(new Comment("Frank", "Very informative video, subscribed!"));
        videosList.Add(video2);

        Video video3 = new Video("Funny Cats Compilation", "CatLover99", 1200);
        video3.Comments.Add(new Comment("Grace", "So cute!"));
        video3.Comments.Add(new Comment("Heidi", "The second cat falling off the couch is hilarious."));
        video3.Comments.Add(new Comment("Ivan", "This totally made my day."));
        videosList.Add(video3);

        foreach (Video v in videosList)
        {
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine($"Title: {v.Title}");
            Console.WriteLine($"Author: {v.Author}");
            Console.WriteLine($"Length: {v.LengthInSeconds} seconds");
            Console.WriteLine($"Number of Comments: {v.GetCommentCount()}");
            Console.WriteLine("Comments:");
            
            foreach (Comment c in v.Comments)
            {
                Console.WriteLine($"  - {c.Name}: \"{c.Text}\"");
            }
            Console.WriteLine();
        }
    }
}