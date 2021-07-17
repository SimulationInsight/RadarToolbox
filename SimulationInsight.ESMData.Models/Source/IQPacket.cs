using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationInsight.ESMData.Models
{
    public class IQPacket
    {
        public int StreamId { get; set; }

        public int PacketId { get; set; }

        public double StartTime { get; set; }

        public double EndTime { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public double Duration => EndTime - StartTime;

        public double RFFrequencyStart { get; set; }

        public double RFFrequencyEnd { get; set; }

        public double RFFrequencySpan => RFFrequencyEnd - RFFrequencyStart;

        public double SampleInterval => Duration / NumberOfSamples - 1;

        public double SampleInterval_us => SampleInterval * 1.0e6;

        public double SampleRate => 1.0 / SampleInterval;

        public double SampleRate_MHz => SampleRate / 1.0e6;

        public int NumberOfSamples => Samples.Count;

        public List<IQSample> Samples { get; set; }
    }
}
