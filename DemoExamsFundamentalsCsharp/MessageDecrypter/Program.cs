using System;
using System.Text;
using System.Text.RegularExpressions;

namespace MessageDecrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                Regex regex = new Regex(@"^([$%])([A-Z][a-z]{2,})\1:\s\[(\d+)\]\|\[(\d+)\]\|\[(\d+)\]\|$");
                Match match = regex.Match(input);

                if (match.Success)
                {
                    string tag = match.Groups[2].Value;
                    int first = int.Parse(match.Groups[3].Value);
                    int second = int.Parse(match.Groups[4].Value);
                    int third = int.Parse(match.Groups[5].Value);

                    StringBuilder decrypted = new StringBuilder();

                    decrypted.Append((char)first);
                    decrypted.Append((char)second);
                    decrypted.Append((char)third);


                    Console.WriteLine($"{tag}: {decrypted.ToString()}");
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}
