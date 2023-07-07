
using Snake;
int dimention = 10;
Directions directions = Directions.up;
Field field = new Field(dimention);
SnakeBody snake = new SnakeBody();
Fruit apple = new Fruit();
bool move = true;



do
{
    // fill field
    for (int i = 0; i < field.FieldArea.GetLength(0); i++)
    {
        for (int j = 0; j < field.FieldArea.GetLength(1); j++)
        {
            field.FieldArea[j, i] = '0';
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
        apple.Apple.X = new Random().Next();
    }


        //print the field with the snake
        for (int i = 0; i < field.FieldArea.GetLength(0); i++)
    {
        for (int j = 0; j < field.FieldArea.GetLength(1); j++)
        {
            Console.Write(field.FieldArea[j, i]);
        }
        Console.WriteLine();
    }

    //get input
    ConsoleKeyInfo currentDirection = Console.ReadKey();

    //get direction from input
    switch (currentDirection.Key)

    {
        case ConsoleKey.UpArrow:
            directions = Directions.up;
            break;

        case ConsoleKey.DownArrow:
            directions = Directions.down;
            break;
        case ConsoleKey.LeftArrow:
            directions = Directions.left;
            break;
        case ConsoleKey.RightArrow:
            directions = Directions.right;
            break;
        default:
            break;
    }
    Thread.Sleep(1000);
    Console.Clear();




    int index = 0;
    //currentCell = snake.Body.First();


    Cell backupHead = new Cell(snake.Body[index]);
    Cell backupBody;
    // head movement




    //Cell head = snake.Body[0];
    //Cell newHead = new Cell(head.X, head.Y);

    //switch (direction)
    //{
    //    case Directions.Up:
    //        newHead.X--;
    //        break;
    //    case Directions.Down:
    //        newHead.X++;
    //        break;
    //    case Directions.Left:
    //        newHead.Y--;
    //        break;
    //    case Directions.Right:
    //        newHead.Y++;
    //        break;
    //}

    //snake.Body.Insert(0, newHead);
    ////snake.Body.RemoveAt(snake.Body.Count - 1);


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
        || snake.Body[0].Y > field.FieldArea.GetLength(0) -1
        || snake.Body[0].Y < 0 
        || snake.Body[0].X > field.FieldArea.GetLength(1)-1)
    {
        Console.WriteLine("Game Over!");
        break;
    }
    for (int i = 1; i <= snake.Body.Count - 1; i++)
    {
        if (snake.Body[0].X == snake.Body[i].X && snake.Body[0].Y == snake.Body[i].Y)
        {
            Console.Clear();
            Console.WriteLine("Game Over!");
            return;
        }
    }
    //algorithm for moving the snake
    for (int i = index; i < snake.Body.Count; i++)
    {
        backupBody = new Cell(snake.Body[index]);
        snake.Body[index] = backupHead;
        backupHead = new Cell(backupBody);
        index++;

    }

} while (move);

