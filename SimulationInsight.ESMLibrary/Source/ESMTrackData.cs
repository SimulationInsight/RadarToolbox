using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationInsight.ESMLibrary
{
    public class ESMTrackData
    {
        public List<ESMTrack> Tracks { get; set; }

        public int NumberOfTracks => Tracks.Count;

        public ESMTrackData()
        {
            Tracks = new List<ESMTrack>();
        }
    }
}
