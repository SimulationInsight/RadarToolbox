using System.Threading.Tasks;

using Microsoft.UI.Xaml;

namespace SimulationInsight.ESMDataViewer.Contracts.Services
{
    public interface IThemeSelectorService
    {
        ElementTheme Theme { get; }

        Task InitializeAsync();

        Task SetThemeAsync(ElementTheme theme);

        Task SetRequestedThemeAsync();
    }
}
