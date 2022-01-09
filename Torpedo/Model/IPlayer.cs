using System;
using System.Collections.Generic;
using System.Text;

namespace Torpedo.Model
{
    public interface IPlayer
    {
        void TakeShot(int x, int y);

        void Shoot(int x, int y, bool isHit);

        void PlaceShip();

        bool ShipPlacedAtField(int x, int y);
    }
}
