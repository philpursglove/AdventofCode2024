using AdventUtilities;

var input = File.ReadAllText("InputFile.txt");

List<Stone> stones = new List<Stone>();

foreach (var i in input.ParseInts(" "))
{
    Stone stone = new Stone() { Value = i };
    stones.Add(stone);
}

for (int i = 0; i < 75; i++)
{
    stones = Blink(stones);
}

Console.WriteLine($"Number of stones {stones.Count}");
Console.ReadLine();



List<Stone> Blink(List<Stone> input)
{
    List<Stone> output = new List<Stone>();
    foreach (var stone in input)
    {
        if (stone.Value == 0)
        {
            output.Add(new Stone() { Value = 1 });
            continue;
        }

        if (stone.Value.ToString().Length % 2 == 0)
        {
            string stringValue = stone.Value.ToString();
            var stringLength = stringValue.Length;

            var val1 = long.Parse(stringValue.Substring(0, (stringLength / 2)));
            var val2 = long.Parse(stringValue.Substring(stringLength / 2));

            output.Add(new Stone() { Value = val1 });
            output.Add(new Stone() { Value = val2 });

            continue;
        }

        output.Add(new Stone() { Value = stone.Value * 2024 });

    }

    return output;
}

class Stone
{
    public long Value { get; set; }
}