using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationInsight.ESMData.Models
{
    public class ESMData
    {
        public List<ESMTrack> Tracks { get; set; }

        public int NumberOfTracks => Tracks.Count;

        public ESMData()
        {
            Tracks = new List<ESMTrack>();
        }
    }
}
