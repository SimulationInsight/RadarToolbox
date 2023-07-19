using Microsoft.Extensions.Logging;
using SimulationInsight.SystemMessages;
using Wolverine;

namespace SimulationInsight.DataRecorder;

public class SystemMessageHandler
{
    public IDataRecorder DataRecorder { get; set; }

    public SystemMessageHandler(IDataRecorder dataRecorder)
    {
        DataRecorder = dataRecorder;
    }

    public void Handle(ISystemMessage systemMessage, ILogger<SystemMessageHandler> logger)
    {
        DataRecorder.SystemMessages.Add(systemMessage);
    }
}