using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep1 World!");
        Console.Write("What is your first name? ");
        string name1 = Console.ReadLine();
        Console.Write("What is your last name? ");
        string name2 = Console.ReadLine();
        Console.WriteLine($"your name is {name2}, {name1} {name2} ");

    }
}