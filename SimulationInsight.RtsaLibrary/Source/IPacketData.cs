namespace SimulationInsight.RtsaLibrary
{
    public interface IPacketData
    {
        DSPStreamFileChunk PacketHeader { get; set; }

        byte[] ExtraData { get; set; }
    }
}