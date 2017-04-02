﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantaChessEngine
{
    public class NormalMove : MoveBase
    {
        public NormalMove(char movingPiece, int sourceFile, int sourceRank, int targetFile, int targetRank, char capturedPiece)
            : base(movingPiece, sourceFile, sourceRank, targetFile, targetRank, capturedPiece)
        {
        }

        public NormalMove(string moveStringUser)
            : base(moveStringUser)
        {
        }

        public override bool Equals(System.Object obj)
        {
            if (!(obj is NormalMove))
            {
                return false;
            }

            return base.Equals(obj);
        }

        public override string ToString()
        {
            string moveString = "";
            moveString += Helper.FileToFileChar(SourceFile);
            moveString += SourceRank.ToString();
            moveString += Helper.FileToFileChar(TargetFile);
            moveString += TargetRank;
            moveString += CapturedPiece;
            return moveString;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }
    }
}