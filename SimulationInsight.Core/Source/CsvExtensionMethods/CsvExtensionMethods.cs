using CsvHelper;
using CsvHelper.TypeConversion;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace SimulationInsight.Core
{
    public static class CsvExtensionMethods
    {
        public static void WriteToCsvFile<T>(this IEnumerable<T> records, string path)
        {
            Logger.Information($"      Writing {path}");

            using var writer = new StreamWriter(path);

            var csv = new CsvWriter(writer, CultureInfo.CurrentCulture);

            var options = new TypeConverterOptions { Formats = new[] { "dd/MM/yyyy hh:mm:ss.fff" } };

            csv.Context.TypeConverterOptionsCache.AddOptions<DateTime>(options);

            csv.WriteRecords(records);
        }

        public static List<T> ReadFromCsvFile<T>(string path)
        {
            Logger.Information($"      Reading {path}");

            using var reader = new StreamReader(path);
            using var csv = new CsvReader(reader, CultureInfo.CurrentCulture);

            var data = csv.GetRecords<T>().ToList();

            return data;
        }
    }
}