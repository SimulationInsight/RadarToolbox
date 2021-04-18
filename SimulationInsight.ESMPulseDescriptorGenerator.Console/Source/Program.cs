using SimulationInsight.Core;
using System.Diagnostics;

namespace SimulationInsight.ESMPulseDescriptorGenerator.Console
{
    internal class Program
    {
        private static string InputFileName { get; set; }

        private static string OutputFileName { get; set; }

        private static string LogFileName { get; set; }

        /// <summary>
        /// ESMPulseDescriptorGenerator.
        /// </summary>
        /// <param name="inputFileName">Input File Name.</param>
        /// <param name="outputFileName">Output File Name.</param>
        /// <param name="logFileName">Log File Name.</param>
        public static void Main(string inputFileName, string outputFileName, string logFileName)
        {
            InputFileName = inputFileName;
            OutputFileName = outputFileName;
            LogFileName = logFileName;

            SetFileNames();

            Run();
        }

        private static void SetFileNames()
        {
            if (string.IsNullOrEmpty(OutputFileName))
            {
                OutputFileName = @"C:\Temp\ESMPulseDescriptorGenerator\ESMPulseDescriptors.csv";
            }

            if (string.IsNullOrEmpty(LogFileName))
            {
                LogFileName = @"C:\Temp\ESMPulseDescriptorGenerator\ESMPulseDescriptorGenerator.log";
            }
        }

        private static void Run()
        {
            Logger.Initialise(LogFileName);

            var i = ESMPulseDescriptorGeneratorInputsFactory.Example_1();

            var e = new ESMPulseDescriptorGenerator()
            {
                ESMPulseDescriptorGeneratorInputs = i
            };

            Logger.Information("Running ESMPulseDescriptorGenerator");
            Logger.Information($"   InputFileName  = {InputFileName}");
            Logger.Information($"   OutputFileName = {OutputFileName}");
            Logger.Information($"   LogFileName    = {LogFileName}");
            Logger.Information("");
            Logger.Information($"Starting...");
            Logger.Information("");

            Logger.Information($"   Generating Data...");
            var sw = Stopwatch.StartNew();
            e.GeneratePulseDescriptorData();
            Logger.Information($"      Elapsed Time = {sw.ElapsedMilliseconds}ms");
            Logger.Information($"   Finished.");
            Logger.Information("");

            Logger.Information($"   Writing Data...");
            sw.Restart();
            e.WritePulseDescriptorData(OutputFileName);
            Logger.Information($"      Elapsed Time = {sw.ElapsedMilliseconds}ms");
            Logger.Information($"   Finished.");
            Logger.Information("");

            Logger.Information($"Finished.");

            Logger.Close();
        }
    }
}