using System;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace AlmaceNando.App.ViewModel
{
    public abstract partial class ViewModelBase: ObservableValidator
    {

        public abstract string ViewName { get;  }
        public abstract int Priority { get; }


    }
}
