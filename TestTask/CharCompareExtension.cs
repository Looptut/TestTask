namespace TestTask;

public static class CharInvariantCompareExtension
{ 
        public static bool EqualsSensitiveCase(this char c1, char c2, bool ignoreCase = false)
        {
                if (ignoreCase)
                        return char.ToLowerInvariant(c1) == char.ToLowerInvariant(c2);
                
                return c1 == c2;
        }
}