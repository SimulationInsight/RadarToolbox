namespace SimulationInsight.SystemMessages;

public enum SystemMessageType
{
    Undefined = 0,
    RadarProfileDemand,
    RadarProfileStatus,
    ScanControlData,
    ScanData,
    AzimuthChangePulse,
    WaveformData,
    VideoData,
    TargetReports,
    UpdatedTrack,
    PredictedTrack
}