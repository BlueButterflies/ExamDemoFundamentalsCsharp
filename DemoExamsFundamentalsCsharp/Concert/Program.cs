using System;
using System.Collections.Generic;
using System.Linq;

namespace Concert
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> infoBands = new Dictionary<string, List<string>>();
            Dictionary<string, int> infoPlayBand = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "start of concert")
            {
                string[] info = input.Split("; ");

                string command = info[0];
                string bands = info[1];

                if (command == "Add")
                {
                    string[] members = info[2].Split(", ");

                    if (!infoBands.ContainsKey(bands))
                    {
                        infoBands.Add(bands, new List<string>());
                    }

                    for (int i = 0; i < members.Count(); i++)
                    {
                        if (!infoBands[bands].Contains(members[i]))
                        {
                            infoBands[bands].AddRange(members);
                        }
                    }

                }
                else if (command == "Play")
                {
                    int time = int.Parse(info[2]);

                    if (!infoPlayBand.ContainsKey(bands))
                    {
                        infoPlayBand.Add(bands, time);
                    }
                    else
                    {
                        infoPlayBand[bands] += time;
                    }
                }
                input = Console.ReadLine();
            }

            string band = Console.ReadLine();

            var sortedPlay = infoPlayBand.OrderByDescending(x => x.Value).ThenBy(x => x.Key);

            Console.WriteLine($"Total time: {infoPlayBand.Values.Sum()}");

            foreach (var item in sortedPlay)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }

            foreach (var nameBand in infoBands)
            {
                if (nameBand.Key == band)
                {
                    Console.WriteLine(nameBand.Key);

                    foreach (var members in nameBand.Value)
                    {
                        Console.WriteLine($"=> {members}");
                    }
                }
            }
        }
    }
}
