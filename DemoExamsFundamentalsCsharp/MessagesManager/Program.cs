using System;
using System.Collections.Generic;
using System.Linq;

namespace MessagesManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, MessagesInfo> users = new Dictionary<string, MessagesInfo>();
            
            int capasity = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                string[] infoIput = input.Split("=");

                if (infoIput[0] == "Add")
                {
                    if (!users.ContainsKey(infoIput[1]))
                    {
                        users.Add(infoIput[1], new MessagesInfo(int.Parse(infoIput[2]), int.Parse(infoIput[3])));
                    }
                }
                else if(infoIput[0] == "Message")
                {
                    if (users.ContainsKey(infoIput[1]) && users.ContainsKey(infoIput[2]))
                    {
                        users[infoIput[1]].Sent++;
                        users[infoIput[2]].Recived++;

                        if (users[infoIput[1]].Total >= capasity)
                        {
                            users.Remove(infoIput[1]);

                            Console.WriteLine($"{infoIput[1]} reached the capacity!");
                        }

                        if (users[infoIput[2]].Total >= capasity)
                        {
                            users.Remove(infoIput[2]);

                            Console.WriteLine($"{infoIput[2]} reached the capacity!");
                        }
                    }
                }
                else if (infoIput[0] == "Empty")
                {
                    if (infoIput[1] == "All")
                    {
                        users = new Dictionary<string, MessagesInfo>();
                    }
                    else if (users.ContainsKey(infoIput[1]))
                    {
                        users.Remove(infoIput[1]);
                    }
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"Users count: {users.Count}");

            foreach (var user in users.OrderByDescending(x => x.Value.Recived).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{user.Key} - {user.Value.Total}");
            }
        }
    }
}
