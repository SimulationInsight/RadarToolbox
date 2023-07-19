using SimulationInsight.SystemMessages;

namespace SimulationInsight.DataRecorder;

public class AzimuthChangePulseDataMessageHandler
{
    public IDataRecorder DataRecorder { get; set; }

    public AzimuthChangePulseDataMessageHandler(IDataRecorder dataRecorder)
    {
        DataRecorder = dataRecorder;
    }

    public void Handle(AzimuthChangePulseDataMessage azimuthChangePulseDataMessage)
    {
        DataRecorder.SystemMessages.Add(azimuthChangePulseDataMessage);

        DataRecorder.AzimuthChangePulseDataMessages.Add(azimuthChangePulseDataMessage);
    }
}