using SimulationInsight.SystemMessages;

namespace SimulationInsight.Tracker;

public class TrackManager : ITrackManager
{
    public ITrackManagerSettings TrackManagerSettings
    {
        get;
        set;
    }

    public List<Track> Tracks
    {
        get;
        set;
    }

    public List<PredictedTrackData> PredictedTracks
    {
        get;
        set;
    }

    public int NumberOfTracks => Tracks.Count;

    public TrackManager(ITrackManagerSettings trackManagerSettings)
    {
        TrackManagerSettings = trackManagerSettings;
        Tracks = new List<Track>();
    }

    public void Initialise(double time)
    {
    }

    public void Update(double time)
    {
    }

    public void Finalise(double time)
    {
    }

    public void ProcessTargetReports()
    {
    }

    public void PredictTracks(double time)
    {
        PredictedTracks.Clear();

        foreach (var track in Tracks)
        {
            var predictedTrack = track.PredictTrack(time);

            PredictedTracks.Add(predictedTrack);
        }
    }

    public void SendSmoothedTracksMessage()
    {
    }

    public void SendPredictedTracksMessage()
    {
    }

    public void DeleteAllTracks()
    {
        Tracks.Clear();
    }

    public void DeleteTrack(int trackId)
    {
        var track = Tracks.Where(s => s.TrackId == trackId).First();

        Tracks.Remove(track);
    }
}