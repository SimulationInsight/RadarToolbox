using System;
using System.Collections.ObjectModel;

using CommunityToolkit.Mvvm.ComponentModel;

using SimulationInsight.ESMDataViewer.Contracts.ViewModels;
using SimulationInsight.ESMDataViewer.Core.Contracts.Services;
using SimulationInsight.ESMDataViewer.Models;
using SimulationInsight.ESMLibrary;

namespace SimulationInsight.ESMDataViewer.ViewModels
{
    public class TrackDataViewModel : ObservableRecipient, INavigationAware
    {
        private readonly ISampleDataService _sampleDataService;

        private readonly IESMDataService _esmDataService;

        public ObservableCollection<ESMTrack> Source { get; } = new ObservableCollection<ESMTrack>();

        public TrackDataViewModel(ISampleDataService sampleDataService, IESMDataService esmDataService)
        {
            _sampleDataService = sampleDataService;
            _esmDataService = esmDataService;
        }

        public async void OnNavigatedTo(object parameter)
        {
            Source.Clear();

            var data = _esmDataService.ESMData.Tracks;

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
