using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationInsight.RtsaLibrary
{
    public class PacketData : IPacketData
    {
        public DSPStreamFileChunk PacketHeader { get; set; }
    }
}
