﻿//using System;
//using MantaChessEngine;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace MantaChessEngineTest
//{
//    [TestClass]
//    public class SearchServiceDepthHalfTest
//    {
//        [TestMethod]
//        public void SearchTest_WhenWhenQueenCanBeCaptured_ThenCaptureQueen_White()
//        {
//            IEvaluator evaluator = new EvaluatorSimple();
//            MoveGenerator gen = new MoveGenerator(new MoveFactory());
//            ISearchService target = new SearchServiceDepthHalfMove(evaluator, gen);
//            var board = new Board();
//            string boardString = "rnb.kbnr" +
//                                 "ppp.pppp" +
//                                 "........" +
//                                 "....q..." +
//                                 "...p.P.." +
//                                 "........" +
//                                 "PPPPP.PP" +
//                                 "RNBQKBNR";
//            board.SetPosition(boardString);

//            float score = 0;
//            IMove actualMove = target.Search(board, Definitions.ChessColor.White, out score);
//            IMove expectedMove = new NormalMove(Piece.MakePiece('P'), 'f', 4, 'e', 5, Piece.MakePiece('q'));
//            Assert.AreEqual(expectedMove, actualMove, "Queen should be captured.");
//        }

//        [TestMethod]
//        public void SearchTest_WhenWhenQueenCanBeCaptured_ThenCaptureQueen_Black()
//        {
//            IEvaluator evaluator = new EvaluatorSimple();
//            MoveGenerator gen = new MoveGenerator(new MoveFactory());
//            ISearchService target = new SearchServiceDepthHalfMove(evaluator, gen);
//            var board = new Board();
//            string boardString = "rnbqkbnr" +
//                                 "pppp.ppp" +
//                                 "........" +
//                                 "...Pp..." +
//                                 "...Q...." +
//                                 "........" +
//                                 "PPP.PPPP" +
//                                 "RNB.KBNR";
//            board.SetPosition(boardString);

//            float score = 0;
//            IMove actualMove = target.Search(board, Definitions.ChessColor.Black, out score);
//            IMove expectedMove = new NormalMove(Piece.MakePiece('p'), 'e', 5, 'd', 4, Piece.MakePiece('Q'));
//            Assert.AreEqual(expectedMove, actualMove, "Queen should be captured.");
//        }
//    }
//}
