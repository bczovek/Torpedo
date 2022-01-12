using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Torpedo.ViewModel
{
    class PlayerNameViewModel : INotifyPropertyChanged
    {

        public PlayerNameViewModel()
        {
            Start = new DelegateCommand(OnStart);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private bool _twoPlayerGame;
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
        }

        private void NotifyChange(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
