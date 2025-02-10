using System;
using System.Collections.Generic;
using System.Linq;

namespace TextProcessor
{
    public static class TextStats
    {
        public static (int lines, int words, int charsWithSpaces, int charsWithoutSpaces, Dictionary<string, int> frequentWords) AnalyzeText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return (0, 0, 0, 0, new Dictionary<string, int>());

            string[] lines = text.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            string[] words = text.Split(new[] { ' ', '\n', '\r', '\t', ',', '.', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            int charsWithSpaces = text.Length;
            int charsWithoutSpaces = text.Replace(" ", "").Length;

            // Compter la fréquence des mots
            var wordFrequencies = words
                .Where(word => word.Length > 2) // Exclure les petits mots
                .GroupBy(word => word.ToLower())
                .OrderByDescending(g => g.Count())
                .Take(5) // Prendre les 5 mots les plus fréquents
                .ToDictionary(g => g.Key, g => g.Count());

            return (lines.Length, words.Length, charsWithSpaces, charsWithoutSpaces, wordFrequencies);
        }
    }
}
