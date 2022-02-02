using Board;

namespace Pieces
{
    class King : Piece
    {
        public King(Color pieceColor, ChessBoard chessBoard) : base(pieceColor, chessBoard)
        {

        }

        public override bool[,] AllowedMoves()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            return "K";
        }
    }
}
