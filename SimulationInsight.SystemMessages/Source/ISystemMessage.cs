namespace SimulationInsight.SystemMessages
{
    public interface ISystemMessage
    {
        SystemMessageType MessageType
        {
            get;
        }

        int MessageOriginId
        {
            get; set;
        }

        int MessageId
        {
            get; set;
        }

        double MessageTime
        {
            get; set;
        }
    }
}