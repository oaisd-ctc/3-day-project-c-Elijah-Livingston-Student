using System;
public class Program
{
    public static void Main(string[] args)
    {
    
        int amountOfLives;
    StartOfGame:
        Console.Clear();
        Console.WriteLine("Welcome to Lawn Mowing Simulator 1: The Game!");
        Console.WriteLine("This game you will upgrade your mower, collect powerups, and run over obstacles!");
        Console.WriteLine("Would you like to begin, see credits or leave.");
        Console.WriteLine("(b/c/l)");
        string startChoice = Console.ReadLine();
        if (startChoice == "b")
        {
            Console.WriteLine("There are 3 difficulties! Easy, Hard, Impossible.");
            Console.WriteLine("(e/h/i)");
            string difficultyChoice = Console.ReadLine();
            if (difficultyChoice != "e" && difficultyChoice != "h" && difficultyChoice != "i")
            {
                Console.WriteLine("That is an invalid option!");
                goto StartOfGame;
            }
            if (difficultyChoice == "e")
            {
                amountOfLives = 10;

            }
            else if (difficultyChoice == "h")
            {
                amountOfLives = 5;
            }
            else
            {
                amountOfLives = 1;
            }

        }
        else if (startChoice == "c")
        {
            Console.WriteLine("David:");
            Thread.Sleep(100);
            Console.WriteLine("Shop");
            Thread.Sleep(100);
            Console.WriteLine("Heath:");
            Thread.Sleep(100);
            Console.WriteLine("Art, Movement");
            Thread.Sleep(100);
            Console.WriteLine("Al:");
            Thread.Sleep(100);
            Console.WriteLine("Powerup functions");
            Thread.Sleep(100);
            Console.WriteLine("Elijah:");
            Thread.Sleep(100);
            Console.WriteLine("Intro");
            Thread.Sleep(2000);
            goto StartOfGame;

        }
        else
        {
            Console.WriteLine("Bye!");
        }
    }
}