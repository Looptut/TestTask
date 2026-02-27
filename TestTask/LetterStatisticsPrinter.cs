namespace TestTask;

public static class LetterStatisticsPrinter
{
    public static void PrintStatisticSorted(IList<LetterStats> letters)
    {
        var sorted = letters.OrderBy(x => char.ToLowerInvariant(x.Letter[0]));
        foreach (var letter in sorted)
        {
            Console.WriteLine($"{letter.Letter} : {letter.Count}");
        }
        
        Console.WriteLine($"ИТОГО : {letters.Count()}");
    }
}