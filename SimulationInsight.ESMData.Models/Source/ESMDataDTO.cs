using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationInsight.ESMData.Models
{
    public class ESMDataDTO
    {
        public List<TrackDTO> Tracks { get; set; }

        public int NumberOfTracks => Tracks.Count;

        public ESMDataDTO()
        {
            Tracks = new List<TrackDTO>();
        }
    }
}
