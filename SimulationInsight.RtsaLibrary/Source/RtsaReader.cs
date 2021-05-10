using System.IO;
using System.Linq;

namespace SimulationInsight.RtsaLibrary
{
    public class RtsaReader
    {
        public string FilePath { get; set; }

        public byte[] FileBytes { get; set; }

        public BinaryReader Reader { get; set; }

        public RtsaData RtsaData { get; set; }

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
            RtsaData = new RtsaData();

            DSPStreamFileChunk packetHeader;
            IPacketData packetData;

            while (Reader.PeekChar() >= 0)
            {
                packetHeader = ReadPacketHeader();
                packetData = ReadPacketData(packetHeader);
                packetData = SkipToNextPacket(packetData);

                RtsaData.PacketHeaders.Add(packetHeader);
                RtsaData.PacketData.Add(packetData);
            }

            RtsaData.PacketTypes = RtsaData.PacketHeaders.Select(s => s.PacketString).ToList();
        }

        public DSPStreamFileChunk ReadPacketHeader()
        {
            var packetHeader = RtsaReaderUtilities.ReadPacketHeader(Reader);

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

        public IPacketData SkipToNextPacket(IPacketData packetData)
        {
            var numberOfBytesRead = Reader.BaseStream.Position - packetData.PacketHeader.PacketStartPosition;

            var numberOfBytesRequired = packetData.PacketHeader.ChunkSize;

            var numberOfBytesToSkip = numberOfBytesRequired - numberOfBytesRead;

            packetData.ExtraData = Reader.ReadBytes((int)numberOfBytesToSkip);

            return packetData;
        }
    }
}