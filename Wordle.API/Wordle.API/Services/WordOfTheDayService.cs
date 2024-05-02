
using System.Reflection;

namespace Wordle.Api.Services;

public class WordOfTheDayService
{
    private static readonly string directory = Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)!;
    public static readonly string filePath = Path.Combine(directory, "..", "..", "..", "..", "..", "wordle-web", "scripts", "wordList.ts");
    private List<string> words = LoadWordList(filePath);

    public static List<string> LoadWordList(string filePath)
    {
        List<string> words = ["myconstantword"];

        using (StreamReader reader = new StreamReader(filePath))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                // Ignore comment lines and empty lines
                if (!line.StartsWith("//") && !string.IsNullOrWhiteSpace(line) && !line.StartsWith("export"))
                {
                    string word = string.Concat(line.Where(char.IsLetter)).Trim();
                    words.Add(word);
                }
            }
        }

        return words;
    }

    public string GetRandomWord()
    {
        Random random = new Random();
        int index = random.Next(words.Count);
        return words[index];
    }
}
