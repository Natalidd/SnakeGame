
using Snake;
using Snake.Data;
using Snake.Data.Models;

int dimension = 10;
Directions directions = Directions.up;
Field field = new Field(dimension);
SnakeBody snake = new SnakeBody();
Fruit apple = new Fruit();
bool move = true;
int score = 0;
bool AppleMatchesSnake()
{
    for (int i = 1; i <= snake.Body.Count - 1; i++)
    {
        if (snake.Body[i].X == apple.Apple.X && snake.Body[i].Y == apple.Apple.Y)
        {
            return true;
        }

    }
    return false;
}

ConsoleKeyInfo currentDirection = Console.ReadKey();

do
{
    // fill field
    for (int i = 0; i < field.FieldArea.GetLength(0); i++)
    {
        for (int j = 0; j < field.FieldArea.GetLength(1); j++)
        {
            field.FieldArea[j, i] = '░';
        }
    }
    //putting the snake in the field
    foreach (var cell in snake.Body)
    {

        int x = cell.X;
        int y = cell.Y;
        if (x >= 0 && x < field.FieldArea.GetLength(0) && y >= 0 && y < field.FieldArea.GetLength(1))
        {
            field.FieldArea[y, x] = 's';
        }

    }
    //putting apple in field
    field.FieldArea[apple.Apple.Y, apple.Apple.X] = 'a';
    if (snake.Body[0].X == apple.Apple.X && snake.Body[0].Y == apple.Apple.Y)
    {
        field.FieldArea[apple.Apple.Y, apple.Apple.X] = 's';
        score += 5;
        //last cell
        Cell newTail = snake.Body.Last();

        apple.Apple.X = new Random().Next(0, dimension);
        apple.Apple.Y = new Random().Next(0, dimension);
        while (AppleMatchesSnake())
        {
            apple.Apple.X = new Random().Next(0, dimension);
            apple.Apple.Y = new Random().Next(0, dimension);
        }
        snake.Body.Add(newTail);
        field.FieldArea[apple.Apple.Y, apple.Apple.X] = 'a';

    }

    //print the field with snake
    for (int k = 0; k < field.FieldArea.GetLength(0); k++)
    {
        for (int j = 0; j < field.FieldArea.GetLength(1); j++)
        {
            if (field.FieldArea[j, k] == 'a')
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (field.FieldArea[j, k] == 's')
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (field.FieldArea[j, k] == '░')
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }
            Console.Write(field.FieldArea[j, k]);

        }
        Console.WriteLine();
    }


    Console.WriteLine("score: " + score);


    while (Console.KeyAvailable)
    {
        currentDirection = Console.ReadKey();
    }
    if (currentDirection.Key == ConsoleKey.P)
    {
        while (!Console.KeyAvailable)
        {
            currentDirection = Console.ReadKey();

        }
        if (currentDirection.Key != ConsoleKey.P)
        {
            Thread.Sleep(1000);
        }
    }


    //get input
    Thread.Sleep(1000);

    //get direction from input
    switch (currentDirection.Key)

    {
        case ConsoleKey.UpArrow:
            if (directions != Directions.down)
            {
                directions = Directions.up;
            }

            break;

        case ConsoleKey.DownArrow:
            if (directions != Directions.up)
            {
                directions = Directions.down;
            }
            break;
        case ConsoleKey.LeftArrow:
            if (directions != Directions.right)
            {
                directions = Directions.left;
            }
            break;
        case ConsoleKey.RightArrow:
            if (directions != Directions.left)
            {
                directions = Directions.right;
            }
            break;
        default:
            break;
    }

    Console.Clear();
    //currentDirection = Console.ReadKey(true);
    int index = 0;
    //currentCell = snake.Body.First();



    Cell backupHead = new Cell(snake.Body[index]);
    Cell backupBody;
    // head movement




    switch (directions)
    {

        case Directions.up:

            snake.Body[index].X = --snake.Body[index].X;

            break;
        case Directions.down:

            snake.Body[index].X = ++snake.Body[index].X;

            break;
        case Directions.left:
            {
                snake.Body[index].Y = --snake.Body[index].Y;
            }
            break;
        case Directions.right:
            {
                snake.Body[index].Y = ++snake.Body[index].Y;
            }
            break;
    }
    index++;
    if (snake.Body[0].X < 0
        || snake.Body[0].Y > field.FieldArea.GetLength(0) - 1
        || snake.Body[0].Y < 0
        || snake.Body[0].X > field.FieldArea.GetLength(1) - 1)
    {

        Console.WriteLine("Game Over!");
        break;
    }
    for (int p = 1; p <= snake.Body.Count - 1; p++)
    {
        if (snake.Body[0].X == snake.Body[p].X && snake.Body[0].Y == snake.Body[p].Y)
        {
            Console.Clear();
            Console.WriteLine("Game Over!");
            return;
        }
    }
    //algorithm for moving the snake
    for (int h = index; h < snake.Body.Count; h++)
    {
        backupBody = new Cell(snake.Body[index]);
        snake.Body[index] = backupHead;
        backupHead = new Cell(backupBody);
        index++;
    }


} while (move);
Console.Write("playerName: ");
string playerName = Console.ReadLine();
using (var db = new AppDbContext())
{
    HighScores highscore = new HighScores();
    highscore.Name = playerName;
    highscore.Score = score;
    db.Add(highscore);
    db.SaveChanges();
    var list = db.HighScores
        .GroupBy(x => x.Name)
        .Select(g => new
        {
            Name = g.Key,
            Score = g.Max(y => y.Score)
        }).
        ToList();
    foreach (var item in list)
    {
        Console.WriteLine("player name: " + item.Name);
        Console.WriteLine("score: " + item.Score);
    }
}
