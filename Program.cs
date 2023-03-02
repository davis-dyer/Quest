using System;
using System.Collections.Generic;

// Every class in the program is defined within the "Quest" namespace
// Classes within the same namespace refer to one another without a "using" statement
namespace Quest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is your name, adventurer?");
            string NewName = Console.ReadLine();
            //Phase 4 - #8 --- need to create this new instance of the Robe class before the robe parameter is passed into the Adventurer.
            Robe theRobe = new Robe();
            theRobe.Colors = new List<string>
            {
                "Peach", "Indigo", "Bright"
            };
            theRobe.Length = 36;
            Hat newHat = new Hat();
            newHat.ShininessLevel = 5;
            Adventurer theAdventurer = new Adventurer(NewName, theRobe, newHat);

            Prize newPrize = new Prize("You win eternal glory");

            //Showing the Adventurers attributes
            Console.WriteLine(theAdventurer.GetDescription());
            // Create a few challenges for our Adventurer's quest
            // The "Challenge" Constructor takes three arguments
            //   the text of the challenge
            //   a correct answer
            //   a number of awesome points to gain or lose depending on the success of the challenge
            Challenge twoPlusTwo = new Challenge("2 + 2?", 4, 10);
            Challenge theAnswer = new Challenge(
                "What's the answer to life, the universe and everything?", 42, 25);
            Challenge whatSecond = new Challenge(
                "What is the current second?", DateTime.Now.Second, 50);

            int randomNumber = new Random().Next() % 10;
            Challenge guessRandom = new Challenge("What number am I thinking of?", randomNumber, 25);

            Challenge favoriteBeatle = new Challenge(
                @"Who's your favorite Beatle?
    1) John
    2) Paul
    3) George
    4) Ringo
",
                4, 20
            );

            Challenge areYouADingDong = new Challenge(
                "On a scale of 1-10, how much of a ding-dong are ya?", 4, 500
            );

            Challenge lameMathProblem = new Challenge(
                "How much money is five cents?", 5, 15
            );

            Challenge cartWheels = new Challenge(
                "How many times can I cartwheel", 8, 10
            );

            Challenge octivePitch = new Challenge(
                "Sing right now and enter in the pitch you were in", 4, 90
            );

            // "Awesomeness" is like our Adventurer's current "score"
            // A higher Awesomeness is better

            // Here we set some reasonable min and max values.
            //  If an Adventurer has an Awesomeness greater than the max, they are truly awesome
            //  If an Adventurer has an Awesomeness less than the min, they are terrible
            int minAwesomeness = 0;
            int maxAwesomeness = 100;

            // Make a new "Adventurer" object using the "Adventurer" class
            //Adventurer theAdventurer = new Adventurer("Jack");

            // A list of challenges for the Adventurer to complete
            // Note we can use the List class here because have the line "using System.Collections.Generic;" at the top of the file.
            List<Challenge> challenges = new List<Challenge>()
            {
                twoPlusTwo,
                theAnswer,
                whatSecond,
                guessRandom,
                favoriteBeatle,
                areYouADingDong,
                lameMathProblem,
                cartWheels,
                octivePitch
            };

            List<int> random = new List<int>();

            while (random.Count != 5)
            {
                Random r = new Random();
                int index = r.Next(0, challenges.Count);
                if (!random.Contains(index))
                {
                    random.Add(index);
                }
            }




            // Loop through all the challenges and subject the Adventurer to them
            bool x = true;
            while (x == true)
            {
                foreach (int id in random)
                {
                    challenges[id].RunChallenge(theAdventurer);
                }

                // This code examines how Awesome the Adventurer is after completing the challenges
                // And praises or humiliates them accordingly
                if (theAdventurer.Awesomeness >= maxAwesomeness)
                {
                    Console.WriteLine("YOU DID IT! You are truly awesome!");
                }
                else if (theAdventurer.Awesomeness <= minAwesomeness)
                {
                    Console.WriteLine("Get out of my sight. Your lack of awesomeness offends me!");
                }
                else
                {
                    Console.WriteLine("I guess you did...ok? ...sorta. Still, you should get out of my sight.");
                }

                newPrize.ShowPrize(theAdventurer);

                Console.WriteLine("Would you like to try again? (y/n)");
                string TryRes = Console.ReadLine();
                if (TryRes.ToLower() == "n")
                {
                    x = false;
                }
                else if (TryRes.ToLower() == "y")
                {
                    theAdventurer.Awesomeness += (theAdventurer.numberRight * 10);
                    Console.WriteLine($"You have this many {theAdventurer.Awesomeness} points");
                    theAdventurer.numberRight = 0;
                }
            }
        }
    }
}
