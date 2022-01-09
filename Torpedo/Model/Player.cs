using System;
using System.Collections.Generic;
using System.Text;

namespace Torpedo.Model
{
    public class Player : IPlayer
    {
        private Battlefield Battlefield;

        private Battlefield OpponentBattlefield;

        public Player(string name)
        {
            Battlefield = new Battlefield();
            OpponentBattlefield = new Battlefield();
            Name = name;
            Points = 0;
        }

        public int Points { get; set; }
        public string Name { get; } 

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
