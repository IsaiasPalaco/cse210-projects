public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();
        Random random = new Random();
        Console.WriteLine(_prompts[random.Next(_prompts.Count)]);
        ShowCountDown(5);

        int duration = GetDuration();
        int elapsedTime = 0;
        List<string> items = new List<string>();

        while (elapsedTime < duration)
        {
            Console.Write("Enter an item: ");
            items.Add(Console.ReadLine());
            elapsedTime += 2; // Simulating time spent per entry
        }

        Console.WriteLine($"You listed {items.Count} items.");
        DisplayEndingMessage();
    }

    private int GetDuration()
    {
        return int.Parse(Console.ReadLine());
    }
}
