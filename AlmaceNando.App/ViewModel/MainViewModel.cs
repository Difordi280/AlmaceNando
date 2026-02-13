using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AlmaceNando.App.ViewModel
{
    public partial class MainViewModel: ObservableValidator
    {
        [ObservableProperty]
        private ViewModelBase _current;


        public ObservableCollection<ViewModelBase> InjectedModules { get; set; }



        public MainViewModel(IEnumerable<ViewModelBase> listviewmodles)
        {
            var order = listviewmodles
                .OrderBy(x => x.Priority)
                .ThenBy(x => x.ViewName);

            InjectedModules = new ObservableCollection<ViewModelBase>(order);

            Current = InjectedModules[0];
            
        }
    }
}
