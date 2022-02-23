using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RepeatedWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = "C:\\Users\\Michal\\source\\repos\\wiktomi\\RepeatedWords\\RepeatedWords\\test.txt";

            string allWords = File.ReadAllText(filePath, Encoding.UTF8).ToLower();

            string[] wordsArray = allWords.Split(' ',',', '.', '-', '!');

            List<WordCounter> wordCounters = new List<WordCounter>();

            foreach (string w in wordsArray)
            {
               WordCounter foundWord =  wordCounters.Find(x => x.Word == w);

                if(foundWord == null)
                {
                    wordCounters.Add(new WordCounter(w, 1));
                }
                else
                {
                    foundWord.Frequency++;
                }
            }

            foreach (var item in wordCounters)
            {
                Console.WriteLine($"Word: {item.Word} Frequency: {item.Frequency}");
            }

        }
    }
    class WordCounter
    {
        public WordCounter(string word, int frequency)
        {
            Word = word;
            Frequency = frequency;
        }

        public string Word { get; set; }
        public int Frequency { get; set; }

    }
}
