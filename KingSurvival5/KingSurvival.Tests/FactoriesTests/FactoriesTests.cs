namespace KingSurvival.Tests.FactoriesTests
{
    using KingSurvival.GameLogic.Models;
    using KingSurvival.GameLogic.Models.Factories;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FactoriesTests
    {
        [TestMethod]
        public void CreateFigureMethodTesterForKing()
        {
            var kingFactory = new KingFactory();
            var king = kingFactory.CreateFigure('K', new Position(1, 1));
            Assert.IsTrue(king is King);
        }

        [TestMethod]
        public void CreateFigureMethodTesterForPawn()
        {
            var pawnFactory = new PawnFactory();
            var king = pawnFactory.CreateFigure('A', new Position(2, 2));
            Assert.IsTrue(king is Pawn);
        }
    }
}
