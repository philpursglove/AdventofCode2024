namespace AdventUtilities
{
    public static class StringExtensions
    {
        public static string[,] ToGrid(this string[] strings)
        {
            string[,] grid = new string[strings.First().Length, strings.Length];

            for (int y = 0; y < strings.Length; y++)
            {
                for (int x = 0; x < strings[y].Length; x++)
                {
                    grid[x, y] = strings[y].Substring(x, 1);
                }
            }

            return grid;
        }

        public static List<Tuple<Coordinate, Coordinate>> Search(this string[,] grid, string searchText)
        {
            string reversedSearchText = string.Join("", searchText.Reverse());

            List<Tuple<Coordinate, Coordinate>> searchResults = new List<Tuple<Coordinate, Coordinate>>();

            for (int y = 0; y < grid.GetUpperBound(1) + 1; y++)
            {
                string row = string.Empty;
                for (int x = 0; x < grid.GetUpperBound(0) + 1; x++)
                {
                    row += grid[x, y];
                }

                if (row.Contains(searchText, StringComparison.CurrentCulture))
                {
                    int startPosition = 0;

                    while (row.IndexOf(searchText, startPosition, StringComparison.CurrentCulture) != -1)
                    {
                        startPosition = row.IndexOf(searchText, startPosition, StringComparison.CurrentCulture) + 1;
                        searchResults.Add(new Tuple<Coordinate, Coordinate>(new Coordinate(startPosition, y),
                            new Coordinate(startPosition + (searchText.Length - 1), y)));

                    }
                }
                if (row.Contains(reversedSearchText, StringComparison.CurrentCulture))
                {
                    int startPosition = 0;

                    while (row.IndexOf(reversedSearchText, startPosition, StringComparison.CurrentCulture) != -1)
                    {
                        startPosition = row.IndexOf(reversedSearchText, startPosition, StringComparison.CurrentCulture) + 1;
                        searchResults.Add(new Tuple<Coordinate, Coordinate>(new Coordinate(startPosition, y),
                            new Coordinate(startPosition + (searchText.Length - 1), y)));

                    }
                }
            }

            for (int x = 0; x < grid.GetUpperBound(0) + 1; x++)
            {
                string col = string.Empty;
                for (int y = 0; y < grid.GetUpperBound(1) + 1; y++)
                {
                    col += grid[x, y];
                }

                if (col.Contains(searchText, StringComparison.CurrentCulture))
                {
                    int startPosition = 0;

                    while (col.IndexOf(searchText, startPosition, StringComparison.CurrentCulture) != -1)
                    {
                        startPosition = col.IndexOf(searchText, startPosition, StringComparison.CurrentCulture) + 1;
                        searchResults.Add(new Tuple<Coordinate, Coordinate>(new Coordinate(x, startPosition),
                            new Coordinate(x, startPosition + (searchText.Length - 1))));

                    }
                }
                if (col.Contains(reversedSearchText, StringComparison.CurrentCulture))
                {
                    int startPosition = 0;

                    while (col.IndexOf(reversedSearchText, startPosition, StringComparison.CurrentCulture) != -1)
                    {
                        startPosition = col.IndexOf(reversedSearchText, startPosition, StringComparison.CurrentCulture) + 1;
                        searchResults.Add(new Tuple<Coordinate, Coordinate>(new Coordinate(x, startPosition),
                            new Coordinate(x, startPosition + (searchText.Length - 1))));
                    }
                }
            }

            for (int y = 0; y < grid.GetUpperBound(1) - (searchText.Length - 2); y++)
            {
                for (int x = 0; x < grid.GetUpperBound(0) - (searchText.Length - 2); x++)
                {
                    string diagonal = string.Empty;
                    for (int position = 0; position < searchText.Length; position++)
                    {
                        diagonal += grid[x + position, y + position];
                    }
                    if (diagonal == searchText || diagonal == reversedSearchText)
                    {
                        searchResults.Add(new Tuple<Coordinate, Coordinate>(new Coordinate(x, y), new Coordinate(x + searchText.Length - 1, y + searchText.Length - 1)));
                    }
                }
            }

            for (int y = 0; y < grid.GetUpperBound(1) - (searchText.Length - 2); y++)
            {
                for (int x = grid.GetUpperBound(0); x > (searchText.Length - 2); x--)
                {
                    string diagonal = string.Empty;
                    for (int position = 0; position < searchText.Length; position++)
                    {
                        diagonal += grid[x - position, y + position];
                    }
                    if (diagonal == searchText || diagonal == reversedSearchText)
                    {
                        searchResults.Add(new Tuple<Coordinate, Coordinate>(new Coordinate(x, y), new Coordinate(x - (searchText.Length - 1), y + searchText.Length - 1)));
                    }
                }

            }

            return searchResults;
        }

        public static int[,] ToIntGrid(this string[] strings)
        {
            int[,] grid = new int[strings.First().Length, strings.Length];

            for (int i = 0; i < strings.Length; i++)
            {
                for (int j = 0; j < strings[i].Length; j++)
                {
                    grid[i, j] = int.Parse(strings[i].Substring(j, 1));
                }
            }

            return grid;
        }

        public static char[,] ToCharGrid(this string[] strings)
        {
            int width = strings.First().Length, height = strings.Length;
            char[,] grid = new char[width, height];

            for (int y = 0; y < (height); y++)
            {
                for (int x = 0; x < width; x++)
                {
                    grid[x, y] = (strings[y].Substring(x, 1)).ToCharArray()[0];
                }
            }

            return grid;
        }

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

        public static Coordinate Find(this string[,] grid, string searchText)
        {
            for (int y = 0; y < grid.GetUpperBound(1) + 1; y++)
            {
                for (int x = 0; x < grid.GetUpperBound(0) + 1; x++)
                {
                    if (grid[x, y] == searchText)
                    {
                        return new Coordinate(x, y);
                    }
                }
            }
            return null;
        }
    }

    public enum Direction
    {
        Up = 0,
        Right = 1,
        Down = 2,
        Left = 3,
        North = 0,
        East = 1,
        South = 2,
        West = 3
    }
}
