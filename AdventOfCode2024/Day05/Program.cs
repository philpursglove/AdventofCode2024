var input = File.ReadAllLines("InputFile.txt");

List<string> rulesLines = new List<string>();
List<string> updatesLines = new List<string>();

bool change = false;

foreach (var line in input)
{
    if (line == string.Empty)
    {
        change = true;
        continue;
    }

    if (change)
    {
        updatesLines.Add(line);
    }
    else
    {
        rulesLines.Add(line);
    }
}

List<Tuple<int, int>> rules = new List<Tuple<int, int>>();
List<List<int>> updates = new List<List<int>>();

foreach (var rulesLine in rulesLines)
{
    var ruleBits = rulesLine.Split("|");
    Tuple<int, int> rule = new Tuple<int, int>(int.Parse(ruleBits[0]), int.Parse(ruleBits[1]));
    rules.Add(rule);
}

foreach (var updatesLine in updatesLines)
{
    var updateBits = updatesLine.Split(",");
    List<int> update = new List<int>();
    foreach (var updateBit in updateBits)
    {
        update.Add(int.Parse(updateBit));
    }
    updates.Add(update);
}

List<List<int>> validUpdates = new List<List<int>>();

foreach (var update in updates)
{
    bool valid = true;
    foreach (int updateItem in update)
    {
        IEnumerable<Tuple<int, int>> relevantRules = rules.Where(r => r.Item1 == updateItem && update.Contains(r.Item1) && update.Contains(r.Item2));
        var position = update.IndexOf(updateItem);
        foreach (var relevantRule in relevantRules)
        {
            if (update.IndexOf(relevantRule.Item2) < position)
            {
                valid = false;
            }
        }
    }

    if (valid)
    {
        validUpdates.Add(update);
    }
}

var total = 0;

foreach (var validUpdate in validUpdates)
{
    var midItem = validUpdate[((validUpdate.Count + 1) / 2) - 1];
    total += midItem;
}

Console.WriteLine(total);
Console.ReadLine();