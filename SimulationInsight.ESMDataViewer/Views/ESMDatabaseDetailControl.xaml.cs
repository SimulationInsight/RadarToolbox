using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

using SimulationInsight.ESMDataViewer.Core.Models;

namespace SimulationInsight.ESMDataViewer.Views
{
    public sealed partial class ESMDatabaseDetailControl : UserControl
    {
        public SampleOrder ListDetailsMenuItem
        {
            get { return GetValue(ListDetailsMenuItemProperty) as SampleOrder; }
            set { SetValue(ListDetailsMenuItemProperty, value); }
        }

        public static readonly DependencyProperty ListDetailsMenuItemProperty = DependencyProperty.Register("ListDetailsMenuItem", typeof(SampleOrder), typeof(ESMDatabaseDetailControl), new PropertyMetadata(null, OnListDetailsMenuItemPropertyChanged));

        public ESMDatabaseDetailControl()
        {
            InitializeComponent();
        }

        private static void OnListDetailsMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as ESMDatabaseDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
