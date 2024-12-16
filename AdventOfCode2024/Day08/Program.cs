using AdventUtilities;

var input = File.ReadAllLines("SampleFile3.txt");

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

antinodes = new List<Coordinate>();

foreach (var frequency in frequencyList)
{
    var entries = grid.FindEntries(frequency);

    foreach (var entry in entries)
    {
        List<Coordinate> otherEntries = entries.Except(new List<Coordinate>() { entry }).ToList();

        foreach (var otherEntry in otherEntries)
        {
            Coordinate potential = new Coordinate(0,0);
            if (entry.X < otherEntry.X)
            {
                if (entry.Y < otherEntry.Y)
                {
                    var diffX = Math.Abs(entry.X - otherEntry.X);
                    var diffY = Math.Abs(entry.Y - otherEntry.Y);

                    var currentX = entry.X;
                    var currentY = entry.Y;

                    do
                    {
                        potential.X = currentX - diffX;
                        potential.Y = currentY - diffY;

                        if (potential.X >= 0 && potential.Y >= 0)
                        {
                            antinodes.Add(potential);
                            currentX = potential.X;
                            currentY = potential.Y;
                        }
                    } while (potential.X >= 0 && potential.Y >= 0);

                }
                else
                {
                    var diffX = Math.Abs(entry.X - otherEntry.X);
                    var diffY = Math.Abs(entry.Y - otherEntry.Y);

                    var currentX = entry.X;
                    var currentY = entry.Y;

                    do
                    {
                        potential.X = currentX - diffX;
                        potential.Y = currentY + diffY;

                        if (potential.X >= 0 && potential.Y <= grid.GetUpperBound(1))
                        {
                            antinodes.Add(potential);
                            currentX = potential.X;
                            currentY = potential.Y;
                        }
                    } while (potential.X >= 0 && potential.Y <= grid.GetUpperBound(1));
                }
            }
            else
            {
                if (entry.Y < otherEntry.Y)
                {
                    var diffX = Math.Abs(entry.X - otherEntry.X);
                    var diffY = Math.Abs(entry.Y - otherEntry.Y);

                    var currentX = entry.X;
                    var currentY = entry.Y;

                    do
                    {
                        potential.X = currentX + diffX;
                        potential.Y = currentY - diffY;

                        if (potential.X <= grid.GetUpperBound(0) && potential.Y >= 0)
                        {
                            antinodes.Add(potential);
                            currentX = potential.X;
                            currentY = potential.Y;
                        }
                    } while (potential.X <= grid.GetUpperBound(0) && potential.Y >= 0);

                }
                else
                {
                    var diffX = Math.Abs(entry.X - otherEntry.X);
                    var diffY = Math.Abs(entry.Y - otherEntry.Y);

                    var currentX = entry.X;
                    var currentY = entry.Y;

                    do
                    {
                        potential.X = currentX + diffX;
                        potential.Y = currentY + diffY;

                        if (potential.X <= grid.GetUpperBound(0) && potential.Y <= grid.GetUpperBound(1))
                        {
                            antinodes.Add(potential);
                            currentX = potential.X;
                            currentY = potential.Y;
                        }
                    } while (potential.X <= grid.GetUpperBound(0) && potential.Y <= grid.GetUpperBound(1));

                }

            }
        }
    }
    antinodes.AddRange(entries);
}

Console.WriteLine(antinodes.Count());
//Console.WriteLine(antinodes.Distinct(new CoordinateComparer()).Count());
Console.ReadLine();

//public class CoordinateComparer : IEqualityComparer<Coordinate>
//{
//    public bool Equals(Coordinate? x, Coordinate? y)
//    {
//        if (ReferenceEquals(x, y)) return true;
//        if (x is null) return false;
//        if (y is null) return false;
//        if (x.GetType() != y.GetType()) return false;
//        return x.X == y.X && x.Y == y.Y;
//    }

//    public int GetHashCode(Coordinate obj)
//    {
//        return HashCode.Combine(obj.X, obj.Y);
//    }
//}