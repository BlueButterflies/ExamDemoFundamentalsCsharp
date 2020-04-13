using System;
using System.Linq;
using System.Text;

namespace NikuldenSCharity
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "Finish")
            {
                string[] commands = command.Split();

                switch (commands[0])
                {
                    case "Replace":
                        var currentChar = commands[1];
                        var newChar = commands[2];

                        input = input.Replace(currentChar, newChar);

                        Console.WriteLine(input);
                        break;
                    case "Cut":
                        int startIndex = int.Parse(commands[1]);
                        int endIndex = int.Parse(commands[2]);

                        if (startIndex >= 0 && startIndex <= input.Length
                        && endIndex >= startIndex && endIndex <= input.Length - 1)
                        {
                            string temp = new string(input);

                            temp = temp.Remove(startIndex, endIndex - startIndex + 1);
                            Console.WriteLine(temp);

                            input = temp;
                        }
                        else
                        {
                            Console.WriteLine("Invalid indexes!");
                        }
                        break;
                    case "Make":
                        if (commands[1] == "Upper")
                        {
                            input = input.ToUpper();

                            Console.WriteLine(input.Trim());
                        }
                        else if (commands[1] == "Lower")
                        {
                            input = input.ToLower();

                            Console.WriteLine(input.Trim());
                        }
                        break;
                    case "Check":
                        string str = commands[1];

                        if (input.Contains(str))
                        {
                            Console.WriteLine($"Message contains {str}");
                        }
                        else
                        {
                            Console.WriteLine($"Message doesn't contain {str}");
                        }
                        break;
                    case "Sum":

                        int start = int.Parse(commands[1]);
                        int end = int.Parse(commands[2]);

                        if (start >= 0 && start < input.Length
                        && end >= start && end < input.Length)
                        {
                            char[] arr;

                            arr = input.ToCharArray(start, end);

                            byte[] asciiBytes = Encoding.ASCII.GetBytes(arr);

                            Console.WriteLine(asciiBytes.Sum(x => x));
                        }
                        else
                        {
                            Console.WriteLine("Invalid indexes!");
                        }
                        break;
                }

                command = Console.ReadLine();
            }
        }
    }
}
