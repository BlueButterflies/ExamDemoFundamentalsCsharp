using System;
using System.Text;
using System.Text.RegularExpressions;

namespace MessageEncrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Regex regex = new Regex(@"([*@%])([A-Z][a-z]{2,})\1:\s\[(\w)\]\|\[(\w)\]\|\[(\w)\]\|$");
                Match match = regex.Match(input);

                if (match.Success)
                {
                    string tag = match.Groups[2].Value;
                    string first = match.Groups[3].Value;
                    string second = match.Groups[4].Value;
                    string third = match.Groups[5].Value;

                    StringBuilder decrypted = new StringBuilder();

                    decrypted.Append(first + second + third);

                    byte[] asciiChar = Encoding.ASCII.GetBytes(decrypted.ToString());

                    Console.WriteLine($"{tag}: {string.Join(" ", asciiChar)}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
