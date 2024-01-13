using System;

class Program
{
    static void Main(string[] args)
    {
      List<int> numbers = new List<int>();
        int input;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        do
        {
            Console.Write("Enter number: ");
            input = int.Parse(Console.ReadLine());

            if (input != 0)
            {
                numbers.Add(input);
            }

        } while (input != 0);

        // Calculate sum
        int sum = numbers.Sum();

        // Calculate average
        double average = numbers.Average();

        // Find the maximum number
        int maxNumber = numbers.Max();

        // Find the smallest positive number
        int smallestPositive = numbers.Where(x => x > 0).Min();

        // Sort the numbers
        List<int> sortedNumbers = numbers.OrderBy(x => x).ToList();

        // Display results
        Console.WriteLine("The sum is: " + sum);
        Console.WriteLine("The average is: " + average);
        Console.WriteLine("The largest number is: " + maxNumber);
        Console.WriteLine("The smallest positive number is: " + smallestPositive);
        Console.WriteLine("The sorted list is:");
        foreach (int num in sortedNumbers)
        {
            Console.WriteLine(num);
        }  
    }
}