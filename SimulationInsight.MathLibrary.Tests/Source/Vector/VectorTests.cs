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
    }
}
