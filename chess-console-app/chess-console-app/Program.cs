using System;
using Board;
using Pieces;

namespace chess_console_app
{
    class Program
    {
        static Position ReadInformation()
        {
            string typedPosition = Console.ReadLine();
            char column = typedPosition[0];
            int line = int.Parse(typedPosition[1].ToString());
            Position position = new Position(column, line);
            return position;
        }
        static void Main(string[] args)
        {

            try
            {
              
                Match match = new Match();
                while (!match.Finished)
                {
                    Console.Clear();
                    Print.Board(match.ChessBoard);
                    Console.WriteLine();
                    Console.Write("From: ");
                    Position origin = ReadInformation();

                    bool[,] allowedMoves = match.ChessBoard.SinglePiece(origin).AllowedMoves();
                    Console.Clear();
                    Print.Board(match.ChessBoard, allowedMoves);

                    Console.WriteLine();
                    Console.Write("To: ");
                    Position destination = ReadInformation();
                    match.MovePiece(origin, destination);
                    Print.Board(match.ChessBoard);
                }

            } catch(BoardException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            
        }
    }
}
