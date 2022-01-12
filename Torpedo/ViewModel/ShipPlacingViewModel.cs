using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Torpedo.ViewModel
{
    class ShipPlacingViewModel
    {
        public ShipPlacingViewModel()
        {
            Reset = new DelegateCommand(OnReset);
            Done = new DelegateCommand(OnDone);
        }

        public DelegateCommand Reset { get; set; }
        public DelegateCommand Done { get; set; }

        private void OnReset()
        {

        }

        private void OnDone()
        {

        }
    }
}
