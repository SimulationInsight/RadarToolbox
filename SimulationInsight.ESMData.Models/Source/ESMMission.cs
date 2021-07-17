using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationInsight.ESMData.Models.Source
{
    public class ESMMission
    {
        public int MissionNumber { get; set; }

        public ESMMissionType MissionType { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public string Description { get; set; }

        public List<ESMTrack> Tracks { get; set; }
    }
}
