using Board;
using System;
using System.Collections.Generic;
using System.Text;

namespace chess_console_app
{
    class Print
    {
        public static string ColumnLetters = "abcdefgh";
        public static int Constant = 8;
        public static void Board(ChessBoard chessBoard)
        {
            for(int i = 0; i < chessBoard.Lines; i++)
            {
                Console.Write(Constant - i + " ");
                for(int j = 0; j < chessBoard.Columns; j++)
                {
                    if(chessBoard.SinglePiece(i, j) != null)
                    {
                        Piece(chessBoard.SinglePiece(i, j));
                        Console.Write(" ");
                        //Console.Write(chessBoard.SinglePiece(i, j) + " ");
                    } else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void Piece(Piece piece)
        {
            if(piece.PieceColor == Color.White)
            {
                Console.Write(piece);
            } else
            {
                ConsoleColor defaultColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = defaultColor;
            }
        }
        
    }
}
