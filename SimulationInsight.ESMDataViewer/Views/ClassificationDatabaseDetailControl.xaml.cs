using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

using SimulationInsight.ESMDataViewer.Core.Models;

namespace SimulationInsight.ESMDataViewer.Views
{
    public sealed partial class ClassificationDatabaseDetailControl : UserControl
    {
        public SampleOrder ListDetailsMenuItem
        {
            get { return GetValue(ListDetailsMenuItemProperty) as SampleOrder; }
            set { SetValue(ListDetailsMenuItemProperty, value); }
        }

        public static readonly DependencyProperty ListDetailsMenuItemProperty = DependencyProperty.Register("ListDetailsMenuItem", typeof(SampleOrder), typeof(ClassificationDatabaseDetailControl), new PropertyMetadata(null, OnListDetailsMenuItemPropertyChanged));

        public ClassificationDatabaseDetailControl()
        {
            InitializeComponent();
        }

        private static void OnListDetailsMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as ClassificationDatabaseDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
