namespace SimulationInsight.RtsaLibrary
{
    public class PacketData : IPacketData
    {
        public DSPStreamFileChunk PacketHeader { get; set; }

        public byte[] ExtraData { get; set; }
    }
}