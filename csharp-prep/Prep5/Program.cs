using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();

        string name = PromptName();

        int number = PromptNumber();

        int squaredNumber = SquareNumber(number);

        int year;

        PromptYear(out year);

        DisplayResult(name, squaredNumber, year);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    static string PromptName()
    {
        Console.Write("Please enter your name: ");

        string name = Console.ReadLine();
        
        return name;
    }

    static int PromptNumber()
    {
        Console.Write("Please enter your favorite number: ");

        int number = int.Parse(Console.ReadLine());

        return number;
    }

    static int SquareNumber(int number)
    {
        int squaredNumber = number * number;

        return squaredNumber;
    }

    static void PromptYear(out int year)
    {
        Console.Write("Please enter the year you were born: ");

        year = int.Parse(Console.ReadLine());
    }

    static void DisplayResult(string name, int squaredNumber, int year)
    {
        Console.WriteLine($"{name}, the square of your favorite number is {squaredNumber}.");
        Console.WriteLine($"{name}, you will turn {2026 - year} years old this year.");
    }
}