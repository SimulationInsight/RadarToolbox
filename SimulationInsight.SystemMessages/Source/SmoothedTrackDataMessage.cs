namespace SimulationInsight.SystemMessages;

public class SmoothedTrackDataMessage : SystemMessage
{
    public SmoothedTrackDataMessage()
    {
        MessageType = SystemMessageType.SmoothedTrack;
    }

    public List<SmoothedTrackData> PredictedTracks
    {
        get; set;
    }
}