using SimulationInsight.SystemMessages;

namespace SimulationInsight.DataRecorder;

public class TransmitPulseParametersMessageHandler
{
    public IDataRecorder DataRecorder
    {
        get; set;
    }

    public TransmitPulseParametersMessageHandler(IDataRecorder dataRecorder)
    {
        DataRecorder = dataRecorder;
    }

    public void Handle(TransmitPulseDataMessage transmitPulseDataMessage)
    {
        DataRecorder.SystemMessages.Add(transmitPulseDataMessage);

        DataRecorder.TransmitPulseDataMessages.Add(transmitPulseDataMessage);
    }
}