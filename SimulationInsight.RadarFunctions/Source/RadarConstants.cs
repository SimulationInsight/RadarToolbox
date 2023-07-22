namespace SimulationInsight.RadarFunctions;

public static class RadarConstants
{
    public static List<(double frequency_GHz, string ieeeBand)> IeeeBands = new()
    {
            (0.03, "HF"),
            (0.3, "VHF"),
            (1, "UHF"),
            (2, "L"),
            (4, "S"),
            (8, "C"),
            (12, "X"),
            (18, "Ku"),
            (27, "K"),
            (40, "Ka"),
            (75, "V"),
            (110, "W"),
            (300, "mm"),
        };

    public static List<(double frequency_GHz, string natoBand)> NatoBands = new()
    {
            (0.25, "A"),
            (0.5, "B"),
            (1, "C"),
            (2, "D"),
            (3, "E"),
            (4, "F"),
            (6, "G"),
            (8, "H"),
            (10, "I"),
            (20, "J"),
            (40, "K"),
            (60, "L"),
            (100, "M"),
        };
}