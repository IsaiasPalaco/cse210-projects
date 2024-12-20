using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new()
            {
                new BreathingActivity(),
                new ListingActivity(),
                new ReflectingActivity()
            };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Mindfulness Program");
                Console.WriteLine("Select an activity:");

                Console.WriteLine();

                for (int i = 0; i < activities.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {activities[i].GetType().Name}");
                    Console.WriteLine($"   Times performed: {activities[i].GetTimesPerformed()}"); 
                }
                Console.WriteLine("0. Exit");

                int choice = int.Parse(Console.ReadLine());

                if (choice == 0)
                    break;

                if (choice > 0 && choice <= activities.Count)
                {
                    activities[choice - 1].Run();
                }
                else
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            }

            Console.WriteLine("Thank you for using the Mindfulness Program. Goodbye!");
    }
}