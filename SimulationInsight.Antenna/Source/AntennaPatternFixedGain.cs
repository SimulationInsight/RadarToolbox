namespace SimulationInsight.Antenna.Source
{
    public class AntennaPatternFixedGain : AntennaPattern
    {
        public double Gain_dB { get; set; }

        public AntennaPatternFixedGain()
        {
            AntennaPatternType = AntennaPatternType.FixedGain;
        }

        public override double GetAntennaGain_dB(double azimuthAngleDeg, double elevationAngleDeg)
        {
            return Gain_dB;
        }
    }
}