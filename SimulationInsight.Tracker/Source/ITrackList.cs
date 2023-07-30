namespace SimulationInsight.Tracker;

public interface ITrackList
{
    List<Track> Tracks
    {
        get;
        set;
    }

    int NumberOfTracks
    {
        get;
    }

    void DeleteAllTracks();

    void DeleteTrack(int trackId);
}