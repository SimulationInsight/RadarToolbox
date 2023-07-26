using System.Linq;

namespace SimulationInsight.MathLibrary.Tests
{
    [TestClass]
    public class Interpolation1DTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Interpolate_WithZeroElements_ExpectException()
        {
            // Arrange:
            var x = new Vector();
            var y = new Vector();

            // Act:
            var interpolation = new Interpolation1D(x, y);

            // Assert:
            Assert.Fail();
        }

        [TestMethod]
        public void Interpolate_WithSingleElement_ExpectSuccess()
        {
            // Arrange:
            var x = new Vector(1.0);
            var y = new Vector(10.0);

            var xi = 2.0;

            var yiExpected = 10.0;

            var interpolation = new Interpolation1D(x, y);

            // Act:
            var yi = interpolation.Interpolate(xi);

            // Assert:
            Assert.AreEqual(yiExpected, yi);
        }

        [DataTestMethod]
        [DataRow(0.5, 10.0)]
        [DataRow(1.0, 10.0)]
        [DataRow(1.2, 12.0)]
        [DataRow(2.0, 20.0)]
        [DataRow(3.0, 20.0)]
        public void Interpolate_WithTwoElements_ExpectSuccess(double xi, double yiExpected)
        {
            // Arrange:
            var x = new Vector(1.0, 2.0);
            var y = new Vector(10.0, 20.0);

            var interpolation = new Interpolation1D(x, y);

            // Act:
            var yi = interpolation.Interpolate(xi);

            // Assert:
            Assert.AreEqual(yiExpected, yi);
        }

        [DataTestMethod]
        [DataRow(0.5, 10.0)]
        [DataRow(1.0, 10.0)]
        [DataRow(1.2, 10.8)]
        [DataRow(1.5, 12.0)]
        [DataRow(1.7, 15.2)]
        [DataRow(2.0, 20.0)]
        [DataRow(3.0, 20.0)]
        public void Interpolate_WithThreeElements_ExpectSuccess(double xi, double yiExpected)
        {
            // Arrange:
            var x = new Vector(1.0, 1.5, 2.0);
            var y = new Vector(10.0, 12.0, 20.0);

            var interpolation = new Interpolation1D(x, y);

            // Act:
            var yi = interpolation.Interpolate(xi);

            // Assert:
            Assert.AreEqual(yiExpected, yi);
        }

        [TestMethod]
        public void Interpolate_WithVector_ExpectSuccess()
        {
            // Arrange:
            var x = new Vector(1.0, 1.5, 2.0);
            var y = new Vector(10.0, 12.0, 20.0);

            var xi = new Vector(0.5, 1.0, 1.2, 1.5, 1.7, 2.0, 3.0);
            var yiExpected = new Vector(10.0, 10.0, 10.8, 12.0, 15.2, 20.0, 20.0);

            var interpolation = new Interpolation1D(x, y);

            // Act:
            var yi = interpolation.Interpolate(xi);

            // Assert:
            var areEqual = yiExpected.Data.SequenceEqual(yi.Data);

            Assert.IsTrue(areEqual);
        }
    }
}