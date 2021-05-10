using System.IO;

namespace SimulationInsight.RtsaLibrary
{
    public static class RtsaWriterUtilities
    {
        public static void WritePacketHeader(BinaryWriter writer, DSPStreamFileChunk packetHeader)
        {
            writer.Write(packetHeader.ChunkID);
            writer.Write(packetHeader.ChunkSize);
            writer.Write(packetHeader.ChunkFlags);
            writer.Write(packetHeader.Version);
            writer.Write(packetHeader.HeaderSize);
        }

        public static void WritePacketDataDSFH(BinaryWriter writer, DSPStreamFileChunkHead packetData)
        {
            WritePacketHeader(writer, packetData.PacketHeader);

            writer.Write(packetData.CreationTime);
        }

        public static void WritePacketDataSTRM(BinaryWriter writer, DSPStreamFileChunkStreamHead packetData)
        {
            WritePacketHeader(writer, packetData.PacketHeader);

            writer.Write(packetData.StreamID);
            writer.Write(packetData.StartTime);
            writer.Write(packetData.StreamOffset);
        }

        public static void WritePacketDataSSTR(BinaryWriter writer, DSPStreamFileChunkSubStream packetData)
        {
            WritePacketHeader(writer, packetData.PacketHeader);

            writer.Write(packetData.StreamID);
            writer.Write(packetData.SubStreamID);
            writer.Write(packetData.SubStreamOffset);
            writer.Write(packetData.XXX1);
            writer.Write(packetData.FrequencyStart);
            writer.Write(packetData.FrequencyStep);
            writer.Write(packetData.FrequencySpan);
            writer.Write(packetData.ValueMinimum);
            writer.Write(packetData.ValueMaximum);
            writer.Write(packetData.Direction);
            writer.Write(packetData.AntennaIndex);
            writer.Write(packetData.NumCategories);
            writer.Write(packetData.Name);
            writer.Write(packetData.AntennaID);
            writer.Write(packetData.MetaDataID);
        }

        public static void WritePacketDataSAMP(BinaryWriter writer, DSPStreamFileChunkSamples packetData)
        {
            WritePacketHeader(writer, packetData.PacketHeader);

            writer.Write(packetData.StreamID);
            writer.Write(packetData.SubStreamID);
            writer.Write(packetData.SampleType);
            writer.Write(packetData.SampleUnit);
            writer.Write(packetData.PayloadType);
            writer.Write(packetData.Compression);
            writer.Write(packetData.PacketStartTime);
            writer.Write(packetData.PacketEndTime);
            writer.Write(packetData.PacketFlags);
            writer.Write(packetData.SampleSize);
            writer.Write(packetData.SampleDepth);
            writer.Write(packetData.NumSamples);

            for (int i = 0; i < packetData.NumSamples; i++)
            {
                writer.Write(packetData.Samples[i]);
            }
        }

        public static void WritePacketDataSPRV(BinaryWriter writer, IPacketData packetData)
        {
            WritePacketHeader(writer, packetData.PacketHeader);
        }

        public static void WritePacketDataSTRT(BinaryWriter writer, DSPStreamFileChunkStreamTail packetData)
        {
            WritePacketHeader(writer, packetData.PacketHeader);

            writer.Write(packetData.StreamOffset);
            writer.Write(packetData.SubStreamOffset);
            writer.Write(packetData.PreviewOffset);
            writer.Write(packetData.NumSamples);
            writer.Write(packetData.PayloadSize);
            writer.Write(packetData.PreviewLevels);
            writer.Write(packetData.NumPreviews);
            writer.Write(packetData.NumPreviewSegments);
            writer.Write(packetData.EndTime);
            writer.Write(packetData.AntennaOffset);
            writer.Write(packetData.MetaDataOffset);
        }

        public static void WritePacketDataDSFT(BinaryWriter writer, DSPStreamFileChunkTail packetData)
        {
            WritePacketHeader(writer, packetData.PacketHeader);

            writer.Write(packetData.CompletionTime);
            writer.Write(packetData.StreamOffset);
            writer.Write(packetData.NumStreams);
        }
    }
}