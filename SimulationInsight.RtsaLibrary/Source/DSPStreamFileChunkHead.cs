using SimulationInsight.MathLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationInsight.RtsaLibrary
{
    public class DSPStreamFileChunkHead : PacketData
    {
        public double CreationTime { get; set; }

        public double CreationTimeSeconds => CreationTime / 1.0e6;

        public DateTime CreationTimeDateTime => DateTimeUtilities.ConvertUnixTimeToDataTime(CreationTimeSeconds);
    }
}
