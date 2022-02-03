using System;
using Board;
using System.Collections.Generic;
using System.Text;

namespace chess_console_app
{
    class Converter
    {
        public int Line { get; set; }
        public char Column { get; set; }

        public Converter(int line, char column)
        {
            Line = line;
            Column = column;
        }

       /* public Position ConvertToPosition()
        {
            int convertedLine = Print.LineConstant - Line;
            int convertedColumn = -1;
            char[] letters = Print.ColumnLetters.ToCharArray();
            for (int i = 0; i < letters.Length; i++)
            {
                if(letters[i] == Column)
                {
                    convertedColumn = i;
                } 
            }
            Position convertedPosition = new Position(convertedLine, convertedColumn);
            return convertedPosition;
        }*/
    }
}
