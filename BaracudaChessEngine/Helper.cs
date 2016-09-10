﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaracudaChessEngine
{
    public class Helper
    {
        public static char FileToFileChar(int file)
        {
            char fileChar = (char)(file - 1 + 'a');
            return fileChar;
        }

        public static int FileCharToFile(char fileChar)
        {
            int file = fileChar + 1 - 'a';
            return file;
        }

        public static List<string> GetMoveDirectionSequence(char piece)
        {
            List<string> sequence;
            switch (piece)
            {
                case 'n': // knight
                    sequence = new List<string>() { "uul", "uur", "rru", "rrd", "ddr", "ddl", "lld", "llu" }; // up up left, up up right, ...
                    break;
                case 'r': // rook
                    sequence = new List<string>() { "u", "r", "d", "l" }; // up, right, down, left
                    break;
                case 'q': // queen
                case 'k': // king
                    sequence = new List<string>() { "u", "ur", "r", "rd", "d", "dl", "l", "lu" }; // up, up right, right, right down, ...
                    break;
                case 'b': // bishop
                    sequence = new List<string>() { "ur", "rd", "dl", "lu" }; // up right, right down, down left, left up
                    break;
                case 'p': // pawn
                    sequence = new List<string>() { "u", "uu", "ul", "ur" }; // up, up up, up left, up right
                    break;

                default:
                    sequence = new List<string>();
                    break;
            }

            return sequence;
        }

        public static void GetEndPosition(int file, int rank, string sequence, out int targetFile, out int targetRank, out bool valid)
        {
            targetFile = file;
            targetRank = rank;

            for (int i = 0; i < sequence.Length; i++)
            {
                char direction = sequence[i];
                switch (direction)
                {
                    case 'u':
                        targetRank++;
                        break;
                    case 'r':
                        targetFile++;
                        break;
                    case 'd':
                        targetRank--;
                        break;
                    case 'l':
                        targetFile--;
                        break;
                    default:
                        break;
                }
            }

            valid = targetFile >= 1 && targetFile <= 8 &&
                    targetRank >= 1 && targetRank <= 8;
        }
    }
}