using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimulationInsight.SystemMessages;

namespace SimulationInsight.Tracker;

public interface ITrackDataManager
{
    ITrackList TrackList
    {
        get;
        set;
    }

    List<SmoothedTrackData> SmoothedTracks
    {
        get;
        set;
    }

    List<PredictedTrackData> PredictedTracks
    {
        get;
        set;
    }

    void GenerateSmoothedTracks();

    void GeneratePredictedTracks();

    void SendSmoothedTracksMessage();

    void SendPredictedTracksMessage();

}
