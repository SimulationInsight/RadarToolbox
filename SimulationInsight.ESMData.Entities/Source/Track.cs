using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationInsight.ESMData.Entities
{
    [Table("Track")]
    public class Track
    {
        public int TrackId { get; set; }

        public int TrackNumber { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public string TrackName { get; set; }

        public List<PulseDescriptor> PulseDescriptors { get; set; }

        public int MissionId { get; set; }
        public Mission Mission { get; set; }
    }
}
