namespace AdventUtilities
{
    public static class StringExtensions
    {
        public static bool ContainsDigits(this string input)
        {
            return input.Any(char.IsDigit);
        }

        public static bool ContainsMixedCase(this string input)
        {
            return (input.Any(char.IsLower) && input.Any(char.IsUpper));
        }

        public static bool IsNumeric(this string str)
        {
            return str.All(char.IsNumber);
        }
    }
}
