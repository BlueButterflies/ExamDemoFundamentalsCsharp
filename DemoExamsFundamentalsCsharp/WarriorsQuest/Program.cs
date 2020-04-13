using System;

namespace WarriorsQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            string skills = Console.ReadLine();

            string commands = Console.ReadLine();

            while (commands != "For Azeroth")
            {
                string[] infoCommands = commands.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                switch (infoCommands[0])
                {
                    case "GladiatorStance":
                        skills = skills.ToUpper();

                        Console.WriteLine(skills.Trim());
                        break;
                    case "DefensiveStance":
                        skills = skills.ToLower();

                        Console.WriteLine(skills.Trim());
                        break;
                    case "Dispel":
                        int index = int.Parse(infoCommands[1]);
                        var letters = infoCommands[2];

                        try
                        {
                            skills = skills.Remove(index, 1).Insert(index, letters);
                            Console.WriteLine("Success!");
                        }
                        catch
                        {
                            Console.WriteLine("Dispel too weak.");
                        }
                        break;
                    case "Target":

                        if (infoCommands[1] == "Change")
                        {
                            string first = infoCommands[2];
                            string second = infoCommands[3];

                            skills = skills.Replace(first, second);

                            Console.WriteLine(skills.Trim());
                        }
                        else if (infoCommands[1] == "Remove")
                        {
                            string substring = infoCommands[2];

                            int indexes = skills.IndexOf(substring);
                            skills = skills.Remove(indexes, substring.Length);

                            Console.WriteLine(skills.Trim());
                        }
                        else
                        {
                            Console.WriteLine("Command doesn't exist!");
                        }
                        break;

                    default:
                        Console.WriteLine("Command doesn't exist!");
                        break;
                }

                commands = Console.ReadLine();
            }
        }
    }
}
