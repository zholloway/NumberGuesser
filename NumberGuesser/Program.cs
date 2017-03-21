using System;
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
                //create array to store past guesses
                var pastGuesses = new decimal[5];

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

                        //if guess is low ask again and add to pastGuesses
                        if (parsedGuess < correctNum)
                        {
                            foreach (var position in pastGuesses)
                            {
                                if (parsedGuess == position)
                                {
                                    Console.WriteLine("You already guessed that! Feeling ok?");
                                    pastGuesses[i] = parsedGuess;
                                }
                                else
                                {
                                    Console.WriteLine($"Sorry, {parsedGuess} is too low!");
                                    pastGuesses[i] = parsedGuess;
                                }
                                break;
                            }
                        }
                        //if guess is high ask again and add to pastGuesses
                        else if (parsedGuess > correctNum)
                        {
                            foreach (var position in pastGuesses)
                            {
                                if (parsedGuess == position)
                                {
                                    Console.WriteLine("You already guessed that! Feeling ok?");
                                    pastGuesses[i] = parsedGuess;
                                }
                                else
                                {
                                    Console.WriteLine($"Sorry, {parsedGuess} is too high!");
                                    pastGuesses[i] = parsedGuess;
                                }
                                break;
                            }
                        }
                        //if guess correct then inform of win and break loop
                        else
                        {
                            Console.WriteLine($"Correct! The number was {correctNum}.");
                            guessCorrect = true;
                            break;
                        }
                    }
                    //display all guesses (need to not show unused guesses)
                    Console.WriteLine("So far you have guessed: ");
                    foreach (var guesses in pastGuesses)
                    {
                        Console.WriteLine(guesses);
                    }
                }
                //inform of failure and quit
                if (guessCorrect == false)
                {
                    Console.WriteLine("You failed");
                    guessCorrect = true;
                }

                Console.ReadLine();
            }
        }
    }
}
