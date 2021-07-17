using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationInsight.ESMData.Entities
{
    [Table("Recording")]
    public class Recording
    {
        public int RecordingId { get; set; }

        public int RecordingNumber { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public int FileName { get; set; }

        public int MissionId { get; set; }
        public Mission Mission { get; set; }
    }
}
