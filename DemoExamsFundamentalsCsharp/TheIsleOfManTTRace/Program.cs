using System;
using System.Text;
using System.Text.RegularExpressions;

namespace TheIsleOfManTTRace
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                string input = Console.ReadLine();

                string pattern = @"(?<start>[#|$|%|&|*])(?<name>[A-z]+)\k<start>=(?<lengthCode>[\d]+)!!(?<code>.+)";
                Match match = Regex.Match(input, pattern);

                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    int lengthCode = int.Parse(match.Groups["lengthCode"].Value);
                    string code = match.Groups["code"].Value;

                    if (lengthCode == code.Length)
                    {
                        StringBuilder decrypted = new StringBuilder();

                        for (int i = 0; i < code.Length; i++)
                        {
                            decrypted.Append((char)(code[i] + lengthCode));
                        }

                        Console.WriteLine($"Coordinates found! {name} -> {decrypted.ToString()}");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Nothing found!");
                    }
                }
                else
                {
                    Console.WriteLine("Nothing found!");
                }
            }
        }
    }
}
