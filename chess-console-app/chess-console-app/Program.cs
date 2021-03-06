using System;
using Board;
using Pieces;

namespace chess_console_app
{
    class Program
    {
        
        static void Main(string[] args)
        {


            Match match = new Match();
            while (!match.Finished)
            {
                try
                {
                    Console.Clear();
                    //Print.Board(match.ChessBoard);
                    Print.Match(match);
                    
                    Console.WriteLine();
                    Console.Write("From: ");
                    Position origin = ReadInformation();
                    match.ValidateOrigin(origin);

                    bool[,] moves = match.ChessBoard.SinglePiece(origin).Moves();
                    Console.Clear();
                    Print.Board(match.ChessBoard, moves);

                    Console.WriteLine();
                    Console.Write("To: ");
                    Position destination = ReadInformation();
                    match.ValidateDestination(origin, destination);
                    match.MakeAMove(origin, destination);
                    Print.Board(match.ChessBoard);
                }
                catch (BoardException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Press enter to try again!");
                    Console.ReadLine();
                }

            }
            Console.Clear();
            Print.Match(match);
            Console.WriteLine("Press enter to finish the application!");
            Console.ReadLine();

        }

        static Position ReadInformation()
        {
            string typedPosition = Console.ReadLine();
            if (typedPosition.Length > 2)
            {
                throw new BoardException("You must type only two characters! The first one is a letter (a-g) " +
                    "that refers to the column and the second refers to the line number (1-7). Ex: a1, b2, c7 etc.");
            }
            char column = typedPosition[0];
            int line = int.Parse(typedPosition[1].ToString());
            Position position = new Position(column, line);
            return position;
        }
    }
}
