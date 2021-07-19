using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using SimulationInsight.ESMData.Models;
using SimulationInsight.ESMDataViewer.Contracts.ViewModels;
using SimulationInsight.ESMDataViewer.Models;
using SimulationInsight.ESMLibrary;

namespace SimulationInsight.ESMDataViewer.ViewModels
{
    public class PulseSummaryViewModel : ObservableRecipient, INavigationAware
    {

        private readonly IESMDataService _esmDataService;

        private List<PulseDescriptorDTO> PulseDescriptors { get; set; }

        public ObservableCollection<PulseDescriptorDTO> Source { get; } = new ObservableCollection<PulseDescriptorDTO>();

        public PulseSummaryViewModel(IESMDataService esmDataService)
        {
            _esmDataService = esmDataService;
        }

        public async void OnNavigatedTo(object parameter)
        {
            PulseDescriptors = _esmDataService.ESMData.Tracks[0].PulseDescriptors;
        }

        public void OnNavigatedFrom()
        {
        }
    }
}
