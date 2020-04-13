using System;
using System.Collections.Generic;
using System.Linq;

namespace NikuldenSMeals
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> infoGuests = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            int countUnlike = 0;

            while (input != "Stop")
            {
                string[] info = input.Split("-");

                string command = info[0];
                string guest = info[1];
                string meal = info[2];

                switch (command)
                {
                    case "Like":

                        if (!infoGuests.ContainsKey(guest))
                        {
                            infoGuests.Add(guest, new List<string>());
                        }

                        if (!infoGuests[guest].Contains(meal))
                        {
                            infoGuests[guest].Add(meal);
                        }
                        break;
                    case "Unlike":

                        if (!infoGuests.ContainsKey(guest))
                        {
                            Console.WriteLine($"{guest} is not at the party.");
                        }
                        else if (infoGuests[guest].Contains(meal))
                        {
                            infoGuests[guest].Remove(meal);

                            countUnlike++;

                            Console.WriteLine($"{guest} doesn't like the {meal}.");
                        }
                        else
                        {
                            Console.WriteLine($"{guest} doesn't have the {meal} in his/her collection.");
                        }
                        break;
                }

                input = Console.ReadLine();
            }

            var sortedGuest = infoGuests.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key);

            foreach (var guests in sortedGuest)
            {
                Console.WriteLine($"{guests.Key}: {string.Join(", ", guests.Value)}");
            }

            Console.WriteLine($"Unliked meals: {countUnlike}");
        }
    }
}
