using System;

namespace Board
{
    class BoardException : Exception
    {
        public BoardException(string exceptionMessage) : base(exceptionMessage)
        {
        }
    }
}
