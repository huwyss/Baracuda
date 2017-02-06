﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaracudaChessEngine
{
    public enum EngineType
    {
        Random,
        DepthOne
    }

    public class BaracudaEngine
    {
        private Board _board;
        private MoveGenerator _moveGenerator;
        private ISearchService _search;
        private IEvaluator _evaluator;
        
        public BaracudaEngine(EngineType engineType)
        {
            if (engineType == EngineType.Random)
            {
                _moveGenerator = new MoveGenerator();
                _board = new Board(_moveGenerator);
                _moveGenerator.SetBoard(_board);
                _evaluator = new EvaluatorSimple();
                _search = new SearchRandom();
            }
            else if (engineType == EngineType.DepthOne)
            {
                //_moveGenerator = new MoveGenerator();
                //_board = new Board(_moveGenerator);
                //_moveGenerator.SetBoard(_board);
                //_evaluator = new EvaluatorSimple();
                //_search = new SearchServiceDepthOne(_evaluator);
            }
        }

        public void SetInitialPosition()
        {
            _board.SetInitialPosition();
        }

        public string GetPrintString()
        {
            return _board.GetPrintString();
        }

        public bool Move(string moveStringUser)
        {
            Move syntaxCorrectMove = _board.GetValidMove(moveStringUser);
            bool valid = _board.IsMoveValid(syntaxCorrectMove);
            if (valid)
            {
                _board.Move(syntaxCorrectMove);
            }

            return valid;
        }

        public bool Move(Move move)
        {
            _board.Move(move);
            return true;
        }

        public bool IsWinner(Definitions.ChessColor color)
        {
            return _board.IsWinner(color);
        }

        public Move DoBestMove(Definitions.ChessColor color)
        {
            Move nextMove = _search.Search(_board, color);
            _board.Move(nextMove);
            return nextMove;

            var possibleMovesComputer = GetAllMoves(color);
            int numberPossibleMoves = possibleMovesComputer.Count;
            
            if (numberPossibleMoves > 0)
            {
                //int randomMoveIndex = _rand.Next(0, numberPossibleMoves - 1);
                //nextMove = possibleMovesComputer[randomMoveIndex];
                _board.Move(nextMove);
            }

            return nextMove;
        }

        private List<Move> GetAllMoves(Definitions.ChessColor color)
        {
            return _board.GetAllMoves(color);
        }

        public Definitions.ChessColor SideToMove()
        {
            return _board.SideToMove;
        }
    }
}
