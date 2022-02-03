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

        public Piece SinglePiece(Position pos)
        {
            Piece p = Pieces[pos.Line, pos.Column];
            return p;
        }

        public void PositionIsValid(Position pos)
        {
            if(pos.Line < 0 || pos.Line >= Lines || pos.Column < 0 || pos.Column >= Columns)
            {
                throw new BoardException("Invalid Position");
            }
            if (SinglePiece(pos) != null)
            { 
                throw new BoardException("Another piece is already placed in this position!");
            }

        }
       
        public void PlaceSinglePiece(Piece p, Position pos)
        {
            PositionIsValid(pos);
            Pieces[pos.Line, pos.Column] = p;
            p.PiecePostion = pos;

        }



    }
}
