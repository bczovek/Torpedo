using System;
using System.Collections.Generic;
using System.Text;

namespace Torpedo.Model
{
    public class TwoPlayerGame
    {

        private TurnManager _players;

        public TwoPlayerGame(string player1Name, string player2Name)
        {
            _players = new TurnManager(new Player(player1Name), new Player(player2Name));
        }

        public void PlaceShip(string playerName, int x, int y, int size, bool isHorizontal)
        {
            if(_players.AttackingPlayer.Name == playerName)
            {
                _players.AttackingPlayer.PlaceShip(x, y, size, isHorizontal);
            }
            if (_players.DefendingPlayer.Name == playerName)
            {
                _players.DefendingPlayer.PlaceShip(x, y, size, isHorizontal);
            }
        }

        public void Shoot(int x, int y)
        {
            _players.Shoot(x, y);
        }

        public Player GetCurrentPlayer()
        {
            return _players.AttackingPlayer;
        }
    }
}
