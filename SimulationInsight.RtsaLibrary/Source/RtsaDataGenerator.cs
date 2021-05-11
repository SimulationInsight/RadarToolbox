using SimulationInsight.MathLibrary;
using System;

namespace SimulationInsight.RtsaLibrary
{
    public class RtsaDataGenerator
    {
        public Signal Signal { get; set; }

        public float[] Samples { get; set; }

        public RtsaData RtsaData { get; set; }

        public UInt64 StreamID { get; set; }

        public UInt32 SubStreamID { get; set; }

        public RtsaDataGenerator()
        {
        }

        public void Run()
        {
            Initialise();

            RtsaData = new RtsaData();

            SetPacketDataDSFH();
            SetPacketDataSTRM();
            SetPacketDataSSTR();
            SetPacketDataSAMP();
            SetPacketDataSTRT();
            SetPacketDataDSFT();
        }

        public void Initialise()
        {
            StreamID = 9;
            SubStreamID = 0;

            RtsaData = new RtsaData();
        }

        public void SetPacketDataDSFH()
        {
            var packetHeader = new DSPStreamFileChunk()
            {
                PacketString = "DSFH",
                ChunkSize = 24,
                ChunkFlags = 0,
                Version = 1,
                HeaderSize = 24,
            };

            var packetData = new DSPStreamFileChunkHead()
            {
                PacketHeader = packetHeader,
                CreationTimeDateTime = DateTime.Now,
                ExtraData = Array.Empty<byte>()
            };

            RtsaData.PacketData.Add(packetData);
        }

        public void SetPacketDataSTRM()
        {
            var packetHeader = new DSPStreamFileChunk()
            {
                PacketString = "STRM",
                ChunkSize = 48,
                ChunkFlags = 0,
                Version = 1,
                HeaderSize = 48,
            };

            var packetData = new DSPStreamFileChunkStreamHead()
            {
                PacketHeader = packetHeader,
                StreamID = StreamID,
                StartTimeDateTime = DateTime.Now,
                StreamOffset = 0,
                ExtraData = new byte[8]
            };

            RtsaData.PacketData.Add(packetData);
        }

        public void SetPacketDataSSTR()
        {
            var packetHeader = new DSPStreamFileChunk()
            {
                PacketString = "SSTR",
                ChunkSize = 288,
                ChunkFlags = 0,
                Version = 1,
                HeaderSize = 288,
            };

            var packetData = new DSPStreamFileChunkSubStream()
            {
                PacketHeader = packetHeader,
                StreamID = StreamID,
                SubStreamID = SubStreamID,
                SubStreamOffset = 0,
                XXX1 = new byte[4],
                FrequencyStart = Signal.RFFrequencyMin,
                FrequencyStep = Signal.RFBandwidth,
                FrequencySpan = Signal.RFBandwidth,
                ValueMinimum = -2.0,
                ValueMaximum = 2.0,
                Direction = 0.05,
                AntennaIndex = 0,
                NumCategories = 0,
                Name = new byte[128],
                AntennaID = 0,
                MetaDataID = 0,
                ExtraData = new byte[48]
            };

            RtsaData.PacketData.Add(packetData);
        }

        public void SetPacketDataSAMP()
        {
            Samples = Signal.GetSampleDataFloat();

            var headerSize = 72;
            var dataSize = Signal.NumberOfSamples * 8;
            var chunkSize = headerSize + dataSize;

            var packetHeader = new DSPStreamFileChunk()
            {
                PacketString = "SAMP",
                ChunkSize = (UInt32)chunkSize,
                ChunkFlags = 0,
                Version = 1,
                HeaderSize = (UInt16)headerSize,
            };

            var packetData = new DSPStreamFileChunkSamples()
            {
                PacketHeader = packetHeader,
                StreamID = StreamID,
                SubStreamID = SubStreamID,
                Compression = 0,
                NumSamples = (UInt32)Signal.NumberOfSamples,
                PayloadType = 2,
                SampleDepth = 1,
                SampleSize = 2,
                SampleType = 11,
                SampleUnit = 2,
                PacketStartTime = Signal.StartTime,
                PacketEndTime = Signal.EndTime,
                Samples = Samples,
                ExtraData = new byte[8]
            };

            RtsaData.PacketData.Add(packetData);
        }

        public void SetPacketDataSTRT()
        {
            var packetHeader = new DSPStreamFileChunk()
            {
                PacketString = "STRT",
                ChunkSize = 104,
                ChunkFlags = 0,
                Version = 1,
                HeaderSize = 104,
            };

            var packetData = new DSPStreamFileChunkStreamTail()
            {
                PacketHeader = packetHeader,
                StreamOffset = 24,
                SubStreamOffset = 72,
                PreviewOffset = 0,
                NumSamples = (UInt64)Signal.NumberOfSamples,
                PayloadSize = (UInt64)Signal.NumberOfSamples * 8,
                PreviewLevels = 2,
                NumPreviews = 32,
                NumPreviewSegments = 502,
                XXX1 = 437,
                EndTime = Signal.EndTime,
                AntennaOffset = 0,
                MetaDataOffset = 0,
                ExtraData = new byte[8] {2, 0, 0, 0, 2, 0, 0, 0}
            };

            RtsaData.PacketData.Add(packetData);
        }

        public void SetPacketDataDSFT()
        {
            var packetHeader = new DSPStreamFileChunk()
            {
                PacketString = "DSFT",
                ChunkSize = 40,
                ChunkFlags = 0,
                Version = 1,
                HeaderSize = 40,
            };

            var packetData = new DSPStreamFileChunkTail()
            {
                PacketHeader = packetHeader,
                CompletionTimeDateTime = DateTime.Now,
                StreamOffset = 0,
                NumStreams = 1,
                ExtraData = new byte[4] { 181, 1, 0, 0 }
            };

            RtsaData.PacketData.Add(packetData);
        }
    }
}