using System;

namespace StringManipulatorGroup1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] commands = Console.ReadLine().Split();

            while (commands[0] != "End")
            {
                string command = commands[0];

                switch (command)
                {
                    case "Translate":
                        string chr = commands[1];
                        string replaceChr = commands[2];

                        input = input.Replace(chr, replaceChr);

                        Console.WriteLine(input);
                        break;
                    case "Includes":
                        string str = commands[1];

                        if (input.Contains(str))
                        {
                            Console.WriteLine("True");
                        }
                        else
                        {
                            Console.WriteLine("False");
                        }
                        break;
                    case "Start":
                        string strValid = commands[1];

                        if (input.StartsWith(strValid))
                        {
                            Console.WriteLine("True");
                        }
                        else
                        {
                            Console.WriteLine("False");
                        }
                        break;
                    case "Lowercase":
                        input = input.ToLower();

                        Console.WriteLine(input);
                        break;
                    case "FindIndex":
                        string index = commands[1];

                        int result = input.LastIndexOf(index);

                        Console.WriteLine(result);
                        break;
                    case "Remove":
                        int startIndex = int.Parse(commands[1]);
                        int countForRemove = int.Parse(commands[2]);

                        input = input.Remove(startIndex, countForRemove);

                        Console.WriteLine(input);
                        break;
                }

                commands = Console.ReadLine().Split();
            }
        }
    }
}
