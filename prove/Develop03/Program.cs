using System;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptureLibrary = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16), "For God so loved the world that He gave His only begotten Son"),
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all your heart and lean not on your own understanding"),
            new Scripture(new Reference("Psalm", 23, 1), "The Lord is my shepherd I shall not want")
        };

        Random random = new Random();
        Scripture scripture = scriptureLibrary[random.Next(scriptureLibrary.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("\nThe scripture is fully hidden. Well done!");
                break;
            }

            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.Trim().ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }
    }
}




