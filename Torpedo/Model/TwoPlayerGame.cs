using System;
using System.Collections.Generic;
using System.Text;

namespace Torpedo.Model
{
    public class TwoPlayerGame : IGameModel
    {

        private Players _players;

        public TwoPlayerGame(string player1Name, string player2Name)
        {
            _players = new Players(new Player(player1Name), new Player(player2Name));
        }

        public void PlaceShip(IPlayer player, int x, int y, int size, bool isHorizontal)
        {
            throw new NotImplementedException();
        }

        public void Shoot(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}
