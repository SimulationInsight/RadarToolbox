using CsvHelper;
using System.Globalization;

namespace SimulationInsight.Core;

public static class CsvExtensionMethods
{
    public static void WriteToCsvFile<T>(this List<T> data, string path)
    {
        using var writer = new StreamWriter(path);

        using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);

        csv.WriteRecords(data);
    }
}