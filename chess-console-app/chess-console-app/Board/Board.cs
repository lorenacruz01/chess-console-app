using System;
using System.Collections.Generic;
using System.Text;

namespace Board
{
    class ChessBoard
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        private Piece[,] Pieces { get; set; }

        public ChessBoard(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[Lines, Columns];
        }

        public Piece SinglePiece(int line, int column)
        {
            Piece p = Pieces[line, column];
            return p;
        }

        public void PlaceSinglePiece(Piece p, Position pos)
        {
            Pieces[pos.Line, pos.Column] = p;
            p.PiecePostion = pos;
        }
    }
}
