using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleManager
{

    class Program
    {

        static void Main(string[] args)
        {
            Dictionary<string, People> person = new Dictionary<string, People>();

            string[] info = Console.ReadLine().Split(":");

            while (info[0] != "Results")
            {
                string commands = info[0];

                if (commands == "Add")
                {
                    string name = info[1];
                    int health = int.Parse(info[2]);
                    int energy = int.Parse(info[3]);

                    if (!person.ContainsKey(name))
                    {
                        person.Add(name, new People(health, energy));
                    }
                    else
                    {
                        person[name].Health += health;
                    }
                }
                else if (commands == "Attack")
                {
                    string attackerName = info[1];
                    string defenderName = info[2];
                    int damage = int.Parse(info[3]);

                    if (person.ContainsKey(defenderName)&& person.ContainsKey(attackerName))
                    {
                        person[defenderName].Health -= damage;
                        person[attackerName].Energy--;
                        if (person[defenderName].Health <= 0)
                        {
                            person.Remove(defenderName);

                            Console.WriteLine($"{defenderName} was disqualified!");
                        }
                        if (person[attackerName].Energy <= 0)
                        {
                            person.Remove(attackerName);
                            Console.WriteLine($"{attackerName} was disqualified!");
                        }
                    }
                }
                else if (commands == "Delete")
                {
                    string user = info[1];

                    if (user == "All")
                    {
                        person = new Dictionary<string, People>();
                    }
                    else if (person.ContainsKey(user))
                    {
                        person.Remove(user);
                    }
                }

                info = Console.ReadLine().Split(":");
            }

            Console.WriteLine($"People count: {person.Count}");

            foreach (var people in person.OrderByDescending(x => x.Value.Health).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{people.Key} - {people.Value.Health} - {people.Value.Energy}");
            }
        }
    }
    //public class People
    //{
    //    public int Health { get; set; }
    //    public int Energy { get; set; }

    //    public People(int health, int energy)
    //    {
    //        this.Health = health;
    //        this.Energy = energy;
    //    }
    //}
}
