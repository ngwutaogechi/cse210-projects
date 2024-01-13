using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep2 World!");
        Console.Write("what is your grade percentage?");
        string gradePercentage = Console.ReadLine();
        int grade = int.Parse(gradePercentage);
        string letter = "";

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade>= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
           letter = "D";
        }
        else
        {
            letter = "F";
        }
        Console.WriteLine($"your grade is: {letter}");
        if (grade >= 70)
        {
            Console.WriteLine("congratulations you passed the class");
        } 
        else
        {
            Console.WriteLine("please work more hard to pass next term.");
        }
        // Stretch Challenge
        int lastDigit = grade % 10;
        string sign = "";

        // Determine the sign
        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit < 3)
        {
            sign = "-";
        }

        // Handle exceptional cases for A+ and F grades
        if (letter == "A" && lastDigit >= 7)
        {
            letter = "A-";
            sign = "";
        }

        else if (letter == "F" && lastDigit >= 3)
        {
            sign = "";
        }

        // Display both the grade letter and sign
        Console.WriteLine($"Your final grade is: {letter}{sign}");
    }
}