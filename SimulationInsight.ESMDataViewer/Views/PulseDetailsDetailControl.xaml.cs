using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using SimulationInsight.ESMData.Models;
using SimulationInsight.ESMDataViewer.Core.Models;
using SimulationInsight.ESMLibrary;

namespace SimulationInsight.ESMDataViewer.Views
{
    public sealed partial class PulseDetailsDetailControl : UserControl
    {
        public PulseDescriptorDTO ListDetailsMenuItem
        {
            get { return GetValue(ListDetailsMenuItemProperty) as PulseDescriptorDTO; }
            set { SetValue(ListDetailsMenuItemProperty, value); }
        }

        public static readonly DependencyProperty ListDetailsMenuItemProperty = DependencyProperty.Register("ListDetailsMenuItem", typeof(PulseDescriptorDTO), typeof(PulseDetailsDetailControl), new PropertyMetadata(null, OnListDetailsMenuItemPropertyChanged));

        public PulseDetailsDetailControl()
        {
            InitializeComponent();
        }

        private static void OnListDetailsMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as PulseDetailsDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
