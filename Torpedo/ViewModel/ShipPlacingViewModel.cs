using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using Torpedo.Views;

namespace Torpedo.ViewModel
{
    class ShipPlacingViewModel : AbstractViewModel
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
            GameWindow gameWindow = new GameWindow();
            CloseWindow();
            gameWindow.Show();
        }

    }
}
