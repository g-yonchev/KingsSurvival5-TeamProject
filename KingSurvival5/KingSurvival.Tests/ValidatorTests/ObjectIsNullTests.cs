namespace KingSurvival.Tests.ValidatorTests
{
    using System;

    using KingSurvival.GameLogic.Commons;
    using KingSurvival.GameLogic.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ObjectIsNullTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void MethodShouldThrowNullReferenceExceptionWhenIsPassedNullObject()
        {
            Validator.CheckIfObjectIsNull(null);
        }

        [TestMethod]
        public void MethodShouldNotThrowNullReferenceExceptionWhenIsPassedValidObject()
        {
            Validator.CheckIfObjectIsNull(new Position(1, 1));
        }
    }
}
