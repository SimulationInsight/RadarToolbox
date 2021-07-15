using SimulationInsight.ESMLibrary;
using SimulationInsight.ESMPulseDescriptorGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationInsight.ESMTrackGenerator
{
    public class ESMTrackGenerator
    {
        public List<ESMPulseDescriptorGeneratorInputs> ESMPulseDescriptorGeneratorInputs { get; set; }

        public ESMTrackList ESMTrackList { get; set; }

        public bool IsGenerateIQSignals { get; set; }

        public double SampleRate { get; set; }

        public void GenerateESMTrackList()
        {
            var trackId = 0;

            ESMTrackList = new ESMTrackList();

            foreach (var inputs in ESMPulseDescriptorGeneratorInputs)
            {
                trackId++;

                var track = GenerateESMTrack(trackId, inputs);

                ESMTrackList.Tracks.Add(track);
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

            var signals = new List<IQSignal>();

            if (IsGenerateIQSignals)
            {
                signals = GenerateIQSignals(pulseDescriptors);
            }
            var esmTrack = new ESMTrack()
            {
                TrackId = trackId,
                PulseDescriptors = pulseDescriptors,
                IQSignals = signals
            };

            return esmTrack;
        }

        public List<IQSignal> GenerateIQSignals(List<ESMPulseDescriptor> pulseDesciptors)
        {
            var signals = new List<IQSignal>();

            foreach (var pulseDesciptor in pulseDesciptors)
            {
                var signal = IQSignalGenerator.GenerateSignalFromPulseDescriptor(pulseDesciptor, SampleRate);

                signals.Add(signal);
            }

            return signals;
        }
    }
}
