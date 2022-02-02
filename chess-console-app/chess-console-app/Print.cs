using Board;
using System;
using System.Collections.Generic;
using System.Text;

namespace chess_console_app
{
    class Print
    {
        protected static string letter = "a,b,c,d,e,f,g,h";
        public static void Board(ChessBoard chessBoard)
        {
            for(int i = 0; i < chessBoard.Lines; i++)
            {
                for(int j = 0; j < chessBoard.Columns; j++)
                {
                    if(chessBoard.SinglePiece(i, j) != null)
                    {
                        Console.Write(chessBoard.SinglePiece(i, j) + " ");
                    } else
                    {
                        Console.Write("- ");
                    }
                    
                }
                Console.WriteLine();
            }
        }
    }
}
