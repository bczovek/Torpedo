using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using Torpedo.Views;

namespace Torpedo.ViewModel
{
    class PlayerNameViewModel : INotifyPropertyChanged
    {
        public PlayerNameViewModel()
        {
            Start = new DelegateCommand(OnStart);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private string _firstPlayer;
        private string _secondPlayer;
        private bool _twoPlayerGame;

        public string FirstPlayer { 
            get => _firstPlayer;
            set => _firstPlayer = value; }

        public string SecondPlayer
        {
            get => _secondPlayer;
            set => _secondPlayer = value;
        }

        public DelegateCommand Start { get; set; }

        public bool TwoPlayerGame
        {
            get => _twoPlayerGame;
            set
            {
                _twoPlayerGame = value;
                NotifyChange(nameof(TwoPlayerGame));
            }
        }

        private void OnStart()
        {
            if (_twoPlayerGame)
            {
                if(!(string.IsNullOrWhiteSpace(_firstPlayer) || string.IsNullOrWhiteSpace(_secondPlayer)))
                {
                    ShipPlacingWindow firstPlayerShipWindow = new ShipPlacingWindow();
                    ShipPlacingWindow secondPlayerShipWindow = new ShipPlacingWindow();
                    firstPlayerShipWindow.Show();
                    secondPlayerShipWindow.Show();
                    //CloseWindow();
                }
            }
            else
            {
                if(!string.IsNullOrWhiteSpace(_firstPlayer))
                {
                    ShipPlacingWindow firstPlayerShipWindow = new ShipPlacingWindow();
                    firstPlayerShipWindow.Show();
                    //CloseWindow();
                }
            }
        }

        private void NotifyChange(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
