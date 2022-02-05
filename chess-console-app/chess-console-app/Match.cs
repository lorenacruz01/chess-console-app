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
        public bool Check { get; private set; }

        public Match()
        {
            Turn = 1;
            CurrentPlayer = Color.White;
            ChessBoard = new ChessBoard();
            Pieces = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();
            Check = false;
            PlaceAllPieces();
        }
        private void PlacePiece(Piece piece, char column, int line)
        {
            Pieces.Add(piece);
            ChessBoard.PlaceSinglePiece(piece, new Position(column, line));
        }
        private void PlaceAllPieces()
        {
            PlacePiece(new Rook(Color.White, ChessBoard), 'a', 1);
            PlacePiece(new Knight(Color.White, ChessBoard), 'b', 1);
            PlacePiece(new Bishop(Color.White, ChessBoard), 'c', 1);
            PlacePiece(new Queen(Color.White, ChessBoard), 'd', 1);
            PlacePiece(new King(Color.White, ChessBoard), 'e', 1);
            PlacePiece(new Bishop(Color.White, ChessBoard), 'f', 1);
            PlacePiece(new Knight(Color.White, ChessBoard), 'g', 1);
            PlacePiece(new Rook(Color.White, ChessBoard), 'h', 1);
            PlacePiece(new Pawn(Color.White, ChessBoard), 'a', 2);
            PlacePiece(new Pawn(Color.White, ChessBoard), 'b', 2);
            PlacePiece(new Pawn(Color.White, ChessBoard), 'c', 2);
            PlacePiece(new Pawn(Color.White, ChessBoard), 'd', 2);
            PlacePiece(new Pawn(Color.White, ChessBoard), 'e', 2);
            PlacePiece(new Pawn(Color.White, ChessBoard), 'f', 2);
            PlacePiece(new Pawn(Color.White, ChessBoard), 'g', 2);
            PlacePiece(new Pawn(Color.White, ChessBoard), 'h', 2);

            PlacePiece(new Pawn(Color.Black, ChessBoard), 'a', 7);
            PlacePiece(new Pawn(Color.Black, ChessBoard), 'b', 7);
            PlacePiece(new Pawn(Color.Black, ChessBoard), 'c', 7);
            PlacePiece(new Pawn(Color.Black, ChessBoard), 'd', 7);
            PlacePiece(new Pawn(Color.Black, ChessBoard), 'e', 7);
            PlacePiece(new Pawn(Color.Black, ChessBoard), 'f', 7);
            PlacePiece(new Pawn(Color.Black, ChessBoard), 'g', 7);
            PlacePiece(new Pawn(Color.Black, ChessBoard), 'h', 7);
            PlacePiece(new Rook(Color.Black, ChessBoard), 'a', 8);
            PlacePiece(new Knight(Color.Black, ChessBoard), 'b', 8);
            PlacePiece(new Bishop(Color.Black, ChessBoard), 'c', 8);
            PlacePiece(new Queen(Color.Black, ChessBoard), 'd', 8);
            PlacePiece(new King(Color.Black, ChessBoard), 'e', 8);
            PlacePiece(new Bishop(Color.Black, ChessBoard), 'f', 8);
            PlacePiece(new Knight(Color.Black, ChessBoard), 'g', 8);
            PlacePiece(new Rook(Color.Black, ChessBoard), 'h', 8);

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
        public Piece MovePiece(Position origin, Position destination)
        {
            Piece pieceToBeMoved = ChessBoard.RemoveSinglePiece(origin);
            pieceToBeMoved.RegisterMove();

            Piece capturedPiece = ChessBoard.RemoveSinglePiece(destination);
            if (capturedPiece != null)
            {
                CapturedPieces.Add(capturedPiece);
            }
            ChessBoard.PlaceSinglePiece(pieceToBeMoved, destination);

            return capturedPiece;
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

        public void UndoMove(Piece piece, Position origin, Position destination)
        {
            Piece pieceToOrigin = ChessBoard.RemoveSinglePiece(destination);
            pieceToOrigin.NumberOfMoves--;
            if(piece != null)
            {
                ChessBoard.PlaceSinglePiece(piece, destination);
                CapturedPieces.Remove(piece);
            }
            ChessBoard.PlaceSinglePiece(pieceToOrigin, origin);

        }

        public void MakeAMove(Position origin, Position destination)
        {
            Piece capturedPiece = MovePiece(origin, destination);
            
            if (IsCheck(CurrentPlayer))
            {           
                UndoMove(capturedPiece, origin, destination);
                throw new BoardException("You cannot make a move that places your King in check!");
            }

            if (IsCheck(Opponent(CurrentPlayer)))
            {
                Check = true;
            } else
            {
                Check = false;
            }

            if (IsCheckmate(Opponent(CurrentPlayer)))
            {
                Finished = true;
            }
            else
            {
                Finished = false;
                Turn++;

                SwitchPlayer();
            }

            
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

        private Piece King(Color color)
        {
            foreach (Piece piece in PlayerAvailablePieces(color))
            {
                if(piece is King)
                {
                    return piece;
                }
            }
            return null;
        }

        private Color Opponent(Color player)
        {
            if (player == Color.Black)
            {
                return Color.White;
            }
            else
            {
                return Color.Black;
            }
        }

        private bool IsCheck(Color player)
        {
            bool[,] allThreats; 
            foreach(Piece piece in PlayerAvailablePieces(Opponent(player)))
            {
                Piece king = King(player);
                allThreats = piece.Moves();
                if(allThreats[king.PiecePosition.Line, king.PiecePosition.Column])
                {
                    return true;
                }  
            }
            return false;
        }

        private bool IsCheckmate(Color player)
        {
            if (IsCheck(player) == false)
            {
                return false;
            } else
            {
                bool[,] moves;
                foreach (Piece piece in PlayerAvailablePieces(player))
                {

                    moves = piece.Moves();
                    for (int i = 0; i < ChessBoard.Lines; i++)
                    {
                        for (int j = 0; j < ChessBoard.Columns; j++)
                        {
                            if (moves[i, j] == true)
                            {
                                Position fromPosition = piece.PiecePosition;
                                Position toPosition = new Position(i, j);
                                Piece capturedPiece = MovePiece(fromPosition, toPosition);
                                bool isCheck = IsCheck(player);
                                UndoMove(capturedPiece, fromPosition, toPosition);
                                if (isCheck == false)
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
                return true;
            }
            
        }
    }
}
