using Game;

var board = new Board();
board.DrawBoard();

while (!board.GameOver)
{
    board.Update();
    board.DrawBoard();
}