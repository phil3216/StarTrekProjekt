using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTrekProjectIterativ
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



        private static void Main(string[] args)
        {



            List<string> maleNames = new List<string>();
            maleNames.AddRange(GenerateAllNames(maleVulcanNames.ToList()));
            maleNames.AddRange(GenerateAllNames(maleVulcanNamesAlternate.ToList()));


            List<string> femaleNames = new List<string>();
            femaleNames.AddRange(GenerateAllNames(femaleVulcanNames.ToList()));

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
                WriteStringList(femaleNames.OrderBy(x => x).ToList());
            }
            else
            {
                WriteStringList(maleNames.OrderBy(x => x).ToList());
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

        private static List<string> GenerateAllNames(List<string[]> options)
        {
            List<string> names = new List<string>();

            for (int i = 0; i < options.Count; i++)
            {
                
                List<string> newTemp = new List<string>(names.Count * options[i].Length);

                for (int j = 0; j < options[i].Length; j++)
                {

                    if (i - 1 >= 0)
                    {
                        for (int k = 0; k < names.Count; k++)
                        {
                            newTemp.Add(names[k] + options[i][j]);
                        }

                    }
                    else
                    {
                        newTemp.Add(options[i][j]);
                    }
                }
                names = newTemp;
            }
            return names;
        }


    }
}
