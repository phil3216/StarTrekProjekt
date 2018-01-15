namespace StarTrekProjectIterativ
{
    using System;
    using static System.Console;

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
            string[] maleNamesTemp = GenerateAllNames(maleVulcanNames);
            string[] maleNamesAlternateTemp = GenerateAllNames(maleVulcanNamesAlternate);
            string[] maleNames = new string[maleNamesTemp.Length + maleNamesAlternateTemp.Length];

            maleNamesTemp.CopyTo(maleNames, 0);
            maleNamesAlternateTemp.CopyTo(maleNames, maleNamesTemp.Length);

            string[] femaleNames = GenerateAllNames(femaleVulcanNames);


            while (true)
            {
                Clear();
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


        }


        /// <summary>
        /// Takes a string array and writes it to the console
        /// </summary>
        /// <param name="text"></param>
        private static void WriteStringList(string[] text) => WriteLine(String.Join("\r\n", text));


        /// <summary>
        /// Takes a jagged array of strings and generates all the possible names starting from zero in the array
        /// </summary>
        /// <param name="options"></param>
        /// <example>
        /// The method takes an array like this
        /// <code>
        /// private static readonly string[][] femaleVulcanNames = new string[][]
        /// {
        ///     new string[] {"T’","C"},
        ///     new string[] {"P","K","Q"},
        ///     new string[] {"a","e","i","o","u","y"},
        ///     new string[] {"r","j","’p","k","l"},
        /// 
        /// };
        /// </code>
        /// And returns a list of the possibilities
        /// for example one of the generated names will be "T’Par", By taking "T’" from the first array, 
        /// taking "P" from the second array, taking "a" from the third array and taking "r" from the fourth array.
        /// </example>
        /// <remarks>
        /// The method starts from the first array in the jagged array, and then adds all the extra info for the rest
        /// </remarks>
        /// <returns></returns>
        private static string[] GenerateAllNames(string[][] options)
        {
            string[] names = new string[0];

            for (int i = 0; i < options.Length; i++)
            {
                string[] newTemp = i - 1 < 0 ? new string[options[i].Length] : 
                                               new string[names.Length * options[i].Length];

                int index = 0;

                for (int j = 0; j < options[i].Length; j++)
                {

                    if (i - 1 >= 0)
                    {
                        for (int k = 0; k < names.Length; k++)
                        {
                            newTemp[index] = names[k] + options[i][j];
                            index++;
                        }
                    }
                    else
                    {
                        newTemp[index] = options[i][j];
                        index++;
                    }

                }
                names = newTemp;

            }

            return names;
        }


    }
}
