using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationInsight.ESMData.Models
{
    public class TrackDTO
    {
        public int TrackNumber { get; set; }

        public List<PulseDescriptorDTO> PulseDescriptors { get; set; }
    }
}
