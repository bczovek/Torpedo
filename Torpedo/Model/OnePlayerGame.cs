using System;
using System.Collections.Generic;
using System.Text;

namespace Torpedo.Model
{
    public class OnePlayerGame
    {
        private AITurnManager _players;

        public OnePlayerGame(string playerName)
        {
            _players = new AITurnManager(new Player(playerName));
        }

        public void PlaceShip(int x, int y, int size, bool isHorizontal)
        {
            _players.Player.PlaceShip(x, y, size, isHorizontal);
        }

        public void Shoot(int x, int y)
        {
            _players.Shoot(x, y);
        }

        public void Proceed() { 
            _players.Proceed();
        }
    }
}
