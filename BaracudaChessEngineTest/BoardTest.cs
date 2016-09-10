﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BaracudaChessEngine;

namespace BaracudaChessEngineTest
{
    [TestClass]
    public class BoardTest
    {
        [TestMethod]
        public void GetSetPieceTest_WhenSetPieceRookToD8_ThenGetPieceD8ShouldReturnRook()
        {
            var target = new Board();
            target.SetPiece('R', 4, 8);
            char piece = target.GetPiece('d', 8);
            Assert.AreEqual('R', piece);
        }

        [TestMethod]
        public void GetSetPieceTest_WhenSetPieceRookTo48_ThenGetPiece48ShouldReturnRook()
        {
            var target = new Board();
            target.SetPiece('R', 4, 8);
            char piece = target.GetPiece(4, 8);
            Assert.AreEqual('R', piece);
        }

        [TestMethod]
        public void GetPiece_WhenNewBoard_ThenAllPositionsEmpty()
        {
            var target = new Board();
            char piece = target.GetPiece('d', 8);
            Assert.AreEqual(Definitions.EmptyField, piece);
        }

        [TestMethod]
        public void InitPosition_WhenInitializedPosition_ThenPiecesAtInitPosition()
        {
            var target = new Board();
            target.SetInitialPosition();

            Assert.AreEqual('R', target.GetPiece('a', 1));
            Assert.AreEqual('N', target.GetPiece('b', 1));
            Assert.AreEqual('B', target.GetPiece('c', 1));
            Assert.AreEqual('Q', target.GetPiece('d', 1));
            Assert.AreEqual('K', target.GetPiece('e', 1));
            Assert.AreEqual('B', target.GetPiece('f', 1));
            Assert.AreEqual('N', target.GetPiece('g', 1));
            Assert.AreEqual('R', target.GetPiece('h', 1));

            Assert.AreEqual('P', target.GetPiece('b', 2)); // white pawn
            Assert.AreEqual(Definitions.EmptyField, target.GetPiece('c', 3)); // empty
            Assert.AreEqual(Definitions.EmptyField, target.GetPiece('d', 4)); // empty
            Assert.AreEqual(Definitions.EmptyField, target.GetPiece('e', 5)); // empty
            Assert.AreEqual(Definitions.EmptyField, target.GetPiece('f', 6)); // empty
            Assert.AreEqual('p', target.GetPiece('g', 7)); // black pawn

            Assert.AreEqual('r', target.GetPiece('a', 8));
            Assert.AreEqual('n', target.GetPiece('b', 8));
            Assert.AreEqual('b', target.GetPiece('c', 8));
            Assert.AreEqual('q', target.GetPiece('d', 8));
            Assert.AreEqual('k', target.GetPiece('e', 8));
            Assert.AreEqual('b', target.GetPiece('f', 8));
            Assert.AreEqual('n', target.GetPiece('g', 8));
            Assert.AreEqual('r', target.GetPiece('h', 8));

            Assert.AreEqual(-1, target.EnPassantField);
            Assert.AreEqual(true, target.CastlingRightFirstMover); // white
            Assert.AreEqual(true, target.CastlingRightSecondMover); // black
        }

        [TestMethod]
        public void MoveTest_WhenPawnMovesNormal_ThenNewPositionOk()
        {
            var target = new Board();
            target.SetInitialPosition();

            target.Move('e', 2, 'e', 4);
            Assert.AreEqual(Definitions.EmptyField, target.GetPiece('e', 2));
            Assert.AreEqual('P', target.GetPiece('e', 4));
        }

        [TestMethod]
        public void MoveTest_WhenQueenCapturesPiece_ThenNewPositionOk()
        {
            var target = new Board();
            target.SetInitialPosition();
            target.SetPiece(Definitions.EmptyField, 'd', 2);
            
            target.Move('d', 1, 'd', 7);
            Assert.AreEqual(Definitions.EmptyField, target.GetPiece('d', 1));
            Assert.AreEqual('Q', target.GetPiece('d', 7));

            var moveList = target.Moves;
            Assert.AreEqual(1, target.Moves.Count);
            Assert.AreEqual(new Move(4, 1, 4, 7, 'p'), target.Moves[0]);
        }

        [TestMethod]
        public void GetColorTest()
        {
            var target = new Board();
            target.SetInitialPosition();
            Assert.AreEqual(Definitions.ChessColor.White, target.GetColor(5, 2));
            Assert.AreEqual(Definitions.ChessColor.Empty, target.GetColor(5, 3));
            Assert.AreEqual(Definitions.ChessColor.Black, target.GetColor(5, 7));
            Assert.AreEqual(Definitions.ChessColor.Empty, target.GetColor(5, 5));
        }
    }
}