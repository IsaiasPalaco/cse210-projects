using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        while (true)
        {
            Console.WriteLine("Welcome to the journal program:");
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write new entry");
            Console.WriteLine("2. Display journal entries");
            Console.WriteLine("3. Save journal to file");
            Console.WriteLine("4. Load journal from file");
            Console.WriteLine("5. Exit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                WriteNewEntry(journal, promptGenerator);
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                SaveJournalToFile(journal);
            }
            else if (choice == "4")
            {
                LoadJournalFromFile(journal);
            }
            else if (choice == "5")
            {
                return;
            }
            else
            {
                Console.WriteLine("Invalid choice, please try again.");
            }
        }
    }

    static void WriteNewEntry(Journal journal, PromptGenerator promptGenerator)
    {
        string prompt = promptGenerator.GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Your response: ");
        string entryText = Console.ReadLine();
        string date = DateTime.Now.ToString("yyyy-MM-dd");

        Entry newEntry = new Entry(date, prompt, entryText);
        journal.AddEntry(newEntry);

        Console.WriteLine("Your entry has been saved.\n");
    }

    static void SaveJournalToFile(Journal journal)
    {
        Console.Write("Enter filename to save journal: ");
        string filename = Console.ReadLine();
        journal.SaveToFile(filename);
        Console.WriteLine("Journal saved successfully.\n");
    }

    static void LoadJournalFromFile(Journal journal)
    {
        Console.Write("Enter filename to load journal: ");
        string filename = Console.ReadLine();
        journal.LoadFromFile(filename);
        Console.WriteLine("Journal loaded successfully.\n");
    }
}