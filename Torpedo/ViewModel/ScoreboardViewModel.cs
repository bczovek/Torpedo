using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Torpedo.ViewModel
{
    public class ScoreboardViewModel : AbstractViewModel
    {
        public ScoreboardViewModel()
        {
            Back = new DelegateCommand(OnBack);
        }

        private void OnBack()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            CloseWindow();
        }

        public DelegateCommand Back { get; set; }
    }
}
