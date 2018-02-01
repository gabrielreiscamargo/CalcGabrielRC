using CalcGabrielRC.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalcGabrielRC.Infrastructure
{
    class InstanceLocator
    {

        public MainViewModel Main { get; set; }

        public InstanceLocator()
        {
            Main = new MainViewModel();
        }
    }
}
