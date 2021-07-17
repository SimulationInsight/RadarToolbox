using SimulationInsight.ESMLibrary;
using SimulationInsight.ESMDataGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationInsight.ESMDataViewer.Models
{
    public class ESMDataService : IESMDataService
    {
        public ESMData.Models.ESMData ESMData { get; set; }

        public ESMDataService()
        {
            GetESMData();
        }

        public void GetESMData()
        {
            ESMData = ESMDataGeneratorExamples.GenerateESMDataMultiple();
        }
    }
}
