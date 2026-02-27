namespace TestTask;

public static class ConsonantVowelClassificator
{
    private static readonly HashSet<char> Vowels = new HashSet<char>("аеёиоуыьъэюяАЕЁИОУЫЬЪЭЮЯaeiouAEIOU");
    private static readonly HashSet<char> NonLetterChars = new HashSet<char>("ьъЬЪ");

    public static bool IsVowel(char c)
    {
        if (!char.IsLetter(c))
            return false;
        if (NonLetterChars.Contains(c))
            return false;
        return Vowels.Contains(c);
    }

    public static bool IsConsonant(char c)
    {
        return !IsVowel(c);
    }
}