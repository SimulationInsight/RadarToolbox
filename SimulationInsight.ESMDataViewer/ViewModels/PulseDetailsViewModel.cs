using System;
using System.Collections.ObjectModel;
using System.Linq;

using CommunityToolkit.Mvvm.ComponentModel;
using SimulationInsight.ESMData.Models;
using SimulationInsight.ESMDataViewer.Contracts.ViewModels;
using SimulationInsight.ESMDataViewer.Core.Contracts.Services;
using SimulationInsight.ESMDataViewer.Models;
using SimulationInsight.ESMLibrary;

namespace SimulationInsight.ESMDataViewer.ViewModels
{
    public class PulseDetailsViewModel : ObservableRecipient, INavigationAware
    {
        private readonly ISampleDataService _sampleDataService;

        private readonly IESMDataService _esmDataService;

        public ObservableCollection<ESMPulseDescriptor> Source { get; } = new ObservableCollection<ESMPulseDescriptor>();

        private ESMPulseDescriptor _selected;

        public ESMPulseDescriptor Selected
        {
            get { return _selected; }
            set { SetProperty(ref _selected, value); }
        }

        public ObservableCollection<ESMPulseDescriptor> SampleItems { get; private set; } = new ObservableCollection<ESMPulseDescriptor>();

        public PulseDetailsViewModel(ISampleDataService sampleDataService, IESMDataService esmDataService)
        {
            _sampleDataService = sampleDataService;
            _esmDataService = esmDataService;
        }

        public async void OnNavigatedTo(object parameter)
        {
            SampleItems.Clear();

            // Replace this with your actual data
            var data = _esmDataService.ESMData.Tracks[0].PulseDescriptors;

            foreach (var item in data)
            {
                SampleItems.Add(item);
            }
        }

        public void OnNavigatedFrom()
        {
        }

        public void EnsureItemSelected()
        {
            if (Selected == null)
            {
                Selected = SampleItems.First();
            }
        }
    }
}
