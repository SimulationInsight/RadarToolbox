using SimulationInsight.Core;
using SimulationInsight.ESMLibrary;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace SimulationInsight.ESMPulseDescriptorGenerator
{
    public class ESMPulseDescriptorGenerator : IESMPulseDescriptorGenerator
    {
        public ESMPulseDescriptorGeneratorInputs ESMPulseDescriptorGeneratorInputs { get; set; }

        public PulseDescriptorData PulseDescriptorData { get; set; }

        public void GeneratePulseDescriptorData()
        {
            var currentTime = ESMPulseDescriptorGeneratorInputs.StartTime;

            var pulseId = 0;

            PulseDescriptorData = new PulseDescriptorData()
            {
                PulseDescriptors = new List<PulseDescriptor>()
            };

            while (currentTime <= ESMPulseDescriptorGeneratorInputs.EndTime)
            {
                pulseId++;

                var pw = ESMPulseDescriptorGeneratorInputs.PulseWidth.GetCircularValue(pulseId);
                var prf = ESMPulseDescriptorGeneratorInputs.PulseRepetitionFrequency.GetCircularValue(pulseId);
                var rfCentre = ESMPulseDescriptorGeneratorInputs.FrequencyCentre.GetCircularValue(pulseId);

                var pri = 1.0 / prf;

                var pulseTimeStart = currentTime;
                var pulseTimeEnd = pulseTimeStart + pw;

                var p = new PulseDescriptor()
                {
                    PulseId = pulseId,
                    PulseTimeStart = pulseTimeStart,
                    PulseTimeEnd = pulseTimeEnd,
                    PulseWidth = pw,
                    FrequencyStart = rfCentre
                };

                currentTime += pri;

                PulseDescriptorData.PulseDescriptors.Add(p);
            }
        }

        public void WritePulseDescriptorData(string fileName)
        {
            PulseDescriptorData.PulseDescriptors.WriteToCsvFile(fileName);
        }
    }
}