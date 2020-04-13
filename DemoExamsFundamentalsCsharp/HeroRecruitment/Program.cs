using System;
using System.Collections.Generic;
using System.Linq;

namespace HeroRecruitment
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> hero = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] info = input.Split();

                string command = info[0];

                if (command == "Enroll")
                {
                    string name = info[1];
                    if (!hero.ContainsKey(name))
                    {
                        hero.Add(name, new List<string>());
                    }
                    else
                    {
                        Console.WriteLine($"{name} is already enrolled.");
                    }
                }
                else if (command == "Learn")
                {
                    string name = info[1];
                    string spellName = info[2];

                    if (!hero.ContainsKey(name))
                    {
                        Console.WriteLine($"{name} doesn't exist.");
                    }
                    else
                    {
                        if (!hero[name].Contains(spellName))
                        {
                            hero[name].Add(spellName);
                        }
                        else
                        {
                            Console.WriteLine($"{name} has already learnt {spellName}.");
                        }
                    }
                }
                else if (command == "Unlearn")
                {
                    string name = info[1];
                    string spellName = info[2];

                    if (!hero.ContainsKey(name))
                    {
                        Console.WriteLine($"{name} doesn't exist.");
                    }
                    else
                    {
                        if (!hero[name].Contains(spellName))
                        {
                            Console.WriteLine($"{name} doesn't know {spellName}.");
                        }
                        else
                        {
                            hero[name].Remove(spellName);
                        }
                    }
                }

                input = Console.ReadLine();
            }

            var sortedHero = hero.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key);

            Console.WriteLine("Heroes:");

            foreach (var heroes in sortedHero)
            {
                var name = heroes.Key;
                var spell = heroes.Value;

                Console.WriteLine($"== {name}: {string.Join(", ",spell)}");
            }
        }
    }
}
