using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfLife.BusinessObjects;
using GameOfLife.Contracts;
using System.Collections.Generic;
using GameOfLife.BusinessObjects;

namespace Tests
{
    [TestClass]
    public class BoardTest
    {
        private IBoard board = new Board(5, 5);

        [TestMethod]
        public void BoardGetNeighborTestCorners()
        {
            //in a 5X5 board we are testing for 4 Corner cells. TopLeft, TopRight, BottomLeft, BottomRight
            //total of 3 neighbors will be returned.

            //row/ col indices of the 4 test cells
            int[] testCellRowIndices = { 0, 0, 4, 4 };
            int[] testCellColIndices = { 0, 4, 0, 4 };

            // two dimensional array of row indices of test cell's neighbors. First row contains row indices of the first test cell and so on. Same for colIndices
            int[][] rowIndices = new int[][] { new int[] { 0, 1, 1 }, new int[] { 0, 1, 1 }, new int[] { 3, 3, 4 }, new int[] { 3, 3, 4 } };
            int[][] colIndices = new int[][] { new int[] { 1, 0, 1 }, new int[] { 3, 3, 4 }, new int[] { 0, 1, 1 }, new int[] { 3, 4, 3 } };

            for (int testCellIndex = 0; testCellIndex < 4; testCellIndex++) //Loop through the test cells
            {
                List<ICell> cellList = board.GetNeighbors(board[testCellRowIndices[testCellIndex], testCellColIndices[testCellIndex]]);
                Assert.AreEqual<int>(cellList.Count, 3);

                for (int rowColIndex = 0; rowColIndex < 3; rowColIndex++) //Loops through the neighbors
                {
                    Assert.AreEqual<int>(cellList[rowColIndex].Row, rowIndices[testCellIndex][rowColIndex]); // compares the row index of neighobors
                    Assert.AreEqual<int>(cellList[rowColIndex].Column, colIndices[testCellIndex][rowColIndex]); // compares the col index of neighobors
                }
            }
        }
        [TestMethod]
        public void BoardGetNeighborTestEdges()
        {
            //in a 5X5 board we are testing for 4 edge cells. Topedge, RightEdge, BottomEdge, LeftEdge
            //total of 5 neighbors will be returned.

            //row/ col indices of the 4 test cells
            int[] testCellRowIndices = { 0, 2, 4, 2 };
            int[] testCellColIndices = { 2, 4, 2, 0 };

            // two dimensional array of row indices of test cell's neighbors. First row contains row indices of the first test cell and so on. Same for colIndices
            int[][] rowIndices = new int[][] { new int[] { 0, 0, 1, 1, 1 }, new int[] { 1, 1, 2, 3, 3 }, new int[] { 3, 3, 3, 4, 4 }, new int[] { 1, 1, 2, 3, 3 } };
            int[][] colIndices = new int[][] { new int[] { 1, 3, 1, 2, 3 }, new int[] { 3, 4, 3, 3, 4 }, new int[] { 1, 2, 3, 1, 3 }, new int[] { 0, 1, 1, 0, 1 } };

            for (int testCellIndex = 0; testCellIndex < 4; testCellIndex++) //Loop through the test cells
            {
                List<ICell> cellList = board.GetNeighbors(board[testCellRowIndices[testCellIndex], testCellColIndices[testCellIndex]]);
                Assert.AreEqual<int>(cellList.Count, 5);

                for (int rowColIndex = 0; rowColIndex < 5; rowColIndex++) //Loops through the neighbors
                {
                    Assert.AreEqual<int>(cellList[rowColIndex].Row, rowIndices[testCellIndex][rowColIndex]); // compares the row index of neighobors
                    Assert.AreEqual<int>(cellList[rowColIndex].Column, colIndices[testCellIndex][rowColIndex]); // compares the col index of neighobors
                }
            }
        }
        [TestMethod]
        public void BoardGetNeighborTestCenterCell()
        {
            //in a 5X5 board this test will test the neighbors of the cell 2, 2 (Third row, third column)
            //total of 8 neighbors will be returned.

            // row/ col indices of the neighbors
            int[] rowIndices = { 1, 1, 1, 2, 2, 3, 3, 3 };
            int[] colIndices = { 1, 2, 3, 1, 3, 1, 2, 3 };

            List<ICell> cellList = board.GetNeighbors(board[2, 2]);
            Assert.AreEqual<int>(cellList.Count, 8); // compares the count of neighobors

            for (int rowColIndex = 0; rowColIndex < 8; rowColIndex++)
            {
                Assert.AreEqual<int>(cellList[rowColIndex].Row, rowIndices[rowColIndex]); // compares the row index of neighobors
                Assert.AreEqual<int>(cellList[rowColIndex].Column, colIndices[rowColIndex]); // compares the col index of neighobors
            }
        }

        [TestMethod]
        public void TickTest()
        {
            board[0, 1].Alive = true;
            board[1, 2].Alive = true;
            board[2, 0].Alive = true;
            board[2, 1].Alive = true;
            board[2, 2].Alive = true;

            IBoardTicker boardTicker = new BoardTicker(board);
            board = boardTicker.Tick();

            Assert.IsFalse(board[0, 1].Alive);
            Assert.IsTrue(board[1, 0].Alive);
            Assert.IsFalse(board[1, 1].Alive);
            Assert.IsTrue(board[1, 2].Alive);
            Assert.IsFalse(board[2, 0].Alive);
            Assert.IsTrue(board[2, 1].Alive);
            Assert.IsTrue(board[2, 2].Alive);
            Assert.IsFalse(board[3, 0].Alive);
            Assert.IsTrue(board[3, 1].Alive);
            Assert.IsFalse(board[3, 2].Alive);

            board = boardTicker.Tick();

            Assert.IsFalse(board[1, 0].Alive);
            Assert.IsFalse(board[1, 1].Alive);
            Assert.IsTrue(board[1, 2].Alive);
            Assert.IsTrue(board[2, 0].Alive);
            Assert.IsFalse(board[2, 1].Alive);
            Assert.IsTrue(board[2, 2].Alive);
            Assert.IsFalse(board[3, 0].Alive);
            Assert.IsTrue(board[3, 1].Alive);
            Assert.IsTrue(board[3, 2].Alive);

            board = boardTicker.Tick();
            Assert.IsTrue(board[1, 1].Alive);
            Assert.IsFalse(board[1, 2].Alive);
            Assert.IsFalse(board[1, 3].Alive);
            Assert.IsFalse(board[2, 1].Alive);
            Assert.IsTrue(board[2, 2].Alive);
            Assert.IsTrue(board[2, 3].Alive);
            Assert.IsTrue(board[3, 1].Alive);
            Assert.IsTrue(board[3, 2].Alive);
            Assert.IsFalse(board[3, 3].Alive);
        }
    }
}
