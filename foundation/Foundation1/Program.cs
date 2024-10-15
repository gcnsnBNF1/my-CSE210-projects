using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>
        {
            new Video("Most Dangerous Toys and Products Ever Made", "BE AMAZED", 1790),
            new Video("C# in 100 seconds", "Fireship", 146),
            new Video("I Filmed Plants For 15 Years | Time-lapse Compilation", "Boxlapse", 1839),
            new Video("Learn Python in Less than 10 Minutes for Beginners (Fast & Easy)", "Indently", 629)
        };

        videos[0].AddComment(new Comment("Gavin", "Interesting that some of these toys are still sold."));
        videos[0].AddComment(new Comment("Eve", "Fun video!"));
        videos[0].AddComment(new Comment("Autumn", "Scary that these toys existed."));

        videos[1].AddComment(new Comment("Addison", "Information was too vague."));
        videos[1].AddComment(new Comment("Quentin", "Too fast. Not enough information."));
        videos[1].AddComment(new Comment("Graydon", "A little fast but super informative."));

        videos[2].AddComment(new Comment("Sarah", "So fascinating to see how each of these plants grow."));
        videos[2].AddComment(new Comment("Allan", "Very well done."));
        videos[2].AddComment(new Comment("Gloria", "Time-lapses are always so cool to see."));

        videos[3].AddComment(new Comment("Mason", "Python is thoroughly demonstrated. Great work."));
        videos[3].AddComment(new Comment("Grace", "Thank you for making this video."));
        videos[3].AddComment(new Comment("Ava", "This helps out a ton. Thank you!"));

        for(int i = 0; i < videos.Count; i++)
        {
            Console.WriteLine($"Video {i + 1}");
            DisplayVideoInfo(videos[i]);
        }
    }

    static void DisplayVideoInfo(Video video)
    {
        Console.WriteLine($"Title: {video.GetTitle()}");
        Console.WriteLine($"Author: {video.GetAuthor()}");
        Console.WriteLine($"Length: {video.GetLength()} seconds");
        Console.WriteLine($"Number of comments: {video.GetCommentNumber()}:");
        foreach (var comment in video.GetComment())
        {
            Console.WriteLine($"- {comment.GetPerson()}: {comment.GetText()}");
        }
        Console.WriteLine();
    }
}