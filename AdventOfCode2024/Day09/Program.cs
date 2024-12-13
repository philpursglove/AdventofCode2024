
using System.Text;

var input = File.ReadAllText("InputFile.txt");

List<DiskEntry> disk = new List<DiskEntry>();

bool isFile = true;
int fileId = 0;
foreach (var entry in input)
{
    DiskEntry diskEntry = new DiskEntry();

    if (isFile)
    {
        diskEntry.FileId = fileId;
        fileId++;
    }
    else
    {
        diskEntry.FreeSpace = true;
    }

    diskEntry.Length = int.Parse(entry.ToString());

    isFile = !isFile;

    disk.Add(diskEntry);
}

//displayDisk(disk);

string displayDisk(List<DiskEntry> disk)
{
    StringBuilder builder = new StringBuilder();
    foreach (var diskEntry in disk)
    {
        if (diskEntry.FreeSpace)
        {
            builder.Append(new string('.', diskEntry.Length));
        }
        else
        {
            builder.Append(new string(char.Parse(diskEntry.FileId.ToString()), diskEntry.Length));
        }
    }

    return builder.ToString();
}

var compressedDisk = compressDisk(disk);
//Console.WriteLine(displayDisk(compressedDisk));

Console.WriteLine($"Checksum {diskChecksumFromDisk(compressedDisk)}");

Console.ReadLine();



List<DiskEntry> compressDisk(List<DiskEntry> disk)
{

    do
    {
        DiskEntry file = disk.Last(d => d.FreeSpace == false);
        DiskEntry freeSpace = disk.First(d => d.FreeSpace && d.Length > 0);

        if (freeSpace.Length < file.Length)
        {
            freeSpace.FreeSpace = false;
            freeSpace.FileId = file.FileId;
            file.Length -= freeSpace.Length;
        }
        else
        {
            int remainingSpace = freeSpace.Length - file.Length;
            if (remainingSpace > 0)
            {
                DiskEntry newSpace = new DiskEntry() { FreeSpace = true, Length = remainingSpace };
                disk.Insert(disk.IndexOf(freeSpace) + 1, newSpace);
            }

            freeSpace.FreeSpace = false;
            freeSpace.FileId = file.FileId;
            freeSpace.Length = file.Length;
            disk.Remove(file);
        }
    } while (disk.Any(d => d.FreeSpace && d.Length > 0));

    return disk;
}

long diskChecksum(string disk)
{
    long total = 0;

    for (int i = 0; i < disk.Length; i++)
    {
        total += (i * int.Parse(disk[i].ToString()));
    }

    return total;
}

long diskChecksumFromDisk(List<DiskEntry> disk)
{
    long total = 0;
    long position = 0;
    for (int i = 0; i < disk.Count; i++)
    {
        for (int j = 0; j < disk[i].Length; j++)
        {
            total += position * disk[i].FileId;
            position++;
        }
    }

    return total;
}

class DiskEntry
{
    public int FileId { get; set; }
    public bool FreeSpace { get; set; }
    public int Length { get; set; }
}