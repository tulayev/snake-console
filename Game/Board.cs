namespace Game
{
    public class Board
    {
        private readonly List<Position> _snake;
        
        private readonly int _snakeLength;

        private Position _currentPos;

        private Directions _dir;

        public bool GameOver { get; set; } = false;

        public Board()
        {
            Console.CursorVisible = false;
            _snake = new List<Position>();
            _snakeLength = 3;
            _dir = Directions.Right;
            _currentPos = GetSpawnPosition();
        }

        public void DrawBoard()
        {
            Console.Clear();

            foreach (var part in _snake)
            {
                Console.SetCursorPosition(part.X, part.Y);
                Console.Write('#');
            }
        }

        public void Update()
        {
            _currentPos =  new Position { X = _snake.LastOrDefault().X, Y = _snake.LastOrDefault().Y };
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

            Move();
        }

        private void ClearTail()
        {
            while (_snake.Count > _snakeLength)
            {
                _snake.Remove(_snake.FirstOrDefault());
            }
        }

        private Position GetSpawnPosition()
        {
            return new Position
            {
                X = 0,
                Y = 0
            };
        }      
    }
}