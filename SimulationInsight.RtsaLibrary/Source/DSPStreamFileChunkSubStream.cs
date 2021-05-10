using System;

namespace SimulationInsight.RtsaLibrary
{
    public class DSPStreamFileChunkSubStream : PacketData
    {
        public UInt64 StreamID { get; set; }

        public UInt32 SubStreamID { get; set; }

        public Int64 SubStreamOffset { get; set; }

        public byte[] XXX1 { get; set; }

        public double FrequencyStart { get; set; }

        public double FrequencyStep { get; set; }

        public double FrequencySpan { get; set; }

        public double ValueMinimum { get; set; }

        public double ValueMaximum { get; set; }

        public double Direction { get; set; }

        public UInt32 AntennaIndex { get; set; }

        public UInt32 NumCategories { get; set; }

        public byte[] Name { get; set; }

        public UInt64 AntennaID { get; set; }

        public UInt64 MetaDataID { get; set; }
    }
}