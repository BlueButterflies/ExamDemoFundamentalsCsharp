using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Password
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Regex regex = new Regex(@"^(.+)>(?<first>\d{3})\|(?<second>[a-z]{3})\|(?<third>[A-Z]{3})\|(?<fourth>[^<>]{3})<\1$");
                Match match = regex.Match(input);

                if (match.Success)
                {
                    string first = match.Groups["first"].Value;
                    string second = match.Groups["second"].Value;
                    string third = match.Groups["third"].Value;
                    string fourth = match.Groups["fourth"].Value;

                    StringBuilder encrypter = new StringBuilder();

                    encrypter.Append(first);
                    encrypter.Append(second);
                    encrypter.Append(third);
                    encrypter.Append(fourth);

                    Console.WriteLine($"Password: {encrypter}");
                }
                else
                {
                    Console.WriteLine("Try another password!");
                }
            }

        }
    }
}
