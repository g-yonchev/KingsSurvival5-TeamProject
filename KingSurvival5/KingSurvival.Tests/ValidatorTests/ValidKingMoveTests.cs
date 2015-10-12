namespace KingSurvival.Tests.ValidatorTests
{
    using KingSurvival.GameLogic.Commons;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ValidKingMoveTests
    {
        [TestMethod]
        public void MethodShouldReturnsTrueWhenIsPassedValidKingMoveKurCommand()
        {
            var expected = Validator.IsValidKingMove("KUR");
            Assert.IsTrue(expected);
        }

        [TestMethod]
        public void MethodShouldReturnsFalseWhenIsPassedInvalidKingMove()
        {
            var expected = Validator.IsValidKingMove("Invalid");
            Assert.IsFalse(expected);
        }
    }
}
