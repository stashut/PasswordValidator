using System;
using System.Text.RegularExpressions;

namespace PasswordValidator
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            string filePath = "D:\\TestTask\\PasswordValidator\\passwords.txt";
            int validPasswordCount = 0;

            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                if (IsValidPassword(line, out int charCount))
                {
                    validPasswordCount++;
                    Console.WriteLine($"Valid Password: {line}, Char Count: {charCount}");
                }
            }

            Console.WriteLine($"Number of valid passwords: {validPasswordCount}"); 
        }
        
        static bool IsValidPassword(string line, out int charCount)
        {
            charCount = 0;

            string[] parts = line.Split(':');
            if (parts.Length != 2)
            {
                return false;
            }

            string requirementPart = parts[0].Trim();
            string passwordPart = parts[1].Trim();

            if (TryParseRequirement(requirementPart, out char requiredChar, out int minCount, out int maxCount))
            {
                charCount = CountOccurrences(passwordPart, requiredChar);
                return charCount >= minCount && charCount <= maxCount;
            }

            return false;
        }

        static bool TryParseRequirement(string requirementPart, out char requiredChar, out int minCount, out int maxCount)
        {
            requiredChar = '\0';
            minCount = 0;
            maxCount = 0;

            Match match = Regex.Match(requirementPart, @"(\w)\s+(\d+)-(\d+)");
            if (!match.Success)
            {
                return false;
            }

            requiredChar = match.Groups[1].Value[0];
            minCount = int.Parse(match.Groups[2].Value);
            maxCount = int.Parse(match.Groups[3].Value);

            return true;
        }

        static int CountOccurrences(string input, char target)
        {
            int count = 0;
            foreach (char c in input)
            {
                if (c == target)
                {
                    count++;
                }
            }
            return count;
        }
        
    }
}