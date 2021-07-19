using SimulationInsight.ESMData.Models;
using SimulationInsight.ESMLibrary;
using SimulationInsight.ESMPulseDescriptorGenerator;
using System.Collections.Generic;

namespace SimulationInsight.ESMDataGenerator
{
    public class ESMDataGenerator
    {
        public List<ESMPulseDescriptorGeneratorInputs> ESMPulseDescriptorGeneratorInputs { get; set; }

        public ESMData.Models.ESMDataDTO ESMData { get; set; }

        public bool IsGenerateIQSignals { get; set; }

        public double SampleRate { get; set; }

        public void GenerateESMData()
        {
            var trackNumber = 0;

            ESMData = new ESMData.Models.ESMDataDTO();

            foreach (var inputs in ESMPulseDescriptorGeneratorInputs)
            {
                trackNumber++;

                var track = GenerateESMTrack(trackNumber, inputs);

                ESMData.Tracks.Add(track);
            }
        }

        public TrackDTO GenerateESMTrack(int trackNumber, ESMPulseDescriptorGeneratorInputs inputs)
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

            var esmTrack = new TrackDTO()
            {
                TrackNumber = trackNumber,
                PulseDescriptors = pulseDescriptors,
            };

            return esmTrack;
        }

        public void GenerateIQSignals(List<PulseDescriptorDTO> pulseDesciptors)
        {
            foreach (var pulseDescriptor in pulseDesciptors)
            {
                var signal = IQSignalGenerator.GenerateSignalFromPulseDescriptor(pulseDescriptor, SampleRate);

                pulseDescriptor.Signal = signal;
            }
        }
    }
}
