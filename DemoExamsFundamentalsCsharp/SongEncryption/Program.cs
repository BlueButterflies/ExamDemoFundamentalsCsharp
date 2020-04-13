using System;
using System.Text;
using System.Text.RegularExpressions;

namespace SongEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "end")
            {
                Regex regex = new Regex(@"^(?<artist>[A-Z][a-z\s']+)[:](?<song>[A-Z\s]+)$");
                Match match = regex.Match(input);

                if (match.Success)
                {
                    string artist = match.Groups["artist"].Value;
                    string song = match.Groups["song"].Value;

                    int key = artist.Length;

                    string validInput = $"{artist}:{song}";

                    StringBuilder encrypted = new StringBuilder();

                    EncryptedValidInput(key, validInput, encrypted);

                    Console.WriteLine($"Successful encryption: {encrypted}");
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                input = Console.ReadLine();
            }
        }

        private static void EncryptedValidInput(int key, string validInput, StringBuilder encrypted)
        {
            foreach (var symbol in validInput)
            {
                char temp = symbol;

                if (symbol == ' ' || symbol == '\'')
                {
                    encrypted.Append(temp);
                    continue;
                }
                else if (symbol == ':')
                {
                    temp = '@';
                }
                else if (char.IsUpper(symbol))
                {
                    for (int i = 0; i < key; i++)
                    {
                        if (temp == 90)
                        {
                            temp = (char)65;
                        }
                        else
                        {
                            temp = (char)(temp + 1);
                        }
                    }
                }
                else if (char.IsLower(symbol))
                {
                    for (int i = 0; i < key; i++)
                    {
                        if (temp == 122)
                        {
                            temp = (char)97;
                        }
                        else
                        {
                            temp = (char)(temp + 1);
                        }
                    }
                }
                encrypted.Append(temp);
            }
        }
    }
}