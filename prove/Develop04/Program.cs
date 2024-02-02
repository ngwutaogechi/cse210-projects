using System;
using System.Threading;

// Base class for mindfulness activities
class MindfulnessActivity
{
    protected string activityName;
    protected string activityDescription;
    protected int duration;

    public MindfulnessActivity(string name, string description)
    {
        activityName = name;
        activityDescription = description;
    }

    public void StartActivity()
    {
        DisplayStartingMessage();
        PrepareForActivity();
        PerformActivity();
        DisplayEndingMessage();
    }

    protected virtual void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to {activityName}!");
        Console.WriteLine(activityDescription);
        Console.Write("Enter the duration in seconds: ");
        duration = int.Parse(Console.ReadLine());
        Console.WriteLine($"Get ready to start {activityName} in 3 seconds...");
        Thread.Sleep(3000);
    }

    protected virtual void PrepareForActivity()
    {
        // Additional preparations specific to each activity can be implemented in derived classes
    }

    protected virtual void PerformActivity()
    {
        // This method will be overridden in derived classes
    }

    protected virtual void DisplayEndingMessage()
    {
        Console.WriteLine($"Great job! You have completed {activityName} for {duration} seconds.");
        Thread.Sleep(2000);
    }
}

// Derived class for BreathingActivity
class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    protected override void PerformActivity()
    {
        Console.WriteLine("Let's begin the breathing exercise:");
        for (int i = 0; i < duration; i += 2)
        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(1000);
            Console.WriteLine("Breathe out...");
            Thread.Sleep(1000);
        }
    }
}

// Derived class for ReflectionActivity
class ReflectionActivity : MindfulnessActivity
{
    private string[] reflectionPrompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] reflectionQuestions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Reflection Activity", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    protected override void PerformActivity()
    {
        Random random = new Random();

        Console.WriteLine("Let's start the reflection activity:");
        for (int i = 0; i < duration; i += reflectionQuestions.Length)
        {
            string prompt = reflectionPrompts[random.Next(reflectionPrompts.Length)];
            Console.WriteLine(prompt);

            foreach (var question in reflectionQuestions)
            {
                Console.WriteLine(question);
                Thread.Sleep(2000); // Pause with a spinner
            }
        }
    }
}

// Derived class for ListingActivity
class ListingActivity : MindfulnessActivity
{
    private string[] listingPrompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    protected override void PerformActivity()
    {
        Random random = new Random();

        Console.WriteLine("Let's start the listing activity:");
        string prompt = listingPrompts[random.Next(listingPrompts.Length)];
        Console.WriteLine(prompt);
        Thread.Sleep(2000); // Pause to think about the prompt

        Console.WriteLine("Start listing items:");

        // Let the user list items until the duration is reached
        for (int i = 0; i < duration; i++)
        {
            string item = Console.ReadLine();
            if (string.IsNullOrEmpty(item))
                break; // Stop if the user doesn't enter anything
        }

        Console.WriteLine($"You listed {duration} items.");
    }
}
//to exceed requirments, here i added another activity called "visualizationActivity". 
// Derived class for VisualizationActivity
class VisualizationActivity : MindfulnessActivity
{
    private string[] visualizationPrompts = {
        "Imagine yourself in a peaceful garden.",
        "Visualize a calming beach with gentle waves.",
        "Picture a serene mountain landscape."
    };

    public VisualizationActivity() : base("Visualization Activity", "This activity will help you relax by guiding you through a visualization exercise.")
    {
    }

    protected override void PerformActivity()
    {
        Random random = new Random();

        Console.WriteLine("Let's start the visualization activity:");
        for (int i = 0; i < duration; i++)
        {
            string prompt = visualizationPrompts[random.Next(visualizationPrompts.Length)];
            Console.WriteLine(prompt);
            Thread.Sleep(2000); // Pause with a spinner
        }
    }
}


class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness App Menu");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Visualization Activity"); // Added option
            Console.WriteLine("5. Exit");

            Console.Write("Choose an activity (1-5): ");
            int choice = int.Parse(Console.ReadLine());

            MindfulnessActivity activity;

            switch (choice)
            {
                case 1:
                    activity = new BreathingActivity();
                    break;
                case 2:
                    activity = new ReflectionActivity();
                    break;
                case 3:
                    activity = new ListingActivity();
                    break;
                case 4:
                    activity = new VisualizationActivity(); // Added activity
                    break;
                case 5:
                    Console.WriteLine("Exiting the program. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    continue;
            }

            Console.Clear();
            activity.StartActivity();
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }
    }
}
