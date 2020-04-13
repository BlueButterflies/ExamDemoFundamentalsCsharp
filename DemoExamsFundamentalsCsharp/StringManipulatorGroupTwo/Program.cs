using System;

namespace StringManipulatorGroupTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] commands = Console.ReadLine().Split();

            while (commands[0] != "Done")
            {
                string infoCommand = commands[0];

                switch (infoCommand)
                {
                    case "Change":
                        string firstChar = commands[1];
                        string secondChar = commands[2];

                        input = input.Replace(firstChar, secondChar);

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
                    case "End":
                        string strValid = commands[1];

                        if (input.EndsWith(strValid))
                        {
                            Console.WriteLine("True");
                        }
                        else
                        {
                            Console.WriteLine("False");
                        }
                        break;
                    case "Uppercase":
                        input = input.ToUpper();

                        Console.WriteLine(input);
                        break;
                    case "FindIndex":
                        string index = commands[1];

                        int result = input.IndexOf(index);

                        Console.WriteLine(result);
                        break;
                    case "Cut":
                        int startIndex = int.Parse(commands[1]);
                        int length = int.Parse(commands[2]);

                        //string result
                        input = input.Substring(startIndex, length);

                        Console.WriteLine(input);
                        break;
                }

                commands = Console.ReadLine().Split();
            }
        }
    }
}
