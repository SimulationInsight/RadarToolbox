using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimulationInsight.ESMData.Entities
{
    [Table("Mission")]
    public class Mission
    {
        public int MissionId {get; set; }

        public int MissionNumber { get; set; }

        public MissionType MissionType { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public string Description { get; set; }

        public List<Recording> Recordings { get; set; }

        public List<Track> Tracks { get; set; }
    }
}
