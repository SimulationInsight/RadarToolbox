using System;
using System.Text;

namespace SimulationInsight.RtsaLibrary
{
    public class DSPStreamFileChunk
    {
        public UInt32 ChunkID { get; set; }

        public UInt32 ChunkSize { get; set; }

        public UInt32 ChunkFlags { get; set; }

        public UInt16 Version { get; set; }

        public UInt16 HeaderSize { get; set; }

        public string PacketString { get => Encoding.Default.GetString(BitConverter.GetBytes(ChunkID)); set => ChunkID = BitConverter.ToUInt32(Encoding.ASCII.GetBytes(value)); }

        public long PacketStartPosition { get; set; }
    }
}