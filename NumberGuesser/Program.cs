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
            var decisionValid = false;
            var gameComplete = false;

            while (decisionValid == false || gameComplete == false)
            {
                //give options
                Console.WriteLine("Would you like to guess a number or have the computer guess your number? Please type 'me' or 'computer'. Type 'quit' to exit.");
                var gameDecision = Console.ReadLine();
                if (gameDecision == "me")
                {
                    //enter written game -->
                    
                    //generate random number between 1 and 100
                    Random rand = new Random();
                    int correctNum = rand.Next(1, 101);
                    var pastGuesses = new decimal[5];
                    int i = 0;

                    while (gameComplete == false && i < 5)
                    {

                            // prompt user for a guess and inform of tries left

                            Console.WriteLine($"Guess a random number between 1 and 100! You have {5 - i} tries left.");

                            var userGuess = Console.ReadLine();

                            //make sure guess is a number
                            decimal parsedGuess = 0;
                            var parseSuccess = Decimal.TryParse(userGuess, out parsedGuess);

                            //correct number cheat
                            Console.WriteLine(correctNum);

                            if (parseSuccess)
                            {

                                //if guess is low ask again and add to pastGuesses
                                if (parsedGuess < correctNum)
                                {
                                    Console.Write($"Sorry, {parsedGuess} is too low!");

                                    var loopBreak = "";

                                    foreach (var position in pastGuesses)
                                    {
                                        if (parsedGuess == position && loopBreak != "break it")
                                        {
                                            Console.Write(" You already guessed that! Feeling ok?");
                                            pastGuesses[i] = parsedGuess;
                                            loopBreak = "break it";
                                        }
                                        else
                                        {
                                            if (parsedGuess < position && position != 0 && loopBreak != "break it")
                                            {
                                                Console.Write(" You already knew it'd be low.");
                                            }
                                            pastGuesses[i] = parsedGuess;
                                            loopBreak = "break it";
                                        }
                                    }
                                    Console.WriteLine("");
                                }
                                //if guess is high ask again and add to pastGuesses
                                else if (parsedGuess > correctNum)
                                {
                                    Console.Write($"Sorry, {parsedGuess} is too high!");

                                    var loopBreak = "";

                                    foreach (var position in pastGuesses)
                                    {
                                        if (parsedGuess == position && loopBreak != "break it")
                                        {
                                            Console.WriteLine("You already guessed that! Feeling ok?");
                                            pastGuesses[i] = parsedGuess;
                                            loopBreak = "break it";
                                        }
                                        else
                                        {
                                            if (parsedGuess > position && position != 0)
                                            {
                                                Console.Write(" You already knew it'd be high.");
                                            }
                                            pastGuesses[i] = parsedGuess;
                                            loopBreak = "break it";
                                        }
                                    }
                                    Console.WriteLine("");
                                }
                                //if guess correct then inform of win and break loop
                                else
                                {
                                    Console.WriteLine($"Correct! The number was {correctNum}.");
                                    gameComplete = true;
                                }
                            }

                        //display all guesses ()
                        if (gameComplete != true)
                        {
                            Console.WriteLine("So far you have guessed: ");
                            foreach (var guesses in pastGuesses)
                            {
                                if (guesses != 0)
                                {
                                    if (guesses < correctNum)
                                    {
                                        Console.WriteLine(guesses + " (Low)");
                                    }
                                    else
                                    {
                                        Console.WriteLine(guesses + " (High)");
                                    }
                                }
                            }
                        }

                        //tick up try count
                        i++;

                        //inform of failure and quit
                        if (i == 5)
                        {
                            Console.WriteLine("You failed");
                        }
                    }
                    
                    //break program loop
                    decisionValid = true;
                    gameComplete = true;
                    Console.ReadLine();
                }
                else if (gameDecision == "computer")
                {
                    //create computer guesser
                    Console.WriteLine("Nothing here yet, sorry.");

                    //generate random number 1-100
                    //ask if number is correct
                    //user respond to indicate low, high, or correct
                    //if low, create random number from guess#-100
                    //if high, create random number from 1-guess#

                    //break program loop
                    decisionValid = true;
                    gameComplete = true;
                }
                else if (gameDecision == "quit")
                {
                    decisionValid = true;
                    gameComplete = true;
                }
                else
                {
                    Console.WriteLine("Oops! Please enter a valid option");
                }
            }
        }
    }
}
