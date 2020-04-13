using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace InboxManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> user = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                string[] infoInput = input.Split("->");

                string command = infoInput[0];
                string username = infoInput[1];

                if (command == "Add")
                {
                    if (user.ContainsKey(username))
                    {
                        Console.WriteLine($"{username} is already registered");
                    }
                    else
                    {
                        user.Add(username, new List<string>());
                    }
                }
                else if (command == "Send")
                {
                    string message = infoInput[2];

                    user[username].Add(message);
                }
                else if (command == "Delete")
                {
                    if (!user.ContainsKey(username))
                    {
                        Console.WriteLine($"{username} not found!");
                    }
                    else
                    {
                        user.Remove(username);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Users count: {user.Keys.Count}");

            var sortedUser = user.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key);

            foreach (var users in sortedUser)
            {
                Console.WriteLine(users.Key);

                foreach (var item in users.Value)
                {
                    Console.WriteLine($"- {item}");
                }
            }

        }
    }
}
