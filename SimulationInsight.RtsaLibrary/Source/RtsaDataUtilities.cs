using SimulationInsight.MathLibrary;
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
        public static void PrepareFile(RtsaData rtsaData, int numberOfSAMPPacketsToKeep)
        {
            RemoveSPRVData(rtsaData);
            RemoveSAMPData(rtsaData, numberOfSAMPPacketsToKeep);
            RepairFile(rtsaData);
            rtsaData.UpdateData();
        }

        public static void RemoveSPRVData(RtsaData rtsaData)
        {
            rtsaData.PacketData.RemoveAll(s => s.PacketHeader.PacketString == "SPRV");

            rtsaData.UpdateData();
        }

        public static void RemoveSAMPData(RtsaData rtsaData, int numberOfSAMPPacketsToKeep)
        {
            var index = 3 + numberOfSAMPPacketsToKeep;
            var count = rtsaData.PacketData.Count - index - 2;

            rtsaData.PacketData.RemoveRange(index, count);

            rtsaData.UpdateData();
        }

        public static void RepairFile(RtsaData rtsaData)
        {
            var sampleData = rtsaData.PacketData.Where(s => s.PacketHeader.PacketString == "SAMP").Cast<DSPStreamFileChunkSamples>();

            var numSamples = sampleData.Select(s => (int)s.NumSamples);

            var totalSamples = (UInt64)numSamples.Sum();

            var p = (DSPStreamFileChunkStreamTail)rtsaData.PacketData[^2];

            p.NumSamples = totalSamples;
            p.PayloadSize = totalSamples * 8;

            rtsaData.UpdateData();
        }

        public static void UpdateWithSignalData(RtsaData rtsaData, Signal signal)
        {
            var samplePackets = rtsaData.PacketData.Where(s => s.PacketHeader.PacketString == "SAMP").Cast<DSPStreamFileChunkSamples>();

            foreach (var p in samplePackets)
            {
                p.NumSamples = (UInt32)signal.NumberOfSamples;
                p.Samples = signal.GetSampleDataFloat();
                p.PacketEndTime = p.PacketStartTime + signal.EndTime;
            }

            RepairFile(rtsaData);
        }

        public static void UpdateWithSignalData(RtsaData rtsaData, List<Signal> signals)
        {
            var samplePackets = rtsaData.PacketData.Where(s => s.PacketHeader.PacketString == "SAMP").Cast<DSPStreamFileChunkSamples>();

            var numSignals = signals.Count;

            var index = 0;

            Signal signal;

            foreach (var p in samplePackets)
            {
                signal = signals[index];

                index++;
                _ = Math.DivRem(index, numSignals, out index);

                p.NumSamples = (UInt32)signal.NumberOfSamples;
                p.Samples = signal.GetSampleDataFloat();
                p.PacketEndTime = p.PacketStartTime + signal.EndTime;
            }

            RepairFile(rtsaData);
        }
    }
}
