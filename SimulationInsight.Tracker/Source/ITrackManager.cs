using SimulationInsight.Core;
using SimulationInsight.SystemMessages;

namespace SimulationInsight.Tracker;

public interface ITrackManager : IExecutableModel
{
    List<TargetReport> TargetReports
    {
        get;
        set;
    }

    ITrackList TrackList
    {
        get; 
        set; 
    }

    void ProcessTargetReports();

    void PredictTracks(double time);

    void DeleteAllTracks();

    void DeleteTrack(int trackId);
}