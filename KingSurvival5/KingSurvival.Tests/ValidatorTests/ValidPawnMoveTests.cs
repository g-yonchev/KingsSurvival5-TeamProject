namespace KingSurvival.Tests.ValidatorTests
{
    using KingSurvival.GameLogic.Commons;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ValidPawnMoveTests
    {
        [TestMethod]
        public void MethodShouldReturnsTrueWhenIsPassedValidPawnMoveAdlCommand()
        {
            var expected = Validator.IsValidPawnMove("adl");
            Assert.IsTrue(expected);
        }

        [TestMethod]
        public void MethodShouldReturnsTrueWhenIsPassedValidPawnMoveBdrCommand()
        {
            var expected = Validator.IsValidPawnMove("bdr");
            Assert.IsTrue(expected);
        }

        [TestMethod]
        public void MethodShouldReturnsFalseWhenIsPassedInvalidPawnMove()
        {
            var expected = Validator.IsValidPawnMove("Invalid");
            Assert.IsFalse(expected);
        }
    }
}
