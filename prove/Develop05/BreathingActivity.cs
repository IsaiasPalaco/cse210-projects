public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();
        int duration = 0;
        while (duration < GetDuration())
        {
            Console.WriteLine("Breathe in...");
            ShowCountDown(3);
            duration += 3;
            Console.WriteLine("Breathe out...");
            ShowCountDown(3);
            duration += 3;
        }
        DisplayEndingMessage();
    }

    private int GetDuration()
    {
        return int.Parse(Console.ReadLine());
    }
}