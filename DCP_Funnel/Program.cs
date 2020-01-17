using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DCP_Funnel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            string testWord1 = "sails";
            string testWord2 = "sail";

            Console.WriteLine("FUNNEL");

            Console.WriteLine("Word 1: " + testWord1);
            Console.WriteLine("Word 2: " + testWord2);


            Console.WriteLine(funnel(testWord1,testWord2));

            Console.WriteLine("\r\n");

            string testWord3 = "dragoon";

            Console.WriteLine("BONUS");

            Console.WriteLine("Word 1: " + testWord3);

            Console.WriteLine(string.Join(",",bonus(testWord3)));

        }


        public static bool funnel(string w1, string w2)
        {
            bool simDist1 = false;
            List<string> w1Options = new List<string>();

            if (w1.Length - 1 != w2.Length)
            {
                return simDist1;
            }

            for(int i = 0; i < w1.Length; i++)
            {
                string tempWord = w1.Remove(i,1);
                w1Options.Add(tempWord);
            }

            foreach (string word in w1Options)
            {
                if (word == w2)
                {
                    simDist1 = true;
                }
            }

            return simDist1;
        }


        public static List<string> bonus(string w1)
        {
            List<string> w1Options = new List<string>();
            string pathToTextFile = "C:\\Users\\rgantt\\Desktop\\enable1.txt";
            List<string> matchList = new List<string>();


            for (int i = 0; i < w1.Length; i++)
            {
                string tempWord = w1.Remove(i, 1);
                w1Options.Add(tempWord);
            }

            foreach (string word in w1Options)
            {
                var word_match = File.ReadLines(pathToTextFile).Any(line => line.Equals(word));
                if (word_match) 
                {
                    if (!matchList.Contains(word)) {
                        matchList.Add(word);
                    }
                }
            }

            return matchList;
        }



        public static List<string> bonus2()
        {
            string pathToTextFile = "C:\\Users\\rgantt\\Desktop\\enable1.txt";
            int dictWordLengthMax = 0;

            List<string> w1Options = new List<string>();
            List<string> matchList = new List<string>();
            List<string> masterList = new List<string>();
            Dictionary<int, List<string>> lengthBasedDict = new Dictionary<int, List<string>>();


            //Populate master list and generate sublists based on word length
            using (StreamReader sr = File.OpenText(pathToTextFile)) {
                string dictWord;
                while ((dictWord = sr.ReadLine()) != null)
                {
                    masterList.Add(dictWord);

                    if (dictWord.Length > dictWordLengthMax)
                    {
                        for (int lengthCounter = dictWordLengthMax; lengthCounter >= dictWord.Length; lengthCounter++)
                        {
                            List<string> newLengthDict = new List<string>();
                            newLengthDict.Add(dictWord);
                            lengthBasedDict.Add(lengthCounter, newLengthDict);
                        }
                        dictWordLengthMax = dictWord.Length;

                    }
                    else
                    {
                        lengthBasedDict[dictWord.Length].Add(dictWord);
                    }
                }
            }

            //TO-DO
            //Use the bonus() on the appropriate lengthList
            for (int i = 0; i < w1.Length; i++)
            {
                string tempWord = w1.Remove(i, 1);
                w1Options.Add(tempWord);
            }

            foreach (string word in w1Options)
            {
                var word_match = File.ReadLines(pathToTextFile).Any(line => line.Equals(word));
                if (word_match)
                {
                    if (!matchList.Contains(word))
                    {
                        matchList.Add(word);
                    }
                }
            }

            return matchList;
        }


    }
}
