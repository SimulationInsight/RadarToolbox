using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml.Controls;
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
