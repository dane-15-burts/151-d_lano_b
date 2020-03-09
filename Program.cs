using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GroupDocs.Parser;

namespace TechnicalAssessment
{
    class Program
    {
        static void Main(string[] args)
        {
            WordOccurence(); 
        }

        public static void WordOccurence()
        {

            string filepath = @"C:\Users\Dane\source\repos\TechnicalAssessment\TechnicalAssessment\data\2600-0.txt";

            using (Parser parser = new Parser(filepath))
            {
                // Extract a text into the reader
                using (TextReader reader = parser.GetText())
                {
                    Dictionary<string, int> stats = new Dictionary<string, int>();
                    string text = reader.ReadToEnd();
                    char[] chars = { ' ', '.', ',', ';', ':', '?', '\n', '\r' };
                    // split words
                    string[] words = text.Split(chars);
                    int maxWordLength = 6;// to count words having more than 6 characters
                                          // iterate over the word collection to count occurrences
                    foreach (string word in words)
                    {
                        string w = word.Trim().ToLower();
                        if (w.Length > maxWordLength)
                        {
                            if (!stats.ContainsKey(w))
                            {
                                // add new word to collection
                                stats.Add(w, 1);
                            }
                            else
                            {
                                // update word occurrence count
                                stats[w] += 1;
                            }
                        }
                    }
                    // order the collection by word count
                    var orderedStats = stats.OrderByDescending(x => x.Value);
                    // print total word count
                    Console.WriteLine("Total word count: {0}", stats.Count);
                    // print occurrence of each word
                    foreach (var pair in orderedStats)
                    {
                        Console.WriteLine("Total occurrences of {0} : {1}", pair.Key, pair.Value);
                    }

                    RunTime();

                    Console.ReadKey();
                }
            }
        }

        public static void RunTime()
        {
           
            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();

            for (int i = 0; i < 1000; i++)
            {
                Console.Write(" ");
            }

            watch.Stop();

            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

            Console.ReadKey();
        }
    }
}
