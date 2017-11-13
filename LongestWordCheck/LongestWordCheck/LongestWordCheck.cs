using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestWordCheck
{
    class LongestWordCheck
    {
        static void Main(string[] args)
        {
            List<string> allwords = ReadfromFileToArray();
            allwords = Sort(allwords);
            Find(allwords);
            Console.ReadKey();
        }

        //Find the longest word that can be created out of other words in the list
        //Also to find the total count of words that can be created out of other words in the list
        static void Find(List<string> list)
        {
            int totalCount = 0;
            String MainWord;
            Int64 maxlength = 0;
            for (int i = list.Count - 1; i >= 0; i--)
            {
                MainWord = list[i];
                for (int j = i - 1; j >= 0; j--)
                {
                    if (list[i].Length != list[j].Length && list[i].Length != list[0].Length)
                    {
                        if (MainWord.Contains(list[j]))
                        {
                            MainWord = MainWord.Replace(list[j], " ");
                            if (MainWord.Trim() == string.Empty)
                            {
                                totalCount++;
                                if (maxlength == 0)
                                {
                                    maxlength = list[i].Length;
                                }
                                if (maxlength == list[i].Length)
                                {
                                    Console.Write(list[i] + "\n");
                                    break;
                                }
                                else
                                    break;
                            }
                        }
                    }
                }
            }
            Console.Write("Total count =  " + totalCount);
        }

        //Read the strings from File and save in Generic List
        static List<string> ReadfromFileToArray()
        {
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\temp\wordlist.txt");
            List<string> list = new List<string>();
            while ((line = file.ReadLine()) != null)
            {
                if (line.ToString().Trim() != String.Empty)
                {
                    list.Add(line);
                }
            }
            return list;
        }

        //Sort the strings in ascending order of length
        static List<string> Sort(List<string> allwords)
        {
            List<string> list = new List<string>();
            foreach (string s in SortByLength(allwords))
            {
                list.Add(s);
            }
            return list;
        }

        //Sort the strings in ascending order of length
        static IEnumerable<string> SortByLength(IEnumerable<string> e)
        {
            // Use LINQ to sort the array received and return a copy.
            var sorted = from s in e
                         orderby s.Length ascending
                         select s;
            return sorted;
        }
    }
}
