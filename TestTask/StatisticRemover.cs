namespace TestTask;

public static class LetterStatsExtension
{
    public static void TrimConsonant(this IList<LetterStats> letterStats)
    {
        TrimByPredicate(letterStats, IsConsonant);
    }

    public static void TrimVowels(this IList<LetterStats> letterStats)
    {
        TrimByPredicate(letterStats, IsVowel);
    }

    private static void TrimByPredicate(IList<LetterStats> letterStats, Func<string, bool> predicate)
    {
        for(int i = 0; i < letterStats.Count; i++)
        {
            if(!predicate(letterStats[i].Letter))
            {
                continue;
            }
            letterStats.Remove(letterStats[i]);
            i--;
        }
    }

    private static bool IsConsonant(string letter)
    {
        return string.IsNullOrEmpty(letter) || ConsonantVowelClassificator.IsConsonant(letter[0]);
    }

    private static bool IsVowel(string letter)
    {
        return string.IsNullOrEmpty(letter) || ConsonantVowelClassificator.IsVowel(letter[0]);
    }
}