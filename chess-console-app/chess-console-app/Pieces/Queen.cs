using Board;

namespace Pieces
{
    class Queen : Piece
    {
        public Queen(Color pieceColor, ChessBoard chessBoard) : base(pieceColor, chessBoard)
        {
        }

        public override bool[,] Moves()
        {
            bool[,] moves = new bool[ChessBoard.Lines, ChessBoard.Columns];
            Position position = new Position();

            position.DefinePosition(PiecePosition.Line - 1, PiecePosition.Column);
            while (ChessBoard.PositionInsideBoardLimits(position) && VerifyPosition(position))
            {
                moves[position.Line, position.Column] = true;
                if (ChessBoard.SinglePiece(position) != null && ChessBoard.SinglePiece(position).PieceColor != PieceColor)
                {
                    break;
                }
                position.Line--;
            }

            position.DefinePosition(PiecePosition.Line + 1, PiecePosition.Column);
            while (ChessBoard.PositionInsideBoardLimits(position) && VerifyPosition(position))
            {
                moves[position.Line, position.Column] = true;
                if (ChessBoard.SinglePiece(position) != null && ChessBoard.SinglePiece(position).PieceColor != PieceColor)
                {
                    break;
                }
                position.Line++;
            }

            position.DefinePosition(PiecePosition.Line, PiecePosition.Column - 1);
            while (ChessBoard.PositionInsideBoardLimits(position) && VerifyPosition(position))
            {
                moves[position.Line, position.Column] = true;
                if (ChessBoard.SinglePiece(position) != null && ChessBoard.SinglePiece(position).PieceColor != PieceColor)
                {
                    break;
                }
                position.Column--;
            }

            position.DefinePosition(PiecePosition.Line, PiecePosition.Column + 1);
            while (ChessBoard.PositionInsideBoardLimits(position) && VerifyPosition(position))
            {
                moves[position.Line, position.Column] = true;
                if (ChessBoard.SinglePiece(position) != null && ChessBoard.SinglePiece(position).PieceColor != PieceColor)
                {
                    break;
                }
                position.Column++;
            }

            position.DefinePosition(PiecePosition.Line - 1, PiecePosition.Column - 1);
            while (ChessBoard.PositionInsideBoardLimits(position) && VerifyPosition(position))
            {
                moves[position.Line, position.Column] = true;
                if (ChessBoard.SinglePiece(position) != null && ChessBoard.SinglePiece(position).PieceColor != PieceColor)
                {
                    break;
                }
                position.DefinePosition(position.Line - 1, position.Column - 1);
            }

            position.DefinePosition(PiecePosition.Line + 1, PiecePosition.Column + 1);
            while (ChessBoard.PositionInsideBoardLimits(position) && VerifyPosition(position))
            {
                moves[position.Line, position.Column] = true;
                if (ChessBoard.SinglePiece(position) != null && ChessBoard.SinglePiece(position).PieceColor != PieceColor)
                {
                    break;
                }
                position.DefinePosition(position.Line + 1, position.Column + 1);
            }

            position.DefinePosition(PiecePosition.Line + 1, PiecePosition.Column - 1);
            while (ChessBoard.PositionInsideBoardLimits(position) && VerifyPosition(position))
            {
                moves[position.Line, position.Column] = true;
                if (ChessBoard.SinglePiece(position) != null && ChessBoard.SinglePiece(position).PieceColor != PieceColor)
                {
                    break;
                }
                position.DefinePosition(position.Line + 1, position.Column - 1);
            }

            position.DefinePosition(PiecePosition.Line - 1, PiecePosition.Column + 1);
            while (ChessBoard.PositionInsideBoardLimits(position) && VerifyPosition(position))
            {
                moves[position.Line, position.Column] = true;
                if (ChessBoard.SinglePiece(position) != null && ChessBoard.SinglePiece(position).PieceColor != PieceColor)
                {
                    break;
                }
                position.DefinePosition(position.Line - 1, position.Column + 1);
            }
            return moves;
        }

        public override string ToString()
        {
            return "Q";
        }
    }
}
