namespace Game
{
    public static class Wall
    {
        private static int _width = Console.WindowWidth - 10;

        private static int _height = Console.WindowHeight - 10;

        public static void DrawWall()
        {
            for (int i = 0; i < _width; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write('-');
            }
            
            for (int i = 0; i < _width; i++)
            {
                Console.SetCursorPosition(i, _height);
                Console.Write('-');
            }
            
            for (int i = 0; i < _height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write('|');
            }
            
            for (int i = 0; i < _height; i++)
            {
                Console.SetCursorPosition(_width, i);
                Console.Write('|');
            }
        }
    }
}
