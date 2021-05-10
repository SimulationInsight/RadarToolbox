using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace SimulationInsight.RtsaLibrary
{
    public class RtsaReader
    {
        public string FilePath { get; set; }

        public byte[] FileBytes { get; set; }

        public BinaryReader Reader { get; set; }

        public List<DSPStreamFileChunk> PacketHeaders { get; set; }

        public List<IPacketData> PacketData { get; set; }

        public List<string> PacketTypes { get; set; }

        public RtsaReader()
        {
        }

        public void Run()
        {
            ReadAllData();

            OpenFile();

            ReadData();

            CloseFile();
        }

        public void ReadAllData()
        {
            FileBytes = File.ReadAllBytes(FilePath);
        }

        public void OpenFile()
        {
            Reader = new BinaryReader(File.Open(FilePath, FileMode.Open));
        }

        public void CloseFile()
        {
            Reader.Close();
        }

        public void ReadData()
        {
            PacketHeaders = new List<DSPStreamFileChunk>();
            PacketData = new List<IPacketData>();

            DSPStreamFileChunk packetHeader;
            IPacketData packetData;

            while (Reader.PeekChar() >= 0)
            {
                packetHeader = ReadPackerHeader();
                packetData = ReadPacketData(packetHeader);

                SkipToNextPacket(packetHeader);

                PacketHeaders.Add(packetHeader);
                PacketData.Add(packetData);
            }
        }

        public DSPStreamFileChunk ReadPackerHeader()
        {
            var packetHeader = RtsaReaderUtilities.ReadPackerHeader(Reader);

            return packetHeader;
        }

        public IPacketData ReadPacketData(DSPStreamFileChunk packetHeader)
        {
            IPacketData packetData = packetHeader.PacketString switch
            {
                "DSFH" => RtsaReaderUtilities.ReadPacketDataDSFH(Reader, packetHeader),
                "STRM" => RtsaReaderUtilities.ReadPacketDataSTRM(Reader, packetHeader),
                "SSTR" => RtsaReaderUtilities.ReadPacketDataSSTR(Reader, packetHeader),
                "SAMP" => RtsaReaderUtilities.ReadPacketDataSAMP(Reader, packetHeader),
                "SPRV" => RtsaReaderUtilities.ReadPacketDataSPRV(Reader, packetHeader),
                "STRT" => RtsaReaderUtilities.ReadPacketDataSTRT(Reader, packetHeader),
                "DSFT" => RtsaReaderUtilities.ReadPacketDataDSFT(Reader, packetHeader),
                _ => throw new("Unknown Packet Type"),
            };

            return packetData;
        }

        public void SkipToNextPacket(DSPStreamFileChunk packetHeader)
        {
            var numberOfBytesRead = Reader.BaseStream.Position - packetHeader.PacketStartPosition;

            var numberOfBytesRequired = packetHeader.ChunkSize;

            var numberOfBytesToSkip = numberOfBytesRequired - numberOfBytesRead;

            Reader.ReadBytes((int)numberOfBytesToSkip);
        }
    }
}