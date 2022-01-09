using System;
using System.Collections.Generic;
using System.Text;

namespace Torpedo.Model
{
    public interface IGameModel
    {
        void Shoot(int x, int y);
        void PlaceShip(IPlayer player, int x, int y, int size, bool isHorizontal);
    }
}
