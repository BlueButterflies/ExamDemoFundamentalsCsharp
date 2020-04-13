using System;
using System.Text.RegularExpressions;

namespace Registration
{
    class Program
    {
        static void Main(string[] args)
        {
            int countLines = int.Parse(Console.ReadLine());

            int count = 0;

            for (int i = 0; i < countLines; i++)
            {
                string infoMail = Console.ReadLine();

                var regex = new Regex(@"^U\$(?<user>[A-Z][a-z]{2,})U\$P@\$(?<pass>[a-z]{5,}[0-9]+)P@\$$");
                var machInfo = regex.Match(infoMail);

                if (machInfo.Success)
                {
                    string user = machInfo.Groups["user"].Value;
                    string pass = machInfo.Groups["pass"].Value;

                    count++;

                        Console.WriteLine($"Registration was successful\nUsername: {user}, Password: {pass}");
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }
            }

            Console.WriteLine($"Successful registrations: {count}");
        }
    }
}
