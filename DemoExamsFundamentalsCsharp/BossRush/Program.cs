using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Text.RegularExpressions;

namespace BossRush
{
    class Program
    {
        static void Main(string[] args)
        {
            int countLines = int.Parse(Console.ReadLine());

            for (int i = 0; i < countLines; i++)
            {
                string input = Console.ReadLine();

                var regex = new Regex(@"[|](?<boss>[A-Z]+)[|]:[#](?<title>[A-Za-z]+ [A-Za-z]+)[#]");
                var mach = regex.Match(input);

                if (mach.Success)
                {
                    string boss = mach.Groups["boss"].Value;
                    string title = mach.Groups["title"].Value;

                    Console.WriteLine($"{boss}, The {title}");
                    Console.WriteLine($">> Strength: {boss.Length}");
                    Console.WriteLine($">> Armour: {title.Length}");
                }
                else
                {
                    Console.WriteLine("Access denied!");
                }
            }
        }
    }
}
