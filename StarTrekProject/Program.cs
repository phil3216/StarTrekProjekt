using System;
using System.Collections.Generic;
using System.Text;

namespace StarTrekProject
{
    using System.Diagnostics;
    using static Console;

    internal class Program
    {
        #region MaleVulcanNameOptions

        private static readonly string[][] maleVulcanNames = new string[][]
        {
            new string[] {"S","Sp","Sk","T"},

            new string[] { "a","e","i","o","u","y" },

            new string[] { "r","t","p","d","f","j","k","l","v","b","n","m"},

            new string[] { "a","e","i","o","u","y"},

            new string[] {"q","p","k","ck","l"}

        };

        private static readonly string[][] maleVulcanNamesAlternate = new string[][]
        {
            new string[] {"S","Sp","Sk","T"},

            new string[] { "a","e","i","o","u","y" },

            new string[] { "q","p","k","ck","l"},

        };

        #endregion

        #region FemaleVulcanNameOptions

        private static readonly string[][] femaleVulcanNames = new string[][]
        {
            new string[] {"T’","C"},

            new string[] {"P","K","Q"},

            new string[] {"a","e","i","o","u","y"},
            new string[] {"r","j","’p","k","l"},

        };

        #endregion

        private static void Main()
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            for (int i = 0; i < 10_000; i++)
            {
                GenerateAllNames(maleVulcanNames);
            }
            s.Stop();
            Debug.WriteLine(s.Elapsed);

            List<string> maleNames = new List<string>();
            maleNames.AddRange(GenerateAllNames(maleVulcanNames, ""));
            maleNames.AddRange(GenerateAllNames(maleVulcanNamesAlternate, ""));

            List<string> femaleNames = new List<string>();
            femaleNames.AddRange(GenerateAllNames(femaleVulcanNames, ""));

            WriteLine("Vis 1. Hunkøn eller 2. Hankøn");

            string Answer = ReadLine();
            int result = 0;
            while (!int.TryParse(Answer, out result) && !(result == 1 || result == 2))
            {
                WriteLine("Forkert skriv 1 for Hunkøn og 2 for Hankøn");
                Answer = ReadLine();
            }

            Clear();

            if (result == 1)
            {
                WriteStringList(femaleNames);
            }
            else
            {
                WriteStringList(maleNames);
            }

            ReadLine();
        }

        private static void WriteStringList(List<string> text)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in text)
            {
                sb.AppendLine(item);
            }

            WriteLine(sb.ToString());
        }

        private static string[] GenerateAllNames(string[][] options, string s = "", int index = 0)
        {
            List<string> names = new List<string>();

            if (options.Length > index)
            {
                foreach (var item in options[index])
                {
                    names.AddRange(GenerateAllNames(options, s + item, index + 1));
                }
            }
            else
            {
                names.Add(s);
            }

            return names.ToArray();
        }
    }
}
