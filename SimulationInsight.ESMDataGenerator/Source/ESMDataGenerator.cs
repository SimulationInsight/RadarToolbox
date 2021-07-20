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

            ESMData = new ESMDataDTO();

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
                GenerateIQSignals(pulseDescriptors, inputs);
            }

            var esmTrack = new TrackDTO()
            {
                TrackNumber = trackNumber,
                PulseDescriptors = pulseDescriptors,
            };

            return esmTrack;
        }

        public void GenerateIQSignals(List<PulseDescriptorDTO> pulseDesciptors, ESMPulseDescriptorGeneratorInputs inputs)
        {
            var meanNoisePower = 1.0e-12;

            foreach (var pulseDescriptor in pulseDesciptors)
            {
                var signal = IQSignalGenerator.GenerateSignalFromPulseDescriptor(pulseDescriptor, SampleRate, inputs.FrequencyOffset);

                if (inputs.IsAddNoiseSignal)
                {
                    var noiseSignal = IQSignalGenerator.GenerateNoiseSignal(pulseDescriptor.PulseWidth, SampleRate, meanNoisePower);

                    signal += noiseSignal;
                }

                signal.CalculateInstantaneousFrequency();

                signal.CalculateFrequencySpectrum();

                pulseDescriptor.Signal = signal;
            }
        }
    }
}
