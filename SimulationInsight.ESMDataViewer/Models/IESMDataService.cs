using SimulationInsight.ESMLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationInsight.ESMDataViewer.Models
{
    public interface IESMDataService
    {
        ESMData.Models.ESMData ESMData { get; set; }
    }
}
