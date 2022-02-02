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

        protected Piece(Position piecePostion, Color pieceColor, ChessBoard chessBoard)
        {
            PiecePostion = piecePostion;
            PieceColor = pieceColor;
            ChessBoard = chessBoard;
            NumberOfMoves = 0;
        }

        public abstract bool[,] AllowedMoves();
    }
}
