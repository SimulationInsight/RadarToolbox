using SimulationInsight.Core;
using SimulationInsight.ESMLibrary;
using System.Collections.Generic;

namespace SimulationInsight.ESMPulseDescriptorGenerator
{
    public class ESMPulseDescriptorGenerator : IESMPulseDescriptorGenerator
    {
        public ESMPulseDescriptorGeneratorInputs Inputs { get; set; }

        public ESMPulseDescriptorData PulseDescriptorData { get; set; }

        public void GeneratePulseDescriptorData()
        {
            var currentTime = Inputs.StartTime;

            var pulseId = 0;

            PulseDescriptorData = new ESMPulseDescriptorData()
            {
                PulseDescriptors = new List<ESMPulseDescriptor>()
            };

            while (currentTime <= Inputs.EndTime)
            {
                pulseId++;

                var pw = Inputs.PulseWidth.GetCircularValue(pulseId);
                var prf = Inputs.PulseRepetitionFrequency.GetCircularValue(pulseId);
                var rfCentre = Inputs.FrequencyCentre.GetCircularValue(pulseId);
                var rfBandwidth = Inputs.FrequencyBandwidth.GetCircularValue(pulseId);

                var pri = 1.0 / prf;

                var pulseTimeStart = currentTime;
                var pulseTimeEnd = pulseTimeStart + pw;

                var p = new ESMPulseDescriptor()
                {
                    RadarId = 1,
                    PulseId = pulseId,
                    PulseTimeStart = pulseTimeStart,
                    PulseTimeEnd = pulseTimeEnd,
                    PulseWidth = pw,
                    FrequencyStart = rfCentre - rfBandwidth / 2.0,
                    FrequencyEnd = rfCentre + rfBandwidth / 2.0,
                    PulseModulationType = 1.0,
                    SignalPower = 20.0,
                    SignalToNoiseRatio = 10.0,
                    AzimuthAngleDeg = 10.0,
                    ElevationAngleDeg = 20.0
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