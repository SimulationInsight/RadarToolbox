namespace SimulationInsight.SystemMessages;

public class PredictedTrackDataMessage : SystemMessage
{
    public PredictedTrackDataMessage()
    {
        MessageType = SystemMessageType.PredictedTrack;
        PredictedTracks = [];
    }

    public List<PredictedTrackData> PredictedTracks
    {
        get; set;
    }
}