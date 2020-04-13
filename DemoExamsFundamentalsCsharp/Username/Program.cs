using System;
using System.Linq;

namespace Username
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "Sign up")
            {
                string[] commands = command.Split();

                switch (commands[0])
                {
                    case "Case":

                        if (commands[1] == "lower")
                        {
                            input = input.ToLower();

                            Console.WriteLine(input);
                        }
                        else
                        {
                            input = input.ToUpper();

                            Console.WriteLine(input);
                        }
                        break;

                    case "Reverse":

                        int startIndex = int.Parse(commands[1]);
                        int endIndex = int.Parse(commands[2]);



                        if (startIndex >= 0 && startIndex < endIndex && endIndex < input.Length)
                        {
                            var result = input.Substring(startIndex, endIndex - startIndex + 1);

                            Console.WriteLine(string.Join("",result.Reverse()));
                        }
                        else
                        {
                            continue;
                        }
                        break;

                    case "Cut":

                        if (input.Contains(commands[1]))
                        {
                            var res = input.Remove(input.IndexOf(commands[1]), commands[1].Length);

                            Console.WriteLine(res);
                        }
                        else
                        {
                            Console.WriteLine($"The word {input} doesn't contain {commands[1]}.");
                        }
                        break;

                    case "Replace":

                        input = input.Replace(commands[1], "*");

                        Console.WriteLine(input);
                        break;

                    case "Check":

                        if (input.Contains(commands[1]))
                        {
                            Console.WriteLine("Valid");
                        }
                        else
                        {
                            Console.WriteLine($"Your username must contain {commands[1]}.");
                        }
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
