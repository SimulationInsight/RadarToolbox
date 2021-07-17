using SimulationInsight.ESMData.Models;
using SimulationInsight.ESMLibrary;
using SimulationInsight.ESMPulseDescriptorGenerator;
using System.Collections.Generic;

namespace SimulationInsight.ESMDataGenerator
{
    public class ESMDataGenerator
    {
        public List<ESMPulseDescriptorGeneratorInputs> ESMPulseDescriptorGeneratorInputs { get; set; }

        public ESMData.Models.ESMData ESMData { get; set; }

        public bool IsGenerateIQSignals { get; set; }

        public double SampleRate { get; set; }

        public void GenerateESMData()
        {
            var trackId = 0;

            ESMData = new ESMData.Models.ESMData();

            foreach (var inputs in ESMPulseDescriptorGeneratorInputs)
            {
                trackId++;

                var track = GenerateESMTrack(trackId, inputs);

                ESMData.Tracks.Add(track);
            }
        }

        public ESMTrack GenerateESMTrack(int trackId, ESMPulseDescriptorGeneratorInputs inputs)
        {
            var generator = new ESMPulseDescriptorGenerator.ESMPulseDescriptorGenerator()
            {
                Inputs = inputs
            };

            generator.GeneratePulseDescriptorData();

            var pulseDescriptors = generator.PulseDescriptorData.PulseDescriptors;

            if (IsGenerateIQSignals)
            {
                GenerateIQSignals(pulseDescriptors);
            }

            var esmTrack = new ESMTrack()
            {
                TrackId = trackId,
                PulseDescriptors = pulseDescriptors,
            };

            return esmTrack;
        }

        public void GenerateIQSignals(List<ESMPulseDescriptor> pulseDesciptors)
        {
            foreach (var pulseDescriptor in pulseDesciptors)
            {
                var signal = IQSignalGenerator.GenerateSignalFromPulseDescriptor(pulseDescriptor, SampleRate);

                pulseDescriptor.Signal = signal;
            }
        }
    }
}
