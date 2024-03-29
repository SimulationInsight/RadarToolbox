﻿using SimulationInsight.Core;
using SimulationInsight.SystemMessages;

namespace SimulationInsight.Radar;

public interface IScanner : IExecutableModel
{
    ScanPattern ScanPattern
    {
        get; set;
    }

    ScanData ScanData
    {
        get; set;
    }

    void SetScanPattern(ScanPattern scanPattern);
}