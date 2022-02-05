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

        public static void PrintCapturedPieces(Match match)
        {
            Console.WriteLine("---All Captured Pieces---");
            Console.Write("White: ");
            HashSet<Piece> whiteCapturedPieces = match.PlayerCapturedPieces(Color.White);
            Console.Write("[ ");
            foreach(Piece piece in whiteCapturedPieces)
            {
                Console.WriteLine(piece + " ");
            }
            Console.Write("] ");

            Console.WriteLine();
            Console.Write("Black: ");
            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;
            HashSet<Piece> blackCapturedPieces = match.PlayerCapturedPieces(Color.Black);
            Console.Write("[ ");
            foreach (Piece piece in blackCapturedPieces)
            {
                Console.Write(piece + " ");
            }
            Console.WriteLine("] ");
            Console.ForegroundColor = defaultColor;
            Console.WriteLine("-------------------------");
        }



        public static void Match(Match match)
        {
            Board(match.ChessBoard);
            Console.WriteLine();
            PrintCapturedPieces(match);
            Console.WriteLine();
            Console.WriteLine("Turn: " + match.Turn + ", Player: " + match.CurrentPlayer);
        }
        
    }
}
