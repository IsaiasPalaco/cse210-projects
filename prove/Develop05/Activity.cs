public abstract class Activity
{
    private string _name;
    private string _description;
    private int _duration;
    private static Dictionary<string, int> _activityLog = new Dictionary<string, int>();

    protected Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Starting {_name}...");
        Console.WriteLine(_description);
        Console.Write("Enter the duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine("Good job!");
        Console.WriteLine($"You have completed {_name} for {_duration} seconds.");
        ShowSpinner(3);
        LogActivity();
    }

    public void ShowSpinner(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            System.Threading.Thread.Sleep(1000);
        }
        Console.WriteLine();
    }

    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine(i);
            System.Threading.Thread.Sleep(1000);
        }
    }

    private void LogActivity()
    {
        if (_activityLog.ContainsKey(_name))
        {
            _activityLog[_name]++;
        }
        else
        {
            _activityLog[_name] = 1;
        }
    }

    public static void DisplayActivityLog()
    {
        Console.WriteLine("Activity Log:");
        foreach (var entry in _activityLog)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value} times");
        }
    }

    public abstract void Run();
}


