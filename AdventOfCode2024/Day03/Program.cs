var input = await File.ReadAllTextAsync("SampleFile.txt");

var splitMul = input.Split("mul");
var parenthesised =  splitMul.Where(s => s.StartsWith("(") && s.Contains(")"));
var commas = parenthesised.Where(p => p.Contains(","));

var total = 0;

foreach (var potential in commas)
{
    var split = potential.Split(",");
    var int1 = 0;
    if (!int.TryParse(split[0].Replace("(", ""), out int1))
    {
        Console.WriteLine(split[0].Replace("(", ""));
        continue;
    }

    var int2 = 0;
    if (!split[1].Contains(")"))
    {
        continue;
    }
    if (!int.TryParse(split[1].Substring(0, split[1].IndexOf(")")), out int2))
    {
        Console.WriteLine(split[1].Substring(0, split[1].IndexOf(")")));
        continue;
    }
    total += int1 * int2;
}

Console.WriteLine(total);
Console.ReadLine();

input = File.ReadAllText("InputFile.txt");
var donts = input.Split("don't()");

List<string> dos = new List<string>();

dos.Add(donts[0]);

foreach (var dont in donts)
{
    if (dont.IndexOf("do()") == -1)
    {
        continue;
    }
    else
    {
        dos.Add(dont[dont.IndexOf("do()")..]);
    }
}

var total2 = 0;

foreach (var @do in dos)
{
    var splitMul2 = @do.Split("mul");
    var parenthesised2 = splitMul2.Where(s => s.StartsWith("(") && s.Contains(")"));
    var commas2 = parenthesised2.Where(p => p.Contains(","));

    foreach (var potential in commas2)
    {
        var split = potential.Split(",");
        var int1 = 0;
        if (!int.TryParse(split[0].Replace("(", ""), out int1))
        {
            Console.WriteLine(split[0].Replace("(", ""));
            continue;
        }

        var int2 = 0;
        if (!split[1].Contains(")"))
        {
            continue;
        }

        if (!int.TryParse(split[1].Substring(0, split[1].IndexOf(")")), out int2))
        {
            Console.WriteLine(split[1].Substring(0, split[1].IndexOf(")")));
            continue;
        }

        total2 += int1 * int2;

    }
}

Console.WriteLine(total2);
Console.ReadLine();
