using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Torpedo.Views;

namespace Torpedo.ViewModel
{
    public class MainViewModel : AbstractViewModel
    {
        public MainViewModel()
        {
            Play = new DelegateCommand(OnPlay);
            ShowScoreboard = new DelegateCommand(OnShowScoreboard);
            Exit = new DelegateCommand(OnExit);
        }

        private void OnExit()
        {
            CloseWindow();
        }

        private void OnShowScoreboard()
        {
            ScoreboardWindow scoreboardWindow = new ScoreboardWindow();
            CloseWindow();
            scoreboardWindow.Show();
        }

        private void OnPlay()
        {
            PlayerNameWindow playerNameWindow = new PlayerNameWindow();
            CloseWindow();
            playerNameWindow.Show();
        }

        public DelegateCommand Play { get; set; }
        public DelegateCommand ShowScoreboard { get; set; }
        public DelegateCommand Exit { get; set; }
    }
}
