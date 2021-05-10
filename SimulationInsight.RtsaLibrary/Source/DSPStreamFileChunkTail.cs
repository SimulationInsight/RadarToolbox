using SimulationInsight.MathLibrary;
using System;

namespace SimulationInsight.RtsaLibrary
{
    public class DSPStreamFileChunkTail : PacketData
    {
        public double CompletionTime { get; set; }

        public Int64 StreamOffset { get; set; }

        public UInt32 NumStreams { get; set; }

        public double CompletionTimeSeconds { get => CompletionTime / 1.0e6; set => CompletionTime = value * 1.0e6; }

        public DateTime CompletionTimeDateTime { get => CompletionTimeSeconds.FromUnixTime(); set => CompletionTimeSeconds = value.ToUnixTime(); }
    }
}