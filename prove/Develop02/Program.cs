using System;

class Program
{
    static void Main(string[] args)
    {
        // Creative feature: I added a mood tracker so users can record how they felt each day along with their journal entry.
        Journal journal = new Journal();

        string[] prompts =
        {
            "What was the best part of your day?",
            "What am I grateful for today?",
            "Who made me smile today?",
            "What is something new I learned?",
            "What is one thing I want to improve tomorrow?",
            "What was the strongest emotion I felt today?",
            "What is a memory from today I want to remember?"
        };

        Random random = new Random();

        string choice = "";

        while (choice != "5")
        {
            Console.WriteLine("Journal Menu: ");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display journal");
            Console.WriteLine("3. Save journal");
            Console.WriteLine("4. Load journal");
            Console.WriteLine("5. Quit");

            Console.Write("Choose an option: ");
            choice = Console.ReadLine() ?? "";

            if (choice =="1")
            {
                string prompt = prompts[random.Next(prompts.Length)];
                Console.WriteLine(prompt);

                Console.Write("> ");
                string response = Console.ReadLine() ?? "";

                string date = DateTime.Now.ToShortDateString();

                Console.Write("How would you describe your overall mood today? ");
                string mood = Console.ReadLine() ?? "";

                Entry entry = new Entry(date, prompt, response, mood);
                journal.AddEntry(entry);
            }

            else if (choice == "2")
            {
                journal.DisplayAll();
            }

            else if (choice == "3")
            {
                Console.Write("Enter a filename: ");
                string filename = Console.ReadLine() ?? "";

                try
                {
                    journal.SaveToFile(filename);
                    Console.WriteLine("Journal saved successfully.");
                }
                catch (IOException)
                {
                    Console.WriteLine("Could not save the file. Check the filename.");
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("You don't have permission to save there.");
                }

                journal.SaveToFile(filename);
            }

            else if (choice == "4")
            {
                Console.Write("Enter the filename to load: ");
                string filename = Console.ReadLine() ?? "";

                try
                {
                    journal.LoadFromFile(filename);
                }
                catch (IOException)
                {
                    Console.WriteLine("Could not read the file. Check the filename.");
                }
                catch (UnauthorizedAccessException)
                {
                    Console.WriteLine("You don't have permission to read that file.");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("The file doesn't have the expected journal format.");
                }

                journal.LoadFromFile(filename);
            }
        }

        Console.WriteLine("Goodbye!");
    }
}