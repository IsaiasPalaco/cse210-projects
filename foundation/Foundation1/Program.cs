using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Introduction to C#", "John Doe", 300);
        video1.AddComment(new Comment("Alice", "Great video!"));
        video1.AddComment(new Comment("Bob", "Very informative."));
        video1.AddComment(new Comment("Charlie", "Thanks for sharing!"));
        videos.Add(video1);

        Video video2 = new Video("Advanced C# Techniques", "Jane Smith", 600);
        video2.AddComment(new Comment("Dave", "Amazing content."));
        video2.AddComment(new Comment("Eve", "Really helpful examples."));
        videos.Add(video2);

        Video video3 = new Video("C# Design Patterns", "Michael Brown", 450);
        video3.AddComment(new Comment("Frank", "Loved the explanation!"));
        video3.AddComment(new Comment("Grace", "Very clear and concise."));
        video3.AddComment(new Comment("Hank", "Please make more videos."));
        videos.Add(video3);

        foreach (var video in videos)
        {
            video.DisplayVideoDetails();
        }
    }
}