using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationInsight.ESMLibrary
{
    public class ESMTrack
    {
        public int TrackId { get; set; }

        public List<ESMPulseDescriptor> PulseDescriptors { get; set; }

        public List<IQSignal> IQSignals { get; set; }
    }
}
