namespace KingSurvival.Tests.Enginetests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using KingSurvival.GameLogic.Commons;
    using KingSurvival.GameLogic.Engine;

    [TestClass]
    public class IsOnBoardTest
    {
        [TestMethod]
        public void MethodShouldReturnsTrueIfPassedValidRowAndCol()
        {
            var engine = new Engine();
            var actual = engine.IsOnBoard(2, 2);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void MethodShouldReturnsTrueIfPassedZeroRowAndCol()
        {
            var engine = new Engine();
            var actual = engine.IsOnBoard(GameConstants.MinNumberOfRows, GameConstants.MinNumberOfCols);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void MethodShouldReturnsTrueIfPassedMaxRowAndCol()
        {
            var engine = new Engine();
            var actual = engine.IsOnBoard(GameConstants.BoardRows - 1, GameConstants.BoardCols - 1);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void MethodShouldReturnsFalseIfPassedNegativeRowAndCol()
        {
            var engine = new Engine();
            var actual = engine.IsOnBoard(-2, -2);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void MethodShouldReturnsFalseIfPassedPositiveLargeRowAndCol()
        {
            var engine = new Engine();
            var actual = engine.IsOnBoard(100, 100);
            Assert.IsFalse(actual);
        }
    }
}
