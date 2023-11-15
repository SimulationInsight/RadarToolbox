using SimulationInsight.MathLibrary;
using SimulationInsight.SystemMessages;
using Wolverine;

namespace SimulationInsight.Radar;

public class PulseGenerator : IPulseGenerator
{
    public TransmitPulseData TransmitPulseData
    {
        get; set; 
    } 

    public IMessageBus Bus
    {
        get; set;
    }

    public int TransmitPulseDataMessageId
    {
        get; set;
    }

    public PulseGenerator(IMessageBus bus)
    {
        Bus = bus;

        TransmitPulseData = new TransmitPulseData();
    }

    public void Initialise(double time)
    {
        TransmitPulseData = TransmitPulseData with { TransmitPulseTime = time };
    }

    public void Update(double time)
    {
        TransmitPulseData = TransmitPulseData with { TransmitPulseTime = time };

        SendTransmitPulseDataMessage();
    }

    public void SendTransmitPulseDataMessage()
    {
        TransmitPulseDataMessageId++;

        var message = new TransmitPulseDataMessage()
        {
            MessageId = TransmitPulseDataMessageId,
            MessageTime = TransmitPulseData.TransmitPulseTime,
            TransmitPulseData = TransmitPulseData
        };

        Bus.PublishAsync(message);
    }

    public void Finalise(double time)
    {
    }
}