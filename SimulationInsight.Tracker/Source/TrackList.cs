using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationInsight.Tracker;

public class TrackList : ITrackList
{
    public List<Track> Tracks
    {
        get;
        set;
    }

    public int NumberOfTracks => Tracks.Count;

    public TrackList()
    {
        Tracks = new List<Track>();
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
