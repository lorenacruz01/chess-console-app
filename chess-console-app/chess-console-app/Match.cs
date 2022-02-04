using System;
using Board;
using Pieces;

namespace chess_console_app
{
    class Match
    {
        public bool Finished { get; private set; }
        private int Turn { get; set; }
        private Color CurrentPlayer { get; set; }
        public ChessBoard ChessBoard { get; private set; }

        public Match()
        {
            Turn = 1;
            CurrentPlayer = Color.White;
            ChessBoard = new ChessBoard();
            PlaceAllPieces();
        }
        private void PlaceAllPieces()
        {
            ChessBoard.PlaceSinglePiece(new King(Color.Black, ChessBoard), new Position('a', 1));
            ChessBoard.PlaceSinglePiece(new King(Color.White, ChessBoard), new Position('a', 8));
            ChessBoard.PlaceSinglePiece(new Tower(Color.White, ChessBoard), new Position('a', 6));
        }

        public void MovePiece(Position origin, Position destination)
        {
            Piece pieceToBeMoved = ChessBoard.RemoveSinglePiece(origin);
            pieceToBeMoved.RegisterMove();
            ChessBoard.RemoveSinglePiece(destination);
            ChessBoard.PlaceSinglePiece(pieceToBeMoved, destination);

        }
    }
}
