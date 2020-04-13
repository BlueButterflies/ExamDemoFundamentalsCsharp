using System;
using System.Collections.Generic;
using System.Linq;

namespace Followers
{
    public class InfoFollowers
    {
        public InfoFollowers(int like, int comment)
        {
            this.Like = like;
            this.Comment = comment;
        }

        public int Like { get; set; }
        public int Comment { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, InfoFollowers> followers = new Dictionary<string, InfoFollowers>();

            string[] commands = Console.ReadLine().Split(": ");

            while (commands[0] != "Log out")
            {
                switch (commands[0])
                {
                    case "New follower":

                        if (!followers.ContainsKey(commands[1]))
                        {
                            followers.Add(commands[1], new InfoFollowers(0, 0));
                        }
                        break;
                    case "Like":
                        if (!followers.ContainsKey(commands[1]))
                        {
                            followers.Add(commands[1], new InfoFollowers(int.Parse(commands[2]), 0));
                        }
                        else
                        {
                            followers[commands[1]].Like += int.Parse(commands[2]);
                        }
                        break;
                    case "Comment":
                        if (!followers.ContainsKey(commands[1]))
                        {
                            followers.Add(commands[1], new InfoFollowers(0, 1));
                        }
                        else
                        {
                            followers[commands[1]].Comment++;
                        }
                        break;
                    case "Blocked":
                        if (followers.ContainsKey(commands[1]))
                        {
                            followers.Remove(commands[1]);
                        }
                        else
                        {
                            Console.WriteLine($"{commands[1]} doesn't exist.");
                        }
                        break;
                }
                commands = Console.ReadLine().Split(": ");
            }

            var sorted = followers.OrderByDescending(x => x.Value.Like).ThenBy(x => x.Key);
            Console.WriteLine($"{followers.Count()} followers");
            foreach (var follower in sorted)
            {
                int sum = follower.Value.Like + follower.Value.Comment;



                Console.WriteLine($"{follower.Key}: {sum}");
            }
        }
    }
}
