using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SimulationInsight.MathLibrary.Tests
{
    [TestClass]
    public class VectorTests
    {
        [TestMethod]
        public void VectorTest1()
        {
            // Arrange:
            var numberOfElements = 6;

            var v = new Vector(numberOfElements);

            // Act:

            // Assert:
            Assert.AreEqual(numberOfElements, v.NumberOfElements);
        }

        [TestMethod]
        public void VectorTest2()
        {
            // Arrange:
            var numberOfElements = 10;

            var v = new Vector(numberOfElements);

            // Act:

            // Assert:
            Assert.AreEqual(numberOfElements, v.NumberOfElements);
        }

        [TestMethod]
        public void VectorTest3()
        {
            // Arrange:
            var numberOfElements = 12;

            var v = new Vector(numberOfElements);

            // Act:

            // Assert:
            Assert.AreEqual(numberOfElements, v.NumberOfElements);
        }

        [TestMethod]
        public void VectorTest4()
        {
            // Arrange:
            var v = new Vector(1.0, 2.0, 11.0, 21.0);

            var expectedResult = 2.0;

            // Act:
            var x = v.GetCircularValue(5);

            // Assert:
            Assert.AreEqual(expectedResult, x);
        }
    }
}