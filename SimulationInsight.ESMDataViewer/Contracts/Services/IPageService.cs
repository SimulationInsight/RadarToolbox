using System;

namespace SimulationInsight.ESMDataViewer.Contracts.Services
{
    public interface IPageService
    {
        Type GetPageType(string key);
    }
}
