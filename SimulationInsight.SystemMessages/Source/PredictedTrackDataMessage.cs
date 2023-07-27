namespace SimulationInsight.SystemMessages;

public class PredictedTrackDataMessage : SystemMessage
{
    public PredictedTrackDataMessage()
    {
        MessageType = SystemMessageType.PredictedTrack;
    }

    public List<PredictedTrackData> PredictedTracks
    {
        get; set;
    }
}