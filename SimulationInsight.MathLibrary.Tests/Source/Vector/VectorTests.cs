namespace SimulationInsight.MathLibrary.Tests
{
    [TestClass]
    public class VectorTests
    {
        [DataTestMethod]
        [DataRow(new double[] { }, true)]
        [DataRow(new double[] { 1 }, true)]
        [DataRow(new double[] { 1, 2 }, true)]
        [DataRow(new double[] { 1, 2, 2 }, true)]
        [DataRow(new double[] { 1, 2, 4 }, true)]
        [DataRow(new double[] { 1, 0 }, false)]
        [DataRow(new double[] { 1, 3, 2 }, false)]
        public void IsMonotonicallyIncreasing(double[] data, bool expectedResult)
        {
            // Arrange:
            var x = new Vector(data);

            // Act:
            var isMonotonicallyIncreasing = x.IsMonotonicallyIncreasing();

            // Assert:
            Assert.AreEqual(expectedResult, isMonotonicallyIncreasing);
        }
    }
}