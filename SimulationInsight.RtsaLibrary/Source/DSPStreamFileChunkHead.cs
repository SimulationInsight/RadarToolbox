using SimulationInsight.MathLibrary;
using System;

namespace SimulationInsight.RtsaLibrary
{
    public class DSPStreamFileChunkHead : PacketData
    {
        public double CreationTime { get; set; }

        public double CreationTimeSeconds { get => CreationTime / 1.0e6; set => CreationTime = value * 1.0e6; }

        public DateTime CreationTimeDateTime { get => CreationTimeSeconds.FromUnixTime(); set => CreationTimeSeconds = value.ToUnixTime(); }
    }
}