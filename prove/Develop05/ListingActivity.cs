class ListingActivity : Activity
    {
        private readonly List<string> _prompts = new()
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "Who are some of your personal heroes?"
        };

        private int _count;

        public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        {
        }

        protected override void PerformActivity()
        {
            Console.WriteLine(GetRandomPrompt());
            Console.WriteLine("You have 5 seconds to prepare...");
            ShowSpinner(5);

            Console.WriteLine("Start listing items now:");
            List<string> items = GetListFromUser();

            _count = items.Count;
            Console.WriteLine($"You listed {_count} items.");
        }

        private string GetRandomPrompt()
        {
            Random random = new Random();
            return _prompts[random.Next(_prompts.Count)];
        }

        private List<string> GetListFromUser()
        {
            List<string> items = new();
            DateTime endTime = DateTime.Now.AddSeconds(_duration);
            while (DateTime.Now < endTime)
            {
                string input = Console.ReadLine();
                if (!string.IsNullOrEmpty(input))
                {
                    items.Add(input);
                }
            }
            return items;
        }
    }
