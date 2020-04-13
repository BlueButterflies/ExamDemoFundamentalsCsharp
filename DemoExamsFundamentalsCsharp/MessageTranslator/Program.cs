using System;
using System.Text;
using System.Text.RegularExpressions;

namespace MessageTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            int countLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < countLines; i++)
            {
                string input = Console.ReadLine();

                Regex regex = new Regex(@"[!](?<command>[A-Z][a-z]{3,})[!]:[[](?<message>[A-Za-z]{8,})[]]");
                Match macth = regex.Match(input);

                if (macth.Success)
                {
                    string command = macth.Groups["command"].Value;
                    string message = macth.Groups["message"].Value;

                    byte[] asciiBytes = Encoding.ASCII.GetBytes(message);

                    var result = string.Join(" ", asciiBytes);

                    Console.WriteLine($"{command}: {result}");

                }
                else
                {
                    Console.WriteLine("The message is invalid");
                }
            }
        }
    }
}
