using System;
using System.Collections.Generic;
using System.Text;

namespace Torpedo.Model
{
    public interface ITurnManager
    {
        void NextTurn();

        bool Shoot(int x, int y);

        bool PlaceShip(string playerName, int x, int y, int size, bool isHorizontal);

        List<Player> players { get; }
    }
}
