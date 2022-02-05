using Board;

namespace Pieces
{
    class Bishop : Piece
    {
        public Bishop(Color pieceColor, ChessBoard chessBoard) : base(pieceColor, chessBoard)
        {
        }

        public override bool[,] Moves()
        {
            bool[,] moves = new bool[ChessBoard.Lines, ChessBoard.Columns];
            Position position = new Position();

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
            return "B";
        }
    }
}
