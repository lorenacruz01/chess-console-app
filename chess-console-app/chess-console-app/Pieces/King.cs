﻿using Board;

namespace Pieces
{
    class King : Piece
    {
        public King(Color pieceColor, ChessBoard chessBoard) : base(pieceColor, chessBoard)
        {
        }

        public override bool[,] Moves()
        {
            bool[,] moves = new bool[ChessBoard.Lines, ChessBoard.Columns];
            Position position = new Position();

            position.DefinePosition(PiecePosition.Line - 1, PiecePosition.Column);
            if (ChessBoard.PositionInsideBoardLimits(position) && VerifyPosition(position))
            {
                moves[position.Line, position.Column] = true;
            }

            position.DefinePosition(PiecePosition.Line + 1, PiecePosition.Column);
            if (ChessBoard.PositionInsideBoardLimits(position) && VerifyPosition(position))
            {
                moves[position.Line, position.Column] = true;
            }

            position.DefinePosition(PiecePosition.Line, PiecePosition.Column - 1);
            if (ChessBoard.PositionInsideBoardLimits(position) && VerifyPosition(position))
            {
                moves[position.Line, position.Column] = true;
            }

            position.DefinePosition(PiecePosition.Line, PiecePosition.Column + 1);
            if (ChessBoard.PositionInsideBoardLimits(position) && VerifyPosition(position))
            {
                moves[position.Line, position.Column] = true;
            }


            position.DefinePosition(PiecePosition.Line + 1, PiecePosition.Column + 1);
            if (ChessBoard.PositionInsideBoardLimits(position) && VerifyPosition(position))
            {
                moves[position.Line, position.Column] = true;
            }

            position.DefinePosition(PiecePosition.Line - 1, PiecePosition.Column - 1);
            if (ChessBoard.PositionInsideBoardLimits(position) && VerifyPosition(position))
            {
                moves[position.Line, position.Column] = true;
            }

            position.DefinePosition(PiecePosition.Line + 1, PiecePosition.Column - 1);
            if (ChessBoard.PositionInsideBoardLimits(position) && VerifyPosition(position))
            {
                moves[position.Line, position.Column] = true;
            }

            position.DefinePosition(PiecePosition.Line - 1, PiecePosition.Column + 1);
            if (ChessBoard.PositionInsideBoardLimits(position) && VerifyPosition(position))
            {
                moves[position.Line, position.Column] = true;
            }
            return moves;
        }

        public override string ToString()
        {
            return "K";
        }
    }
}
