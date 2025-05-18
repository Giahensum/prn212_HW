
// A utility to analyze text files and provide statistics
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FileAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("File Analyzer - .NET Core");
            Console.WriteLine("This tool analyzes text files and provides statistics.");

            if (args.Length == 0)
            {
                Console.WriteLine("Please provide a file path as a command-line argument.");
                Console.WriteLine("Example: dotnet run myfile.txt");
                return;
            }

            string filePath = args[0];

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Error: File '{filePath}' does not exist.");
                return;
            }

            try
            {
                Console.WriteLine($"Analyzing file: {filePath}");

                // Read the file content
                string content = File.ReadAllText(filePath);

                // TODO: Implement analysis functionality
                // 1. Count words
                int lineCount = File.ReadAllLines(filePath).Length;
                Console.WriteLine($"Number of lines: {lineCount}");


                string[] words = Regex.Split(content.ToLower(), @"\W+").Where(w => w.Length > 0).ToArray();
                int wordCount = words.Length;
                Console.WriteLine($"Number of words: {wordCount}");
                // 2. Count characters (with and without whitespace)


                int charCountWithSpaces = content.Length;
                int charCountWithoutSpaces = content.Count(c => !char.IsWhiteSpace(c));
                Console.WriteLine($"Characters (with spaces): {charCountWithSpaces}");
                Console.WriteLine($"Characters (without spaces): {charCountWithoutSpaces}");
                // 3. Count sentences


                int sentenceCount = Regex.Matches(content, @"[\.!?]").Count;
                Console.WriteLine($"Number of sentences: {sentenceCount}");
                // 4. Identify most common words


                var wordGroups = words.GroupBy(w => w)
                                     .OrderByDescending(g => g.Count())
                                     .Take(5); // top 5
                Console.WriteLine("Most common words:");
                foreach (var group in wordGroups)
                {
                    Console.WriteLine($"  {group.Key} - {group.Count()} times");
                }
                // 5. Average word length


                double avgWordLength = wordCount > 0 ? words.Average(w => w.Length) : 0;
                Console.WriteLine($"Average word length: {avgWordLength:F2}");

                // Example implementation for counting lines:
                 lineCount = File.ReadAllLines(filePath).Length;
                Console.WriteLine($"Number of lines: {lineCount}");

                // TODO: Additional analysis to be implemented
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during file analysis: {ex.Message}");
            }
        }
    }
}
