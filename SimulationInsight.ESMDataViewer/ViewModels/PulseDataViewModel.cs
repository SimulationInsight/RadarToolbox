using System;
using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;
using SimulationInsight.ESMData.Models;
using SimulationInsight.ESMDataViewer.Contracts.ViewModels;
using SimulationInsight.ESMDataViewer.Core.Contracts.Services;
using SimulationInsight.ESMDataViewer.Models;

namespace SimulationInsight.ESMDataViewer.ViewModels
{
    public class PulseDataViewModel : ObservableRecipient, INavigationAware
    {
        private readonly ISampleDataService _sampleDataService;

        private readonly IESMDataService _esmDataService;

        public ObservableCollection<PulseDescriptorDTO> Source { get; } = new ObservableCollection<PulseDescriptorDTO>();

        public PulseDataViewModel(ISampleDataService sampleDataService, IESMDataService esmDataService)
        {
            _sampleDataService = sampleDataService;
            _esmDataService = esmDataService;
        }

        public async void OnNavigatedTo(object parameter)
        {
            Source.Clear();
            
            var data = _esmDataService.ESMData.Tracks[0].PulseDescriptors;

            foreach (var item in data)
            {
                Source.Add(item);
            }
        }

        public void OnNavigatedFrom()
        {
        }
    }
}
