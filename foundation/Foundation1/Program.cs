using System;

class Program
{
    static void Main(string[] args)
    {
        List<Video> videos = new List<Video>();

        Video video1 = new Video("Introduction to C#", "Isaiah Palaco", 300);
        video1.AddComment(new Comment("Alberto", "Great video!"));
        video1.AddComment(new Comment("Ajape", "Very informative."));
        video1.AddComment(new Comment("Filomena", "Thanks for sharing!"));
        videos.Add(video1);

        Video video2 = new Video("Advanced C# Techniques", "Stella Xavier", 600);
        video2.AddComment(new Comment("Tina", "Amazing content."));
        video2.AddComment(new Comment("Lucas", "Really helpful examples."));
        videos.Add(video2);

        Video video3 = new Video("C# Design Patterns", "Chris Brown", 450);
        video3.AddComment(new Comment("Rihana", "Loved the explanation!"));
        video3.AddComment(new Comment("Karueche", "Very clear and concise."));
        video3.AddComment(new Comment("Lisa", "Please make more videos."));
        videos.Add(video3);

        foreach (var video in videos)
        {
            video.DisplayVideoDetails();
        }
    }
}