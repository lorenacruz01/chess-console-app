using Board;

namespace Pieces
{
    class Pawn : Piece
    {
        public Pawn(Color pieceColor, ChessBoard chessBoard) : base(pieceColor, chessBoard)
        {
        }

        private bool OpponentPlacedInPosition(Position position)
        {
            Piece piece = ChessBoard.SinglePiece(position);
            if (piece != null && piece.PieceColor != PieceColor)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool VacantPosition(Position position)
        {
            Piece piece = ChessBoard.SinglePiece(position);
            if (piece == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override bool[,] Moves()
        {
            bool[,] moves = new bool[ChessBoard.Lines, ChessBoard.Columns];
            Position position = new Position();
            int kFirst = 0;
            int k = 0;
            if (PieceColor == Color.White)
            {
                kFirst = -2;
                k = -1;
            }
            else
            {
                kFirst = 2;
                k = 1;
            }

            position.DefinePosition(PiecePosition.Line + kFirst, PiecePosition.Column);
            if (ChessBoard.PositionInsideBoardLimits(position) && VacantPosition(position) && NumberOfMoves == 0)
            {
                moves[position.Line, position.Column] = true;
            }

            position.DefinePosition(PiecePosition.Line + k, PiecePosition.Column);
            if (ChessBoard.PositionInsideBoardLimits(position) && VacantPosition(position))
            {
                moves[position.Line, position.Column] = true;
            }

            position.DefinePosition(PiecePosition.Line + k, PiecePosition.Column + 1);
            if (ChessBoard.PositionInsideBoardLimits(position) && OpponentPlacedInPosition(position))
            {
                moves[position.Line, position.Column] = true;
            }

            position.DefinePosition(PiecePosition.Line + k, PiecePosition.Column - 1);
            if (ChessBoard.PositionInsideBoardLimits(position) && OpponentPlacedInPosition(position))
            {
                moves[position.Line, position.Column] = true;
            }

            return moves;
        }


        public override string ToString()
        {
            return "P";
        }
    }

}
