using System;
using System.Collections.Generic;
using System.Text;

namespace Torpedo.Model
{
    public class OnePlayerGame : IGameModel
    {
        private Players _players;

        public OnePlayerGame(string playerName)
        {
            _players = new Players(new Player(playerName), new AIPlayer());
        }

        public void PlaceShip(IPlayer player, int x, int y, int size, bool isHorizontal)
        {
            throw new NotImplementedException();
        }

        public void Shoot(int x, int y)
        {
            _players.Shoot(x, y);
        }
    }
}
