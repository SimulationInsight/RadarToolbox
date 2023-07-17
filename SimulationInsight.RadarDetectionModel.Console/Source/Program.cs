using SimulationInsight.Core;
using SimulationInsight.RadarLibrary;

namespace SimulationInsight.RadarDetectionModel;

public class Program
{
    public static string InputFileName { get; set; }

    public static string OutputFileName { get; set; }

    public static bool IsCreateExampleFiles { get; set; }

    public static RadarDetectionModelHarnessInputs Inputs { get; set; }

    public static RadarDetectionModelHarness Harness { get; set; }

    /// <summary>
    ///
    /// </summary>
    /// <param name="inputFileName">Input file name. Full path. Default extension is .json.rdmi</param>
    /// <param name="outputFileName">Output file name. Full path. Default extension is .csv</param>
    /// <param name="isCreateExampleFiles">If true, creates a new example input file showing the required format.</param>
    public static void Main(string inputFileName, string outputFileName, bool isCreateExampleFiles = false)
    {
        InputFileName = inputFileName;
        OutputFileName = outputFileName;
        IsCreateExampleFiles = isCreateExampleFiles;

        CreateLogger();

        DisplaySettings();

        if (IsCreateExampleFiles)
        {
            WriteInputFile();
        }

        ReadInputFile();

        if (Inputs is null)
        {
            return;
        }

        Run();

        WriteOutputFile();

        Logger.Information($"Finished.");
    }

    private static void CreateLogger()
    {
        var logFileName = @"C:\temp\RadarToolbox\RadarDetectionModel\RadarDetectionModel.log";

        Logger.Initialise(logFileName);
    }

    private static void DisplaySettings()
    {
        Logger.Information("RadarDetectionModel");
        Logger.Information($"");
        Logger.Information($"   Settings");
        Logger.Information($"      InputFileName        = {InputFileName}");
        Logger.Information($"      OutputFileName       = {OutputFileName}");
        Logger.Information($"      IsCreateExampleFiles = {IsCreateExampleFiles}");
        Logger.Information($"   End Of Settings.");
        Logger.Information($"");
    }

    private static void WriteInputFile()
    {
        Logger.Information($"   Writing Input File...");

        Inputs = RadarDetectionModelHarnessInputExamples.Example_1();

        Inputs.WriteToJsonFile(InputFileName);

        Logger.Information($"   Finished.");
        Logger.Information($"");
    }

    private static void ReadInputFile()
    {
        Logger.Information($"   Reading Input File...");

        if (string.IsNullOrEmpty(InputFileName))
        {
            Logger.Error($"      Input file name must not be empty.");
            return;
        }

        if (!File.Exists(InputFileName))
        {
            Logger.Error($"      Input file does not exist: {InputFileName}");
            return;
        }

        Inputs = JsonExtensionMethods.ReadFromJsonFile<RadarDetectionModelHarnessInputs>(InputFileName);

        Logger.Information($"   Finished.");
        Logger.Information($"");
    }

    private static void Run()
    {
        Logger.Information($"   Running...");

        Harness = new RadarDetectionModelHarness()
        {
            RadarDetectionModelHarnessInputs = Inputs
        };

        Harness.Run();

        Logger.Information($"   Finished.");
        Logger.Information($"");
    }

    private static void WriteOutputFile()
    {
        Logger.Information($"   Writing Output File...");

        Harness.RadarDetectionModelData.WriteToCsvFile(OutputFileName);

        Logger.Information($"   Finished.");
        Logger.Information($"");
    }
}