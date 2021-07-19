using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationInsight.ESMData.Models
{
    public class MissionDTO
    {
        public int MissionNumber { get; set; }

        public MissionTypeDTO MissionType { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public string Description { get; set; }

        public List<TrackDTO> Tracks { get; set; }
    }
}
