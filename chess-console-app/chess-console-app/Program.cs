using System;
using Board;

namespace chess_console_app
{
    class Program
    {
        static void Main(string[] args)
        {
            //testing board
            ChessBoard board = new ChessBoard(8, 8);
            Print.Board(board);
        }
    }
}
