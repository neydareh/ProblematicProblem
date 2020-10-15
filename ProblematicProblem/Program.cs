using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    public class Program
    {
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
        public static void Main(string[] args)
        {

            Random rng = new Random();
            bool cont = true;
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            
            string result = Console.ReadLine();
            cont = (result.ToLower() == "yes") ? true : false;
            

            Console.WriteLine();

            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();
            Console.WriteLine();

            Console.Write("What is your age? ");
            int userAge = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
            
            result = Console.ReadLine();
            bool seeList = (result.ToLower() == "yes" || result.ToLower() == "sure") ? true : false;
            
            if (seeList == true)
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }

                Console.WriteLine();


                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                result = Console.ReadLine();
                bool addToList = (result.ToLower() == "yes" || result.ToLower() == "sure") ? true : false;

                Console.WriteLine();

                while (addToList == true)
                {
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();

                    activities.Add(userAddition);

                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Would you like to add more? yes/no: ");
                    result = Console.ReadLine();
                    addToList = (result.ToLower() == "yes") ? true : false;
                }
            }

            while (cont != false)
            {
                Console.Write("Connecting to the database");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();


                Console.Write("Choosing your random activity");
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();

                int randomNumber = rng.Next(activities.Count);

                string randomActivity = activities[randomNumber];

                if (userAge < 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Pick something else!");

                    activities.Remove(randomActivity);

                    randomNumber = rng.Next(activities.Count);

                    randomActivity = activities[randomNumber];
                }

                Console.Write($"Ah got it! {randomActivity}, your random activity is: " +
                    $"{userName}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                cont = ((Console.ReadLine().ToLower()) == "redo" || (Console.ReadLine().ToLower()) == "keep") ? true : false;
            }

            Console.WriteLine();

        }
    }
}