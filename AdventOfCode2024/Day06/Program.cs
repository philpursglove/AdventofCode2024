using AdventUtilities;

var input = File.ReadAllLines("SampleFile.txt");

var grid = input.ToGrid();

var startingPosition = grid.Find("^");

var currentPosition = startingPosition;

var direction = Direction.Up;

List<Coordinate> visited = new List<Coordinate>();

visited.Add(currentPosition);

bool onTheGrid = true;

while (onTheGrid)
{
    var peekNextLocation = "";
    switch (direction)
    {
        case Direction.Up:
            currentPosition = new Coordinate(currentPosition.X, currentPosition.Y - 1);

            if (currentPosition.Y - 1 < 0)
            {
                onTheGrid = false;
            }
            else
            {
                peekNextLocation = grid[currentPosition.X, currentPosition.Y - 1];
            }

            break;
        case Direction.Down:
            currentPosition = new Coordinate(currentPosition.X, currentPosition.Y + 1);

            if (currentPosition.Y + 1 > grid.GetUpperBound(1))
            {
                onTheGrid = false;
            }
            else
            {
                peekNextLocation = grid[currentPosition.X, currentPosition.Y + 1];
            }
            break;
        case Direction.Left:
            currentPosition = new Coordinate(currentPosition.X - 1, currentPosition.Y);

            if (currentPosition.X - 1 < 0)
            {
                onTheGrid = false;
            }
            else
            {
                peekNextLocation = grid[currentPosition.X - 1, currentPosition.Y];
            }
            break;
        case Direction.Right:
            currentPosition = new Coordinate(currentPosition.X + 1, currentPosition.Y);

            if (currentPosition.X + 1 > grid.GetUpperBound(0))
            {
                onTheGrid = false;
            }
            else
            {
                peekNextLocation = grid[currentPosition.X + 1, currentPosition.Y];
            }
            break;
    }

    if (!visited.Contains(currentPosition))
    {
        visited.Add(currentPosition);
    }

    Console.WriteLine($"X: {currentPosition.X}, Y: {currentPosition.Y}");

    if (peekNextLocation == "#")
    {
        switch (direction)
        {
            case Direction.Up:
                direction = Direction.Right;
                break;
            case Direction.Left:
                direction = Direction.Up;
                break;
            case Direction.Down:
                direction = Direction.Left;
                break;
            case Direction.Right:
                direction = Direction.Down;
                break;
        }
    }
}

Console.WriteLine(visited.Count);

Console.ReadLine();