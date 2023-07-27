using SimulationInsight.SystemMessages;
using SimulationInsight.TrackingLibrary;

namespace SimulationInsight.Tracker;

public class Track
{
    public int TrackId
    {
        get;
        set;
    }

    public IKalmanFilter TrackFilter
    {
        get;
        set;
    }

    public void InitialiseTrack(TargetReport targetReport)
    {
    }

    public void UpdateTrack(TargetReport targetReport)
    {
    }

    public PredictedTrackData PredictTrack(double time)
    {
        return new PredictedTrackData();
    }

    public SmoothedTrackData GetSmoothedTrackData()
    {
        return new SmoothedTrackData();
    }
}