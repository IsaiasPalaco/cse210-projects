abstract class Activity
    {
        protected string _name;
        protected string _description;
        protected int _duration;
        protected int _timesPerformed;

        protected Activity(string name, string description)
        {
            _name = name;
            _description = description;
            _timesPerformed = 0;
        }

        public void Run()
        {
            DisplayStartingMessage();
            PerformActivity();
            DisplayEndingMessage();
            _timesPerformed++;
        }

        protected void DisplayStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"Starting: {_name}");
            Console.WriteLine(_description);
            Console.Write("Enter duration (in seconds): ");
            _duration = int.Parse(Console.ReadLine());

            Console.WriteLine("Prepare to begin...");
            ShowSpinner(3);
        }

        protected void DisplayEndingMessage()
        {
            Console.WriteLine("Good job!");
            Console.WriteLine($"You completed the {_name} for {_duration} seconds.");
            ShowSpinner(3);
        }

        protected void ShowSpinner(int seconds)
        {
            for (int i = 0; i < seconds; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }

        protected void ShowCountdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.WriteLine(i);
                Thread.Sleep(1000);
            }
        }

        protected abstract void PerformActivity();

        public int GetTimesPerformed()
        {
            return _timesPerformed;
        }
    }