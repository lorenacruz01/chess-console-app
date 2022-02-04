using System;
using System.Collections.Generic;
using System.Text;

namespace Board
{
    abstract class Piece : IPiece
    {
        public Position PiecePostion { get; set; }
        public Color PieceColor { get; protected set; }
        public ChessBoard ChessBoard { get; set; }
        public int NumberOfMoves { get; set; }

        public abstract bool[,] AllowedMoves();

        protected Piece(Color pieceColor, ChessBoard chessBoard)
        {
            PiecePostion = null;
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
