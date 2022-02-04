using System;
using System.Collections.Generic;
using System.Text;

namespace Board
{
    abstract class Piece : IPiece
    {
        public Position PiecePosition { get; set; }
        public Color PieceColor { get; protected set; }
        public ChessBoard ChessBoard { get; set; }
        public int NumberOfMoves { get; set; }

        public bool VerifyPosition(Position position)
        {
            Piece piece = ChessBoard.SinglePiece(position);
            if (piece != null && piece.PieceColor == PieceColor)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public abstract bool[,] AllowedMoves();
        
        protected Piece(Color pieceColor, ChessBoard chessBoard)
        {
            PiecePosition = null;
            PieceColor = pieceColor;
            ChessBoard = chessBoard;
            NumberOfMoves = 0;
        }

        public void RegisterMove()
        {
            NumberOfMoves++;
        }

   
    }
}
