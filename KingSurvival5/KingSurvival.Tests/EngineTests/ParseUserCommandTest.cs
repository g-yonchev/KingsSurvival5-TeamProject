namespace KingSurvival.Tests.EngineTests
{
    using System;
    
    using KingSurvival.GameLogic.Commons;
    using KingSurvival.GameLogic.Engine;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ParseUserCommandTest
    {
        [TestMethod]
        public void MethodShouldReturnsValidVectorWhenIsPassedULCommand()
        {
            var engine = new Engine();
            var actual = engine.ParseUserCommand("UL");
            var expected = new MovementVector(-1, -1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MethodShouldReturnsValidVectorWhenIsPassedURCommand()
        {
            var engine = new Engine();
            var actual = engine.ParseUserCommand("UR");
            var expected = new MovementVector(-1, 1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MethodShouldReturnsValidVectorWhenIsPassedDLCommand()
        {
            var engine = new Engine();
            var actual = engine.ParseUserCommand("DL");
            var expected = new MovementVector(1, -1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MethodShouldReturnsValidVectorWhenIsPassedDRCommand()
        {
            var engine = new Engine();
            var actual = engine.ParseUserCommand("DR");
            var expected = new MovementVector(1, 1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MethodShouldThrowsArgumentExceptionWhenIsPassedInvalidCommand()
        {
            var engine = new Engine();
            engine.ParseUserCommand("Invalid command");
        }
    }
}
