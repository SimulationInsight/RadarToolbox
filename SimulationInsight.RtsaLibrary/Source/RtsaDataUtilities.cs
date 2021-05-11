using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationInsight.RtsaLibrary
{
    public static class RtsaDataUtilities
    {
        public static RtsaData PrepareFile(RtsaData rtsaData, int numberOfSAMPPacketsToKeep)
        {
            rtsaData = RemoveSPRVData(rtsaData);
            rtsaData = RemoveSAMPData(rtsaData, numberOfSAMPPacketsToKeep);
            rtsaData = RepairFile(rtsaData);

            return rtsaData;
        }

        public static RtsaData RemoveSPRVData(RtsaData rtsaData)
        {
            rtsaData.PacketData.RemoveAll(s => s.PacketHeader.PacketString == "SPRV");

            rtsaData.UpdateData();

            return rtsaData;
        }

        public static RtsaData RemoveSAMPData(RtsaData rtsaData, int numberOfSAMPPacketsToKeep)
        {
            var index = 3 + numberOfSAMPPacketsToKeep;
            var count = rtsaData.PacketData.Count - index - 2;

            rtsaData.PacketData.RemoveRange(index, count);

            return rtsaData;
        }

        public static RtsaData RepairFile(RtsaData rtsaData)
        {
            var sampleData = rtsaData.PacketData.Where(s => s.PacketHeader.PacketString == "SAMP").Cast<DSPStreamFileChunkSamples>();

            var numSamples = sampleData.Select(s => (int)s.NumSamples);

            var totalSamples = (UInt64)numSamples.Sum();

            var p = (DSPStreamFileChunkStreamTail)rtsaData.PacketData[^2];

            p.NumSamples = totalSamples;
            p.PayloadSize = totalSamples * 8;

            return rtsaData;
        }
    }
}
