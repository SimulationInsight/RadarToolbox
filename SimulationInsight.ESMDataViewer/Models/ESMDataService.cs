using SimulationInsight.ESMLibrary;
using SimulationInsight.ESMTrackGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationInsight.ESMDataViewer.Models
{
    public class ESMDataService : IESMDataService
    {
        public ESMTrackData ESMTrackData { get; set; }

        public ESMDataService()
        {
            GetESMData();
        }

        public void GetESMData()
        {
            ESMTrackData = ESMTrackListExamples.GenerateESMTrackListMultiple();
        }
    }
}
