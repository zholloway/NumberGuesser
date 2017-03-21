﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuesser
{
    class Program
    {
        static void Main(string[] args)
        {
            //generate random number between 1 and 100
            Random rand = new Random();
            int correctNum = rand.Next(1, 101);

            //user has maximum 5 incorrect guesses
            var guessCorrect = false;

            while (guessCorrect == false)
            {
                for (int i = 0; i < 5; i++)
                {
                    // prompt user for a guess and inform of tries left

                    Console.WriteLine($"Guess a random number between 1 and 100! You have {5 - i} tries left.");

                    var userGuess = Console.ReadLine();

                    //make sure guess is a number
                    decimal parsedGuess = 0;
                    var parseSuccess = Decimal.TryParse(userGuess, out parsedGuess);
                    if (parseSuccess)
                    {
                        //if guess is low ask again
                        if (parsedGuess < correctNum)
                        {
                            Console.WriteLine($"Sorry, {userGuess} is too low!");
                        }
                        //if guess is high ask again
                        else if (parsedGuess > correctNum)
                        {
                            Console.WriteLine($"Sorry, {userGuess} is too high!");
                        }
                        //if guess correct then inform of win and break loop
                        else
                        {
                            Console.WriteLine($"Correct! The number was {correctNum}.");
                            guessCorrect = true;
                            break;
                        }
                    }
                }
                //if all tries used, inform of failure and finish
                if (guessCorrect == false)
                {
                    Console.WriteLine("You failed the NACA challenge.");
                    guessCorrect = true;
                }
            }

            Console.ReadLine();
        }
    }
}
