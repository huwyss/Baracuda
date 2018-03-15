﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantaChessEngine
{
    public class Rating
    {
        /// <summary>
        /// Score of the move. Positive means good for white, negative means good for black.
        /// </summary>
        public float Score { get; set; }

        /// <summary>
        /// True means legal, false means illegal (king is left in check, capture the opponents king, or own king is lost)
        /// </summary>
        public bool IsLegal { get; set; }

        /// <summary>
        /// The number of illegal moves already played.
        /// 0 = all good
        /// 1 = this is the 1st illegal move (king left in check)
        /// 2 = this is the 2nd illegal move (capture opponents king)
        /// 3 = this is the 3rd illegal move (own king is already lost)
        /// </summary>
        public int IllegalMoveCount { get; set; }

        public Rating()
        {
            Score = 0;
            IsLegal = true;
            IllegalMoveCount = 0;
        }
    }
}