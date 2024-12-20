public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        bool exitProgram = false;

        while (!exitProgram)
        {
            Console.WriteLine("\n--- Eternal Quest Program ---");
            Console.WriteLine("1. Display Player Info");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. List Goal Details");
            Console.WriteLine("4. Create a Goal");
            Console.WriteLine("5. Record an Event");
            Console.WriteLine("6. Save Goals");
            Console.WriteLine("7. Load Goals");
            Console.WriteLine("8. Exit");
            Console.Write("Select an option: ");

            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    DisplayPlayerInfo();
                    break;
                case "2":
                    ListGoalNames();
                    break;
                case "3":
                    ListGoalDetails();
                    break;
                case "4":
                    CreateGoal();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    SaveGoals();
                    break;
                case "7":
                    LoadGoals();
                    break;
                case "8":
                    exitProgram = true;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Score: {_score}");
    }

    public void ListGoalNames()
    {
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetDetailsString());
        }
    }

    public void ListGoalDetails()
    {
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetStringRepresentation());
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\n--- Create a New Goal ---");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Select the type of goal to create: ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                CreateSimpleGoal();
                break;
            case "2":
                CreateEternalGoal();
                break;
            case "3":
                CreateChecklistGoal();
                break;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }

    private void CreateSimpleGoal()
    {
        Console.Write("Enter the goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter the goal description: ");
        string description = Console.ReadLine();

        Console.Write("Enter the points for completing the goal: ");
        if (int.TryParse(Console.ReadLine(), out int points))
        {
            SimpleGoal goal = new SimpleGoal(name, description, points);
            _goals.Add(goal);
            Console.WriteLine("Simple Goal created successfully!");
        }
        else
        {
            Console.WriteLine("Invalid points value. Goal creation canceled.");
        }
    }

    private void CreateEternalGoal()
    {
        Console.Write("Enter the goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter the goal description: ");
        string description = Console.ReadLine();

        Console.Write("Enter the points for recording the goal: ");
        if (int.TryParse(Console.ReadLine(), out int points))
        {
            EternalGoal goal = new EternalGoal(name, description, points);
            _goals.Add(goal);
            Console.WriteLine("Eternal Goal created successfully!");
        }
        else
        {
            Console.WriteLine("Invalid points value. Goal creation canceled.");
        }
    }

    private void CreateChecklistGoal()
    {
        Console.Write("Enter the goal name: ");
        string name = Console.ReadLine();

        Console.Write("Enter the goal description: ");
        string description = Console.ReadLine();

        Console.Write("Enter the points for each completion: ");
        if (int.TryParse(Console.ReadLine(), out int points))
        {
            Console.Write("Enter the target number of completions: ");
            if (int.TryParse(Console.ReadLine(), out int target))
            {
                Console.Write("Enter the bonus points for completing the goal: ");
                if (int.TryParse(Console.ReadLine(), out int bonus))
                {
                    ChecklistGoal goal = new ChecklistGoal(name, description, points, target, bonus);
                    _goals.Add(goal);
                    Console.WriteLine("Checklist Goal created successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid bonus points value. Goal creation canceled.");
                }
            }
            else
            {
                Console.WriteLine("Invalid target value. Goal creation canceled.");
            }
        }
        else
        {
            Console.WriteLine("Invalid points value. Goal creation canceled.");
        }
    }

    public void RecordEvent()
    {
        Console.WriteLine("Which goal did you accomplish?");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }

        int choice = int.Parse(Console.ReadLine()) - 1;

        if (choice >= 0 && choice < _goals.Count)
        {
            Goal selectedGoal = _goals[choice];
            selectedGoal.RecordEvent();

            _score += selectedGoal.Points;

            if (selectedGoal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
            {
                _score += checklistGoal.Bonus;
            }

            Console.WriteLine($"Event recorded! Current score: {_score}");
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }

    public void SaveGoals()
    {
        using (StreamWriter writer = new StreamWriter("goals.txt"))
        {
            writer.WriteLine(_score);
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals()
    {
        try
        {
            using (StreamReader reader = new StreamReader("goals.txt"))
            {
                _score = int.Parse(reader.ReadLine());
                _goals.Clear();

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    string goalType = parts[0];

                    switch (goalType)
                    {
                        case "SimpleGoal":
                            _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3])));
                            break;
                        case "EternalGoal":
                            _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                            break;
                        case "ChecklistGoal":
                            _goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5])));
                            break;
                        default:
                            Console.WriteLine($"Unknown goal type: {goalType}");
                            break;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading goals: {ex.Message}");
        }
    }
}
