using System;
using System.Collections.Generic;
using System.Text;
using chess_console_app;

namespace Board
{
    class ChessBoard
    {
        public int Lines = Print.Constant;
        public int Columns = Print.Constant;
        private Piece[,] Pieces { get; set; }

        public ChessBoard()
        {
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
       
        public void PlaceSinglePiece(Piece p, Position position)
        {
            PositionIsValid(position);
            Pieces[position.Line, position.Column] = p;
            p.PiecePostion = position;

        }

        public Piece RemoveSinglePiece(Position position)
        {
            if(SinglePiece(position) == null)
            {
                return null;
            } else
            {
                Piece pieceToBeRemoved = SinglePiece(position);
                pieceToBeRemoved.PiecePostion = null;
                Pieces[position.Line, position.Column] = null;
                return pieceToBeRemoved;
            }
        }



    }
}
