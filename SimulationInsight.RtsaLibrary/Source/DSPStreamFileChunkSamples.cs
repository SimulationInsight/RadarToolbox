using System;

namespace SimulationInsight.RtsaLibrary
{
    public class DSPStreamFileChunkSamples : PacketData
    {
        public UInt64 StreamID { get; set; }

        public UInt32 SubStreamID { get; set; }

        public byte SampleType { get; set; }

        public byte SampleUnit { get; set; }

        public byte PayloadType { get; set; }

        public byte Compression { get; set; }

        public double PacketStartTime { get; set; }

        public double PacketEndTime { get; set; }

        public UInt32 PacketFlags { get; set; }

        public UInt32 SampleSize { get; set; }

        public UInt32 SampleDepth { get; set; }

        public UInt32 NumSamples { get; set; }

        public float[] Samples { get; set; }
    }
}