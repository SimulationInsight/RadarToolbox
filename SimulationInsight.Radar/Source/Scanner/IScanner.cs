namespace SimulationInsight.Radar;

public interface IScanner
{
    ScanPattern ScanPattern { get; set; }

    ScanData ScanData { get; set; }

    void SetScanPattern(ScanPattern scanPattern);

    void InitialiseScan(ScanData scanData);

    void UpdateScan(double time);
}
