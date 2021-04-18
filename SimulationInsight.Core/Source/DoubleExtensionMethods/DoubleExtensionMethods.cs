namespace SimulationInsight.Core
{
    public static class DoubleExtensionMethods
    {
        public static double GetCircularValue(this double[] data, int index)
        {
            var i = index % data.Length;

            var x = data[i];

            return x;
        }
    }
}