using System;
using storeRunner; //This links the code space, the separate function, to here for the intro
public class Program
{
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to menu with one option!");
            Console.WriteLine("shop = s");
            Console.WriteLine("exit = e");

            string input = Console.ReadLine() ?? ""; //I tell it to ignore null with '??'
            input = input.ToLower(); // any cap letter is auto lower case so both cases are accpeted

            switch (input) //This is the switch box method i was talking about.
            {
                case "s":
                Store.RunStore();
                break;

                case "e":
                return;
            }
        }
    }
}