using System.Linq.Expressions;

namespace SimulationInsight.Core.Tests;

[TestClass]
public class FixedTimeStepClockTests
{
    [TestMethod]
    public void StepClock()
    {
        // Arrange:
        var c = new FixedTimeStepClock()
        {
            TimeStep = 0.1
        };

        var initialTime = 0.15;
        var finalTime = 11.99;

        var expectedTime = 11.9;

        c.Initialise(initialTime);

        // Act:
        while (c.IsStepClock(finalTime))
        {
            c.StepClock();
        }

        // Assert:
        Assert.AreEqual(expectedTime, c.CurrentTime);
    }
}