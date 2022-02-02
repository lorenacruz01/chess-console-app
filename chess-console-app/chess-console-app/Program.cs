using System;
using Board;
using Pieces;

namespace chess_console_app
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //testing board
                ChessBoard board = new ChessBoard(8, 8);
                board.PlaceSinglePiece(new Tower(Color.Black, board), new Position(7, 7));
                board.PlaceSinglePiece(new Tower(Color.Black, board), new Position(1, 5));
                board.PlaceSinglePiece(new Tower(Color.Black, board), new Position(1, 8));
                Print.Board(board);
            }
            catch (BoardException excpt)
            {
                Console.WriteLine(excpt.Message);
            }
            
        }
    }
}
