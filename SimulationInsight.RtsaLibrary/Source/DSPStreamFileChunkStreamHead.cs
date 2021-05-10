using SimulationInsight.MathLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationInsight.RtsaLibrary
{
    public class DSPStreamFileChunkStreamHead : PacketData
    {
        public UInt64 StreamID { get; set; }

        public double StartTime { get; set; }

        public Int64 StreamOffset { get; set; }

        public DateTime StartTimeDateTime => DateTimeUtilities.ConvertUnixTimeToDataTime(StartTime);
    }
}
