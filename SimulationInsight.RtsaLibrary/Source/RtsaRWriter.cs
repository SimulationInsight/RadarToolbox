using System.IO;
using System.Linq;

namespace SimulationInsight.RtsaLibrary
{
    public class RtsaWriter
    {
        public string FilePath { get; set; }

        public BinaryWriter Writer { get; set; }

        public RtsaData RtsaData { get; set; }

        public RtsaWriter()
        {
        }

        public void Run()
        {
            OpenFile();

            WriteData();

            CloseFile();
        }

        public void OpenFile()
        {
            Writer = new BinaryWriter(File.Open(FilePath, FileMode.Create));
        }

        public void CloseFile()
        {
            Writer.Close();
        }

        public void WriteData()
        {
            foreach (var packetData in RtsaData.PacketData) 
            {
                WritePacketData(packetData);

                SkipToNextPacket(packetData);
            }
        }

        public void WritePacketData(IPacketData packetData)
        {
            switch (packetData.PacketHeader.PacketString)
            {
                case "DSFH":
                    RtsaWriterUtilities.WritePacketDataDSFH(Writer, (DSPStreamFileChunkHead)packetData);
                    break;

                case "STRM":
                    RtsaWriterUtilities.WritePacketDataSTRM(Writer, (DSPStreamFileChunkStreamHead)packetData);
                    break;

                case "SSTR":
                    RtsaWriterUtilities.WritePacketDataSSTR(Writer, (DSPStreamFileChunkSubStream)packetData);
                    break;

                case "SAMP":
                    RtsaWriterUtilities.WritePacketDataSAMP(Writer, (DSPStreamFileChunkSamples)packetData);
                    break;

                case "SPRV":
                    RtsaWriterUtilities.WritePacketDataSPRV(Writer, packetData);
                    break;

                case "STRT":
                    RtsaWriterUtilities.WritePacketDataSTRT(Writer, (DSPStreamFileChunkStreamTail)packetData);
                    break;

                case "DSFT":
                    RtsaWriterUtilities.WritePacketDataDSFT(Writer, (DSPStreamFileChunkTail)packetData);
                    break;


                default:
                    throw new("Unknown Packet Type");
            }
        }

        public void SkipToNextPacket(IPacketData packetData)
        {
            Writer.Write(packetData.ExtraData);
        }
    }
}