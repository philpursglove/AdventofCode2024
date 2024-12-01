var input = File.ReadAllLines("InputFile.txt");

List<int> list1 = new List<int>();
List<int> list2 = new List<int>();

foreach (var line in input)
{
    var lineSplit = line.Split("   ");
    list1.Add(int.Parse(lineSplit[0]));
    list2.Add(int.Parse(lineSplit[1]));
}

var listArray1 = list1.Order().ToArray();
var listArray2 = list2.Order().ToArray();

long totalDistance = 0;

for (int i = 0; i < listArray1.GetUpperBound(0)+1; i++)
{
    var distance = listArray1[i] - listArray2[i];
    if (distance < 0) distance = int.Abs(distance);
    totalDistance += distance;
}

Console.WriteLine(totalDistance);
Console.ReadLine();

long totalSimilarity = 0;

foreach (int number in list1)
{
    var count = list2.Count(n => n == number);
    totalSimilarity += (number * count);
}

Console.WriteLine(totalSimilarity);
Console.ReadLine();
