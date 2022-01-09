using System;
using System.Collections.Generic;
using System.Text;

namespace Torpedo.Model
{
    public class AIPlayer : IPlayer
    {
        public AIPlayer()
        {
            Battlefield = new Battlefield();
            OpponentBattlefield = new Battlefield();
            Points = 0;
        }

        public int Points { get; set; }
        public Battlefield Battlefield { get; }
        public Battlefield OpponentBattlefield { get; }
        public void PlaceShip()
        {
            throw new NotImplementedException();
        }

        public bool ShipPlacedAtField(int x, int y)
        {
            return Battlefield.IsShip(x, y);
        }

        public void Shoot(int x, int y, bool isHit)
        {
            OpponentBattlefield.SetFieldAsShot(x, y);
            if(isHit)
            {
                OpponentBattlefield.SetFieldAsShip(x, y);
                Points++;
            }
        }

        public void TakeShot(int x, int y)
        {
            Battlefield.SetFieldAsShot(x, y);
        }
    }
}
