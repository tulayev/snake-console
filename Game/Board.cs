namespace Game
{
    public class Board
    {
        private readonly List<Position> _snake = new();
        
        private int _snakeLength = 5;

        private Position _currentPos;

        private Directions _dir = Directions.Right;

        public bool GameOver { get; set; } = false;

        public Board()
        {
            Console.CursorVisible = false;
        }

        public void DrawBoard()
        {
            Console.Clear();
            Wall.DrawWall();

            foreach (var part in _snake)
            {
                Console.SetCursorPosition(part.X, part.Y);
                Console.Write('#');
            }
        }

        public void Update()
        {
            _currentPos = _snake.Count == 0
                ? GetSpawnPosition()
                : new Position { X = _snake.Last().X, Y = _snake.Last().Y };
                
            Thread.Sleep(500);

            if (Console.KeyAvailable)
                ChangeDir();

            Move();

            if (_snake.Any(p => p.X == _currentPos.X && p.Y == _currentPos.Y))
                GameOver = true;

            _snake.Add(_currentPos);
            ClearTail();
        }

        private void Move()
        {
            switch (_dir)
            {
                case Directions.Left:
                    _currentPos.X--;
                    break;
                case Directions.Right:
                    _currentPos.X++;
                    break;
                case Directions.Up:                    
                    _currentPos.Y--;
                    break;
                case Directions.Down:
                    _currentPos.Y++;
                    break;
            }
        }

        private void ChangeDir()
        {
            var key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    _dir = Directions.Left;
                    break;
                case ConsoleKey.RightArrow:
                    _dir = Directions.Right;
                    break;
                case ConsoleKey.UpArrow:
                    _dir = Directions.Up;
                    break;
                case ConsoleKey.DownArrow:
                    _dir = Directions.Down;
                    break;
            }
        }

        private void ClearTail()
        {
            if (_snake.Count > _snakeLength)
                _snake.Remove(_snake.First());
        }

        private static Position GetSpawnPosition()
        {
            return new Position
            {
                X = 2,
                Y = 2
            };
        }      
    }
}