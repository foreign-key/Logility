using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace Logility
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Count() > 0)
            {
                LoadData(args[0], args[1]);
                WriteLine($"Results have been generated at path {args[1]}.");
                Read();
            }
            else
            {
                WriteLine("File paths have not been provided.");
            }
        }

        static async void LoadData(string wordsPath, string resultsPath)
        {
            var listWords = await ReadAllLinesAsync(wordsPath);

            var dictWords = new Dictionary<string, int>();

            foreach(var line in listWords)
            {
                var words = line.Trim().Split(' ');

                foreach(var word in words)
                {
                    if (!dictWords.ContainsKey(word))
                    {
                        dictWords.Add(word, 1);
                    }
                    else
                    {
                        dictWords[word]++;
                    }
                }
            }

            var sortedDictByValue = from entry in dictWords orderby entry.Value descending select entry;
            var sortedDictionary = sortedDictByValue.ThenByDescending(x => x.Key);

            string newValue = string.Join("\n", sortedDictionary.Select(x => x.Key + " " + x.Value).ToArray());

            await WriteFileAsync(resultsPath, newValue);
        }

        static async Task<List<string>> ReadAllLinesAsync(string filePath)
        {
            var lines = new List<string>();

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = await sr.ReadLineAsync()) != null)
                    {
                        lines.Add(line);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }

            return lines;
        }

        static async Task WriteFileAsync(string filePath, string content)
        {
            try
            {
                using (StreamWriter outputFile = new StreamWriter(filePath))
                {
                    await outputFile.WriteAsync(content);
                }
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}