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
    }
}
