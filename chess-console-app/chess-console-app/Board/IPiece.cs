﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Board
{
    interface IPiece
    {
        bool VerifyPosition(Position pos);
        bool[,] AllowedMoves();
    }
}
