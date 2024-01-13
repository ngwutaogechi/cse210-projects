using System;
using System.Collections.Concurrent;

class Program
{
    static void Main(string[] args)
    {
       Random random = new Random();
        int magicNumber = random.Next(1, 100);
        
        //Console.Write("what is the magic number?");
        //string number = Console.ReadLine();
        //int magicNumber = int.Parse(number);
        int numberGuess;
        do
        {
            Console.Write("guess the number?");
            string guessNumber = Console.ReadLine();
            numberGuess = int.Parse(guessNumber);
            Random randomGenerator = new Random();
            if (magicNumber > numberGuess )
            {
                Console.WriteLine("high number");
            }
            else if (magicNumber < numberGuess)
            {
                Console.WriteLine("low number");
            }
            else
            {
              Console.WriteLine("you guessed it right");  
            }
        
        } while (magicNumber != numberGuess);
          
       
       
    }
}