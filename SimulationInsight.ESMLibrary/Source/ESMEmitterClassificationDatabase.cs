using SimulationInsight.Core;
using SimulationInsight.ESMData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationInsight.ESMLibrary.Source
{
    public class ESMEmitterClassificationDatabase
    {
        public List<ESMEmitterDatabaseLine> EmitterList { get; set; }

        public int NumberOfEmitters => EmitterList.Count;

        public void ReadFromFile(string fileName)
        {
            EmitterList = CsvExtensionMethods.ReadFromCsvFile<ESMEmitterDatabaseLine>(fileName);
        }

        public void WriteToFile(string fileName)
        {
            EmitterList.WriteToCsvFile(fileName);
        }
    }
}
