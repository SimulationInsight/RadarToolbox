namespace SimulationInsight.SystemMessages;

public class SystemMessage : ISystemMessage
{
    public SystemMessageType MessageType
    {
        get; set;
    }

    public int MessageOriginId
    {
        get; set;
    }

    public int MessageId
    {
        get; set;
    }

    public double MessageTime
    {
        get; set;
    }
}