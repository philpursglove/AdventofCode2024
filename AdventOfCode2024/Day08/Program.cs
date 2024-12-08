using AdventUtilities;

var input = File.ReadAllLines("InputFile.txt");

var grid = input.ToGrid();

var frequencyList = grid.FindDistinctEntries(new List<string>(){".", "#"});
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