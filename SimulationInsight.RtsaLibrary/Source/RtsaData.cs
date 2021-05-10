using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
