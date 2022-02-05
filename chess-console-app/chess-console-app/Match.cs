using System;
using Board;
using Pieces;

namespace chess_console_app
{
    class Match
    {
        public bool Finished { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
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
            ChessBoard.PlaceSinglePiece(new King(Color.White, ChessBoard), new Position('a', 7));
            ChessBoard.PlaceSinglePiece(new King(Color.White, ChessBoard), new Position('b', 7));
            ChessBoard.PlaceSinglePiece(new King(Color.White, ChessBoard), new Position('b', 8));

        }

        public void ValidateOrigin(Position position)
        {
            if(ChessBoard.SinglePiece(position) == null)
            {
                throw new BoardException("There is no piece placed in this position!");
            }
            if(CurrentPlayer != ChessBoard.SinglePiece(position).PieceColor)
            {
                throw new BoardException("You chose the wrong color piece!");
            }
            if(ChessBoard.SinglePiece(position).AllowedMoves() == false)
            {
                throw new BoardException("There are no moves allowed for this piece");
            }

        }

        public void ValidateDestination(Position origin, Position destination)
        {
            if (ChessBoard.SinglePiece(origin).AllowedToMove(destination) == false)
            {
                throw new BoardException("The piece you chose is not allowed to move to this position!");
            }
        }
        public void MovePiece(Position origin, Position destination)
        {
            Piece pieceToBeMoved = ChessBoard.RemoveSinglePiece(origin);
            pieceToBeMoved.RegisterMove();
            ChessBoard.RemoveSinglePiece(destination);
            ChessBoard.PlaceSinglePiece(pieceToBeMoved, destination);

        }

        private void SwitchPlayer()
        {
            if(CurrentPlayer == Color.Black)
            {
                CurrentPlayer = Color.White;
            } else
            {
                CurrentPlayer = Color.Black;
            }
        }

        public void MakeAMove(Position origin, Position destination)
        {
            MovePiece(origin, destination);
            Turn++;
            SwitchPlayer();
        }



    }
}
