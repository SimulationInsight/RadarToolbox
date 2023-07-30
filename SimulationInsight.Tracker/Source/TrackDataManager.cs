using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulationInsight.SystemMessages;

namespace SimulationInsight.Tracker;

public class TrackDataManager : ITrackDataManager
{
    public ITrackList TrackList
    {
        get;
        set;
    }

    public List<SmoothedTrackData> SmoothedTracks
    {
        get;
        set;
    }

    public List<PredictedTrackData> PredictedTracks
    {
        get;
        set;
    }

    public void GeneratePredictedTracks()
    {
    }

    public void GenerateSmoothedTracks()
    {
    } 
    
    public void SendPredictedTracksMessage()
    {
    }
    
    public void SendSmoothedTracksMessage()
    {
    }
}
