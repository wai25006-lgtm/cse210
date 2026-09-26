using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Try to figure out the magic number! ");
        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 100);

        int x = -1;

        while (x != magicNumber)
        {
            Console.WriteLine("What is your guess? ");
            x = int.Parse(Console.ReadLine());
            
            if (x < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (x > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }
        }
    }
}