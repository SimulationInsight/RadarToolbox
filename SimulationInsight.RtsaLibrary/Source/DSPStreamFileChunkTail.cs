using SimulationInsight.MathLibrary;
using System;

namespace SimulationInsight.RtsaLibrary
{
    public class DSPStreamFileChunkTail : PacketData
    {
        public double CompletionTime { get; set; }

        public Int64 StreamOffset { get; set; }

        public UInt32 NumStreams { get; set; }

        public DateTime CompletionTimeDateTime => DateTimeUtilities.ConvertUnixTimeToDataTime(CompletionTime);
    }
}