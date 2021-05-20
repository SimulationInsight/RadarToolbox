using System;

namespace SimulationInsight.RtsaLibrary
{
    public class DSPStreamFileChunkStreamTail : PacketData
    {
        public Int64 StreamOffset { get; set; }

        public Int64 SubStreamOffset { get; set; }

        public Int64 PreviewOffset { get; set; }

        public UInt64 NumSamples { get; set; }

        public UInt64 PayloadSize { get; set; }

        public UInt32 PreviewLevels { get; set; }

        public UInt32 NumPreviews { get; set; }

        public UInt32 NumPreviewSegments { get; set; }

        public UInt32 XXX1 { get; set; }

        public double EndTime { get; set; }

        public Int64 AntennaOffset { get; set; }

        public Int64 MetaDataOffset { get; set; }
    }
}