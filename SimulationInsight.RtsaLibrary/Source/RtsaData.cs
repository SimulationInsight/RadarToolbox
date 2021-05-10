using System.Collections.Generic;

namespace SimulationInsight.RtsaLibrary
{
    public class RtsaData
    {
        public List<DSPStreamFileChunk> PacketHeaders { get; set; }

        public List<IPacketData> PacketData { get; set; }

        public List<string> PacketTypes { get; set; }

        public RtsaData()
        {
            PacketHeaders = new List<DSPStreamFileChunk>();

            PacketData = new List<IPacketData>();
        }
    }
}