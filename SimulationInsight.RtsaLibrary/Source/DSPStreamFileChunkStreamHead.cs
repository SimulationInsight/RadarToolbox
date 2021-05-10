using SimulationInsight.MathLibrary;
using System;

namespace SimulationInsight.RtsaLibrary
{
    public class DSPStreamFileChunkStreamHead : PacketData
    {
        public UInt64 StreamID { get; set; }

        public double StartTime { get; set; }

        public Int64 StreamOffset { get; set; }

        public DateTime StartTimeDateTime { get => StartTime.FromUnixTime(); set => StartTime = value.ToUnixTime(); }
    }
}