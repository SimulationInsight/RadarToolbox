using SimulationInsight.SystemMessages;
using Wolverine;

namespace SimulationInsight.Radar;

public class Radar : IRadar
{
    public int RadarId
    {
        get;
        set;
    }

    public IMessageBus Bus
    {
        get;
        set;
    }

    public IRadarProfile RadarProfile
    {
        get;
        set;
    }

    public IScanner Scanner
    {
        get; 
        set;
    }

    public double Time
    {
        get;
        set;
    }

    public Radar(IMessageBus bus, IRadarProfile radarProfile, IScanner scanner)
    {
        Bus = bus;
        RadarProfile = radarProfile;
        Scanner = scanner;
    }

    public void Initialise(double time)
    {
        Time = time;

        SendRadarProfileDemandMessage();

        Scanner.Initialise(time);
    }

    public void Update(double time)
    {
        Time = time;

        Scanner.Update(time);
    }

    public void Finalise(double time)
    {
        Time = time;

        Scanner.Finalise(time);
    }

    public void ProcessRadarProfileDemandMessage(RadarProfileDemandMessage radarProfileDemandMessage)
    {
        RadarProfile.ProfileName = radarProfileDemandMessage.RadarProfileDemand.ProfileName;

        SendRadarProfileStatusMessage();
    }

    public void SendRadarProfileStatusMessage()
    {
        var radarProfileStatusMessage = new RadarProfileStatusMessage()
        {
            MessageId = 1,
            MessageTime = Time, 
            RadarProfileStatus = new RadarProfileStatus()
            {
                RadarId = RadarId,
                ProfileName = RadarProfile.ProfileName,
            }
        };

        Bus.PublishAsync(radarProfileStatusMessage);
    }

    public void SendRadarProfileDemandMessage()
    {
        var radarProfileDemandMessage = new RadarProfileDemandMessage()
        {
            MessageId = 1,
            MessageTime = Time,
            RadarProfileDemand = new RadarProfileDemand()
            {
                RadarId = 1,
                ProfileName = "Profile 1"
            }
        };

        Bus.PublishAsync(radarProfileDemandMessage);
    }
}