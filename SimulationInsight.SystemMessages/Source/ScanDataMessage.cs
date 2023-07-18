using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationInsight.SystemMessages;

public class ScanDataMessage : SystemMessage
{
    public ScanDataMessage()
    {
        MessageType = SystemMessageType.ScanData;
    }

    public ScanData ScanData { get; set; }
}
