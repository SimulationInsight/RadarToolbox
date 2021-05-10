using System.IO;

namespace SimulationInsight.RtsaLibrary
{
    public static class RtsaReaderUtilities
    {
        public static DSPStreamFileChunk ReadPacketHeader(BinaryReader reader)
        {
            var packetHeader = new DSPStreamFileChunk
            {
                PacketStartPosition = reader.BaseStream.Position,
                ChunkID = reader.ReadUInt32(),
                ChunkSize = reader.ReadUInt32(),
                ChunkFlags = reader.ReadUInt32(),
                Version = reader.ReadUInt16(),
                HeaderSize = reader.ReadUInt16()
            };

            return packetHeader;
        }

        public static DSPStreamFileChunkHead ReadPacketDataDSFH(BinaryReader reader, DSPStreamFileChunk packetHeader)
        {
            var packetData = new DSPStreamFileChunkHead
            {
                PacketHeader = packetHeader,
                CreationTime = reader.ReadDouble(),
            };

            return packetData;
        }

        public static DSPStreamFileChunkStreamHead ReadPacketDataSTRM(BinaryReader reader, DSPStreamFileChunk packetHeader)
        {
            var packetData = new DSPStreamFileChunkStreamHead
            {
                PacketHeader = packetHeader,
                StreamID = reader.ReadUInt64(),
                StartTime = reader.ReadDouble(),
                StreamOffset = reader.ReadInt64()
            };

            return packetData;
        }

        public static DSPStreamFileChunkSubStream ReadPacketDataSSTR(BinaryReader reader, DSPStreamFileChunk packetHeader)
        {
            var packetData = new DSPStreamFileChunkSubStream
            {
                PacketHeader = packetHeader,
                StreamID = reader.ReadUInt64(),
                SubStreamID = reader.ReadUInt32(),
                SubStreamOffset = reader.ReadInt64(),
                XXX1 = reader.ReadBytes(4),
                FrequencyStart = reader.ReadDouble(),
                FrequencyStep = reader.ReadDouble(),
                FrequencySpan = reader.ReadDouble(),
                ValueMinimum = reader.ReadDouble(),
                ValueMaximum = reader.ReadDouble(),
                Direction = reader.ReadDouble(),
                AntennaIndex = reader.ReadUInt32(),
                NumCategories = reader.ReadUInt32(),
                Name = reader.ReadBytes(128),
                AntennaID = reader.ReadUInt64(),
                MetaDataID = reader.ReadUInt64(),
            };

            return packetData;
        }

        public static DSPStreamFileChunkSamples ReadPacketDataSAMP(BinaryReader reader, DSPStreamFileChunk packetHeader)
        {
            var packetData = new DSPStreamFileChunkSamples
            {
                PacketHeader = packetHeader,
                StreamID = reader.ReadUInt64(),
                SubStreamID = reader.ReadUInt32(),
                SampleType = reader.ReadByte(),
                SampleUnit = reader.ReadByte(),
                PayloadType = reader.ReadByte(),
                Compression = reader.ReadByte(),
                PacketStartTime = reader.ReadDouble(),
                PacketEndTime = reader.ReadDouble(),
                PacketFlags = reader.ReadUInt32(),
                SampleSize = reader.ReadUInt32(),
                SampleDepth = reader.ReadUInt32(),
                NumSamples = reader.ReadUInt32()
            };

            var nSamples = packetData.NumSamples * 2;

            var samples = new float[nSamples];

            for (int i = 0; i < nSamples; i++)
            {
                samples[i] = reader.ReadSingle();
            }

            packetData.Samples = samples;

            return packetData;
        }

        public static DSPStreamFileChunkStreamPreview ReadPacketDataSPRV(BinaryReader reader, DSPStreamFileChunk packetHeader)
        {
            var packetData = new DSPStreamFileChunkStreamPreview
            {
                PacketHeader = packetHeader,
            };

            return packetData;
        }

        public static DSPStreamFileChunkStreamTail ReadPacketDataSTRT(BinaryReader reader, DSPStreamFileChunk packetHeader)
        {
            var packetData = new DSPStreamFileChunkStreamTail
            {
                PacketHeader = packetHeader,
                StreamOffset = reader.ReadInt64(),
                SubStreamOffset = reader.ReadInt64(),
                PreviewOffset = reader.ReadInt64(),
                NumSamples = reader.ReadUInt64(),
                PayloadSize = reader.ReadUInt64(),
                PreviewLevels = reader.ReadUInt32(),
                NumPreviews = reader.ReadUInt32(),
                NumPreviewSegments = reader.ReadUInt32(),
                EndTime = reader.ReadDouble(),
                AntennaOffset = reader.ReadInt64(),
                MetaDataOffset = reader.ReadInt64()
            };

            return packetData;
        }

        public static DSPStreamFileChunkTail ReadPacketDataDSFT(BinaryReader reader, DSPStreamFileChunk packetHeader)
        {
            var packetData = new DSPStreamFileChunkTail
            {
                PacketHeader = packetHeader,
                CompletionTime = reader.ReadDouble(),
                StreamOffset = reader.ReadInt64(),
                NumStreams = reader.ReadUInt32()
            };

            return packetData;
        }
    }
}