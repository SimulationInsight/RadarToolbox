using SimulationInsight.Core;
using SimulationInsight.ESMData.Models;
using SimulationInsight.ESMLibrary;
using System.Collections.Generic;

namespace SimulationInsight.ESMPulseDescriptorGenerator
{
    public class ESMPulseDescriptorGenerator : IESMPulseDescriptorGenerator
    {
        public ESMPulseDescriptorGeneratorInputs Inputs { get; set; }

        public PulseDescriptorData PulseDescriptorData { get; set; }

        public void GeneratePulseDescriptorData()
        {
            var currentTime = Inputs.StartTime;

            var pulseNumber = 0;

            PulseDescriptorData = new PulseDescriptorData()
            {
                PulseDescriptors = new List<PulseDescriptorDTO>()
            };

            while (currentTime <= Inputs.EndTime)
            {
                pulseNumber++;

                var pw = Inputs.PulseWidth.GetCircularValue(pulseNumber);
                var prf = Inputs.PulseRepetitionFrequency.GetCircularValue(pulseNumber);
                var rfCentre = Inputs.FrequencyCentre.GetCircularValue(pulseNumber);
                var rfBandwidth = Inputs.FrequencyBandwidth.GetCircularValue(pulseNumber);

                var pri = 1.0 / prf;

                var pulseTimeStart = currentTime;
                var pulseTimeEnd = pulseTimeStart + pw;

                var p = new PulseDescriptorDTO()
                {
                    RadarId = 1,
                    PulseNumber = pulseNumber,
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