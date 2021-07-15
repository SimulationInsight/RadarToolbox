using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationInsight.ESMLibrary
{
    public class ESMTrackList
    {
        public List<ESMTrack> Tracks { get; set; }

        public int NumberOfTracks => Tracks.Count;

        public ESMTrackList()
        {
            Tracks = new List<ESMTrack>();
        }
    }
}
