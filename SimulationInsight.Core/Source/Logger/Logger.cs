namespace SimulationInsight.Core
{
    public static class Logger
    {
        public static void Information(string messageTemplate)
        {
            Serilog.Log.Logger.Information(messageTemplate);
        }

        public static void Warning(string messageTemplate)
        {
            Serilog.Log.Logger.Warning(messageTemplate);
        }

        public static void Error(string messageTemplate)
        {
            Serilog.Log.Logger.Error(messageTemplate);
        }

        public static void CloseAndFlush()
        {
            Serilog.Log.CloseAndFlush();
        }
    }
}