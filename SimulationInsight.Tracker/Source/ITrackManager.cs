using SimulationInsight.Core;

namespace SimulationInsight.Tracker;

public interface ITrackManager : IExecutableModel
{
    List<Track> Tracks
    {
        get;
        set;
    }

    void ProcessTargetReports();

    void PredictTracks(double time);

    void SendSmoothedTracksMessage();

    void SendPredictedTracksMessage();

    void DeleteAllTracks();

    void DeleteTrack(int trackId);
}