using System.Threading.Tasks;

namespace SimulationInsight.ESMDataViewer.Activation
{
    public interface IActivationHandler
    {
        bool CanHandle(object args);

        Task HandleAsync(object args);
    }
}
