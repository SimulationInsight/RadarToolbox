using System.Collections.Generic;
using System.Linq;

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

        public void UpdateData()
        {
            PacketHeaders = PacketData.Select(s => s.PacketHeader).ToList();

            PacketTypes = PacketHeaders.Select(s => s.PacketString).ToList();
        }
    }
}