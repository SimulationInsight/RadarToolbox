using MathNet.Numerics.LinearAlgebra.Complex;
using SimulationInsight.SystemMessages;

namespace SimulationInsight.Tracker;

public class TrackManager : ITrackManager
{
    public ITrackManagerSettings TrackManagerSettings
    {
        get;
        set;
    }

    public ITrackDataManager TrackDataManager
    {
        get;
        set;
    }

    public List<TargetReport> TargetReports
    {
        get;
        set;
    }

    public ITrackList TrackList
    {
        get;
        set;
    }

    public List<PredictedTrackData> PredictedTracks
    {
        get;
        set;
    }

    public Matrix WeightedDistanceMatrix
    {
        get;
        set; 
    }

    public Matrix AssociationMatrix
    {
        get;
        set;
    }

    public TrackManager(ITrackManagerSettings trackManagerSettings, ITrackList trackList, ITrackDataManager trackDataManager)
    {
        TrackManagerSettings = trackManagerSettings;
        TrackList = trackList;
        TrackDataManager = trackDataManager;
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
        CalculateWeightedDistanceMatrix();

        GenerateAssociationMatrix();

        InitialiseTracks();

        UpdateTracks();

        DeleteTracks();
    }

    public void CalculateWeightedDistanceMatrix()
    {

    }

    public void GenerateAssociationMatrix()
    {

    }

    public void InitialiseTracks()
    {

    }

    public void UpdateTracks()
    {

    }

    public void DeleteTracks()
    {

    }

    public void PredictTracks(double time)
    {
        PredictedTracks.Clear();

        foreach (var track in TrackList.Tracks)
        {
            var predictedTrack = track.PredictTrack(time);

            PredictedTracks.Add(predictedTrack);
        }
    }

    public void DeleteAllTracks()
    {
        TrackList.DeleteAllTracks();
    }

    public void DeleteTrack(int trackId)
    {
        TrackList.DeleteTrack(trackId);
    }
}