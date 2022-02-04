using chess_console_app;
namespace Board
{
    class Position
    {
        public int Line { get; set; }
        public int Column { get; set; }

        public Position()
        {

        }
        public Position(char columnLetter, int line)
        {
            
            int convertedColumn = -1;
            char[] letters = Print.ColumnLetters.ToCharArray();
            for (int i = 0; i < letters.Length; i++)
            {
                if (letters[i] == columnLetter)
                {
                    convertedColumn = i;
                }
            }
            Line = Print.Constant - line;
            Column = convertedColumn;
        }

        public void DefinePosition(int line, int column)
        {
            Line = line;
            Column = column;
        }

        public override string ToString()
        {
            return Line + ", " + Column;
        }
    }
}
