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
                ChessBoard board = new ChessBoard(8, 8);
                board.PlaceSinglePiece(new King(Color.Black, board), new Position('a', 1));
                board.PlaceSinglePiece(new King(Color.White, board), new Position('a', 8));
                Print.Board(board);
            } catch(BoardException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            
        }
    }
}
