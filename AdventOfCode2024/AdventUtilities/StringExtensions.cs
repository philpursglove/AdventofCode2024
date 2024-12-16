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

        public static List<int> ParseInts(this string input, string separator)
        {
            List<int> ints = new List<int>();

            string[] values = input.Trim().Split(separator);
            foreach (var value in values)
            {
                ints.Add(int.Parse(value));
            }

            return ints;
        }

        public static List<long> ParseLongs(this string input, string separator)
        {
            List<long> longs = new List<long>();

            string[] values = input.Trim().Split(separator);
            foreach (var value in values)
            {
                longs.Add(int.Parse(value));
            }

            return longs;
        }

    }
}
