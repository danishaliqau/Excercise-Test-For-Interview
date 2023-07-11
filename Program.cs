using System;
using System.Linq;
using System.Text.RegularExpressions;

public class SimpleReverseLogicWords
{
    public static string InvertPhrase(string phrase)
    {
        // Check Null
        if (string.IsNullOrEmpty(phrase))
            return "";

        // Remove leading/trailing spaces
        phrase = phrase.Trim();

        // Split the phrase into words and punctuation marks
        var matches = Regex.Matches(phrase, @"\b\w+(-\w+)?\b|\p{P}");
        var wordsAndPunctuation = matches.Cast<Match>().Select(match => match.Value).ToList();

        // No need to reverse
        if (wordsAndPunctuation.Count == 1)
            return phrase;

        // Now Reverse
        wordsAndPunctuation.Reverse();

        var result = OutputFormat(wordsAndPunctuation);
        return result;
    }

    private static string OutputFormat(System.Collections.Generic.List<string> words)
    {

        return string.Join("", words.Select((item, index) =>
        {
            if (index > 0 && ShouldHaveSpace(item))
            {
                return item;
            }
            else
            {
                return " " + item;
            }
        }));
    }

    private static bool ShouldHaveSpace(string current)
    {
        return !(string.IsNullOrWhiteSpace(current)) &&
               !(char.IsLetterOrDigit(current[0]));
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        string input = "Good afternoon";
        string output = SimpleReverseLogicWords.InvertPhrase(input);
        Console.WriteLine($"{input} => {output}");

        input = "Hello, how are you?";
        output = SimpleReverseLogicWords.InvertPhrase(input);
        Console.WriteLine($"{input} => {output}");

        input = "Are you twenty-one years old?";
        output = SimpleReverseLogicWords.InvertPhrase(input);
        Console.WriteLine($"{input} => {output}");
        Console.ReadKey();
    }
}
