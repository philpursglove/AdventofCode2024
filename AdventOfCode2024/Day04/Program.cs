using AdventUtilities;

var input = File.ReadAllLines("SampleFile.txt");

string[,] grid = input.ToGrid();

List<Tuple<Coordinate, Coordinate>> foundCoordinates = new List<Tuple<Coordinate, Coordinate>>();

for (int y = 0; y < grid.GetUpperBound(1) + 1; y++)
{
    string row = string.Empty;
    for (int x = 0; x < grid.GetUpperBound(0) + 1; x++)
    {
        row += grid[x, y];
    }

    if (row.Contains("XMAS", StringComparison.CurrentCulture))
    {
        int startPosition = 0;

        while (row.IndexOf("XMAS", startPosition, StringComparison.CurrentCulture) != -1)
        {
            startPosition = row.IndexOf("XMAS", startPosition, StringComparison.CurrentCulture) + 1;
            foundCoordinates.Add(new Tuple<Coordinate, Coordinate>(new Coordinate(startPosition, y),
                new Coordinate(startPosition + 3, y)));

        }
    }
    if (row.Contains("SAMX", StringComparison.CurrentCulture))
    {
        int startPosition = 0;

        while (row.IndexOf("SAMX", startPosition, StringComparison.CurrentCulture) != -1)
        {
            startPosition = row.IndexOf("SAMX", startPosition, StringComparison.CurrentCulture) + 1;
            foundCoordinates.Add(new Tuple<Coordinate, Coordinate>(new Coordinate(startPosition, y),
                new Coordinate(startPosition + 3, y)));

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

    if (col.Contains("XMAS", StringComparison.CurrentCulture))
    {
        int startPosition = 0;

        while (col.IndexOf("XMAS", startPosition, StringComparison.CurrentCulture) != -1)
        {
            startPosition = col.IndexOf("XMAS", startPosition, StringComparison.CurrentCulture) + 1;
            foundCoordinates.Add(new Tuple<Coordinate, Coordinate>(new Coordinate(x, startPosition),
                new Coordinate(x, startPosition + 3)));

        }
    }
    if (col.Contains("SAMX", StringComparison.CurrentCulture))
    {
        int startPosition = 0;

        while (col.IndexOf("SAMX", startPosition, StringComparison.CurrentCulture) != -1)
        {
            startPosition = col.IndexOf("SAMX", startPosition, StringComparison.CurrentCulture) + 1;
            foundCoordinates.Add(new Tuple<Coordinate, Coordinate>(new Coordinate(x, startPosition),
                new Coordinate(x, startPosition + 3)));

        }
    }
}


Console.Write(foundCoordinates.Count);
Console.ReadLine();