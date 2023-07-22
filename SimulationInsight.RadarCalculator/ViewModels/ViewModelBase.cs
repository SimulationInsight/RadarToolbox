using CommunityToolkit.Mvvm.ComponentModel;
using SimulationInsight.RadarCalculator.Views;

namespace SimulationInsight.RadarCalculator.ViewModels;

public class ViewModelBase : ObservableRecipient
{
    public PageBase Page
    {
        get;
        set;
    }

    public void UpdateBindings()
    {
        if (Page is not null)
        {
            Page.UpdateBindings();
        }
    }
}