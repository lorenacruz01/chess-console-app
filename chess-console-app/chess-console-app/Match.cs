using System;
using System.Collections.Generic;
using System.Linq;
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

        private HashSet<Piece> Pieces { get; set; }
        private HashSet<Piece> CapturedPieces { get; set; }

        public Match()
        {
            Turn = 1;
            CurrentPlayer = Color.White;
            ChessBoard = new ChessBoard();
            Pieces = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();
            PlaceAllPieces();
        }
        private void PlacePiece(Piece piece, char column, int line)
        {
            Pieces.Add(piece);
            ChessBoard.PlaceSinglePiece(piece, new Position(column, line));
        }
        private void PlaceAllPieces()
        {
            PlacePiece(new King(Color.Black, ChessBoard), 'a', 1);
            PlacePiece(new King(Color.Black, ChessBoard), 'a', 8);
            PlacePiece(new King(Color.White, ChessBoard), 'b', 7);
            PlacePiece(new King(Color.White, ChessBoard), 'b', 6);

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

            Piece capturedPiece = ChessBoard.RemoveSinglePiece(destination);
            if (capturedPiece != null)
            {
                CapturedPieces.Add(capturedPiece);
            }
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

        public HashSet<Piece> PlayerCapturedPieces(Color player)
        {
             //capturedPieces = new HashSet<Piece>();
            HashSet<Piece> capturedPieces = new HashSet<Piece>(CapturedPieces.Where(x => x.PieceColor == player));
            return capturedPieces;
        }

        public HashSet<Piece> PlayerAvailablePieces(Color player)
        {
            //capturedPieces = new HashSet<Piece>();
            HashSet<Piece> availablePieces = new HashSet<Piece>(Pieces.Where(x => x.PieceColor == player));
            availablePieces.ExceptWith(PlayerCapturedPieces(player));
            return availablePieces;
        }


    }
}
