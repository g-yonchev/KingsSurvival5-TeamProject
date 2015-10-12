namespace KingSurvival.Tests.ValidatorTests
{
    using System;

    using KingSurvival.GameLogic.Commons;
    using KingSurvival.GameLogic.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PositionOnTheBoardTests
    {
        [TestMethod]
        public void MethodShoudReturnsTrueWhenIsPassedValidPosition()
        {
            var position = new Position(4, 4);
            var expected = Validator.IsPositionOnTheBoard(position);
            Assert.IsTrue(expected);
        }

        [TestMethod]
        public void MethodShoudReturnsFalseWhenIsPassedInvalidPositionWithPositiveCoordinates()
        {
            var position = new Position(100, 100);
            var expected = Validator.IsPositionOnTheBoard(position);
            Assert.IsFalse(expected);
        }
    }
}
