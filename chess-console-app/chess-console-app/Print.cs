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
                for (int j = 0; j < chessBoard.Columns; j++)
                {

                    Piece(chessBoard.SinglePiece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void Board(ChessBoard chessBoard, bool[,] moves)
        {
            ConsoleColor defaultColor = Console.BackgroundColor;
            ConsoleColor newColor = ConsoleColor.DarkGray;

            for (int i = 0; i < chessBoard.Lines; i++)
            {
                Console.Write(Constant - i + " ");
                for (int j = 0; j < chessBoard.Columns; j++)
                {
                    if(moves[i, j])
                    {
                        Console.BackgroundColor = newColor;
                    } else
                    {
                        Console.BackgroundColor = defaultColor;
                    }
                    Piece(chessBoard.SinglePiece(i, j));
                    Console.BackgroundColor = defaultColor;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = defaultColor;
        }

        public static void Piece(Piece piece)
        {
            if(piece == null)
            {
                Console.Write("- ");
            } else
            {
                if (piece.PieceColor == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor defaultColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(piece);
                    Console.ForegroundColor = defaultColor;
                }
                Console.Write(" ");
            }
            
        }
        
    }
}
