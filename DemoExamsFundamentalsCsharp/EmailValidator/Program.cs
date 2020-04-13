using System;
using System.Text;

namespace EmailValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();

            string commands = Console.ReadLine();

            while (commands != "Complete")
            {
                string[] infoCommands = commands.Split();

                switch (infoCommands[0])
                {
                    case "Make":
                        if (infoCommands[1] == "Upper")
                        {
                            email = email.ToUpper();

                            Console.WriteLine(email);
                        }
                        else if (infoCommands[1] == "Lower")
                        {
                            email = email.ToLower();

                            Console.WriteLine(email);
                        }
                        break;
                    case "GetDomain":
                        int lastCount = int.Parse(infoCommands[1]);

                        var result = email.Substring(email.Length - lastCount);

                        Console.WriteLine(result);
                        break;
                    case "GetUsername":
                        if (!email.Contains("@"))
                        {
                            Console.WriteLine($"The email {email} doesn't contain the @ symbol.");
                        }
                        else
                        {
                            string results = email.Substring(0, Math.Max(email.IndexOf('@'), 0));

                            Console.WriteLine(results);
                        }
                        break;
                    case "Replace":
                        var symbol = infoCommands[1];

                        email = email.Replace(symbol, "-");

                        Console.WriteLine(email);

                        break;
                    case "Encrypt":
                        byte[] asciiBytes = Encoding.ASCII.GetBytes(email);

                        Console.WriteLine(string.Join(" ", asciiBytes));
                        break;
                }

                commands = Console.ReadLine();
            }
        }
    }
}
