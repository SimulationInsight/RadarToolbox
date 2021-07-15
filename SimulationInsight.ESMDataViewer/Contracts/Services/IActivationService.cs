using System.Threading.Tasks;

namespace SimulationInsight.ESMDataViewer.Contracts.Services
{
    public interface IActivationService
    {
        Task ActivateAsync(object activationArgs);
    }
}
