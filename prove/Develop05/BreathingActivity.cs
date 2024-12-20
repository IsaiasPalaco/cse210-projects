class BreathingActivity : Activity
    {
        public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by guiding you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        {
        }

        protected override void PerformActivity()
        {
            int interval = 4;
            for (int i = 0; i < _duration / (interval * 2); i++)
            {
                Console.WriteLine("Breathe in...");
                ShowCountdown(interval);
                Console.WriteLine("Breathe out...");
                ShowCountdown(interval);
            }
        }
    }
