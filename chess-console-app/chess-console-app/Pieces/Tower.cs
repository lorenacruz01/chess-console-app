using Board;

namespace Pieces
{
    class Tower : Piece
    {
        public Tower(Color pieceColor, ChessBoard chessBoard) : base(pieceColor, chessBoard)
        {

        }
        public override string ToString()
        {
            return "T";
        }
        public override bool[,] AllowedMoves()
        {
            throw new System.NotImplementedException();
        }
    }
}
