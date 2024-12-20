using AdventUtilities;

var input = File.ReadAllLines("SampleFile3.txt");

var grid = input.ToGrid();

var frequencyList = grid.FindDistinctEntries(new List<string>() { ".", "#" });
var antinodes = new List<Coordinate>();

foreach (var frequency in frequencyList)
{
    var entries = grid.FindEntries(frequency);

    foreach (var entry in entries)
    {
        List<Coordinate> otherEntries = entries.Except(new List<Coordinate>() { entry }).ToList();

        foreach (var otherEntry in otherEntries)
        {
            if (entry.X < otherEntry.X)
            {
                if (entry.Y < otherEntry.Y)
                {
                    var diffX = Math.Abs(entry.X - otherEntry.X);
                    var diffY = Math.Abs(entry.Y - otherEntry.Y);

                    Coordinate potential = new Coordinate(entry.X - diffX, entry.Y - diffY);
                    if (Math.Abs(potential.X - otherEntry.X) == diffX * 2 &&
                        Math.Abs(potential.Y - otherEntry.Y) == diffY * 2)
                    {
                        if (potential.X >= 0 && potential.X <= grid.GetUpperBound(0) && potential.Y >= 0 &&
                            potential.Y <= grid.GetUpperBound(1))
                        {
                            if (!antinodes.Any(a => a.X == potential.X && a.Y == potential.Y))
                            {
                                antinodes.Add(potential);
                            }
                        }
                    }
                }
                else
                {
                    var diffX = Math.Abs(entry.X - otherEntry.X);
                    var diffY = Math.Abs(entry.Y - otherEntry.Y);

                    Coordinate potential = new Coordinate(entry.X - diffX, entry.Y + diffY);
                    if (Math.Abs(potential.X - otherEntry.X) == diffX * 2 &&
                        Math.Abs(potential.Y - otherEntry.Y) == diffY * 2)
                    {
                        if (potential.X >= 0 && potential.X <= grid.GetUpperBound(0) && potential.Y >= 0 &&
                            potential.Y <= grid.GetUpperBound(1))
                        {
                            if (!antinodes.Any(a => a.X == potential.X && a.Y == potential.Y))
                            {
                                antinodes.Add(potential);
                            }
                        }
                    }
                }
            }
            else
            {
                if (entry.Y < otherEntry.Y)
                {
                    var diffX = Math.Abs(entry.X - otherEntry.X);
                    var diffY = Math.Abs(entry.Y - otherEntry.Y);

                    Coordinate potential = new Coordinate(entry.X + diffX, entry.Y - diffY);
                    if (Math.Abs(potential.X - otherEntry.X) == diffX * 2 &&
                        Math.Abs(potential.Y - otherEntry.Y) == diffY * 2)
                    {
                        if (potential.X >= 0 && potential.X <= grid.GetUpperBound(0) && potential.Y >= 0 &&
                            potential.Y <= grid.GetUpperBound(1))
                        {
                            if (!antinodes.Any(a => a.X == potential.X && a.Y == potential.Y))
                            {
                                antinodes.Add(potential);
                            }
                        }
                    }
                }
                else
                {
                    var diffX = Math.Abs(entry.X - otherEntry.X);
                    var diffY = Math.Abs(entry.Y - otherEntry.Y);

                    Coordinate potential = new Coordinate(entry.X + diffX, entry.Y + diffY);
                    if (Math.Abs(potential.X - otherEntry.X) == diffX * 2 &&
                        Math.Abs(potential.Y - otherEntry.Y) == diffY * 2)
                    {
                        if (potential.X >= 0 && potential.X <= grid.GetUpperBound(0) && potential.Y >= 0 &&
                            potential.Y <= grid.GetUpperBound(1))
                        {
                            if (!antinodes.Any(a => a.X == potential.X && a.Y == potential.Y))
                            {
                                antinodes.Add(potential);
                            }
                        }
                    }
                }

            }
        }
    }

}

Console.WriteLine(antinodes.Count);
Console.ReadLine();

antinodes = new List<Coordinate>();

foreach (var frequency in frequencyList)
{
    var entries = grid.FindEntries(frequency);

    foreach (var entry in entries)
    {
        List<Coordinate> otherEntries = entries.Except(new List<Coordinate>() { entry }).ToList();

        var gridWidth = grid.GetUpperBound(0);
        var gridHeight = grid.GetUpperBound(1);

        foreach (var otherEntry in otherEntries)
        {
            var diffX = Math.Abs(entry.X - otherEntry.X);
            var diffY = Math.Abs(entry.Y - otherEntry.Y);

            var currentX = entry.X;
            var currentY = entry.Y;

            Coordinate potential = new Coordinate(0, 0);
            if (entry.X < otherEntry.X)
            {
                if (entry.Y < otherEntry.Y)
                {
                    do
                    {
                        potential.X = currentX - diffX;
                        potential.Y = currentY - diffY;

                        if (potential is { X: >= 0, Y: >= 0 })
                        {
                            antinodes.Add(potential);
                            currentX = potential.X;
                            currentY = potential.Y;
                        }
                    } while (potential is { X: >= 0, Y: >= 0 });

                }
                else
                {
                    do
                    {
                        potential.X = currentX - diffX;
                        potential.Y = currentY + diffY;

                        if (potential.X >= 0 && potential.Y <= gridHeight)
                        {
                            antinodes.Add(potential);
                            currentX = potential.X;
                            currentY = potential.Y;
                        }
                    } while (potential.X >= 0 && potential.Y <= gridHeight);
                }
            }
            else
            {
                if (entry.Y < otherEntry.Y)
                {
                    do
                    {
                        potential.X = currentX + diffX;
                        potential.Y = currentY - diffY;

                        if (potential.X <= gridWidth && potential.Y >= 0)
                        {
                            antinodes.Add(potential);
                            currentX = potential.X;
                            currentY = potential.Y;
                        }
                    } while (potential.X <= gridWidth && potential.Y >= 0);

                }
                else
                {
                    do
                    {
                        potential.X = currentX + diffX;
                        potential.Y = currentY + diffY;

                        if (potential.X <= gridWidth && potential.Y <= gridHeight)
                        {
                            antinodes.Add(potential);
                            currentX = potential.X;
                            currentY = potential.Y;
                        }
                    } while (potential.X <= gridWidth && potential.Y <= gridHeight);

                }

            }
        }
    }
    antinodes.AddRange(entries);
}

Console.WriteLine(antinodes.Count());
Console.ReadLine();
