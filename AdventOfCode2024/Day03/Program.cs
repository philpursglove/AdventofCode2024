var input = await File.ReadAllTextAsync("InputFile.txt");

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