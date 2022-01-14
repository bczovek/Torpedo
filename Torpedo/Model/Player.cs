namespace Torpedo.Model
{
    public class Player
    {
        public Battlefield Battlefield { get; private set; }

        public Battlefield OpponentBattlefield { get; private set; }

        public Player(string name)
        {
            Battlefield = new Battlefield();
            OpponentBattlefield = new Battlefield();
            Name = name;
            Points = 0;
        }

        public int Points { get; set; }
        public string Name { get; } 

        public bool PlaceShip(int x, int y, int size, bool isHorizontal)
        {
            if (Battlefield.CheckShipPlace(x, y, size, isHorizontal))
            {
                for (int i = 0; i < size; i++)
                {
                    if (isHorizontal)
                    {
                        Battlefield.SetFieldAsShip(x, y + i);
                    }
                    else
                    {
                        Battlefield.SetFieldAsShip(x + i, y);
                    }
                }
                return true;
            }

            return false;
        }

        public bool ShipPlacedAtField(int x, int y)
        {
            return Battlefield.IsShip(x, y);
        }

        public bool FieldIsShot(int x, int y)
        {
            return Battlefield.IsShot(x, y);
        }

        public void ClearShips()
        {
            this.Battlefield.ResetField();
        }

        public bool IsGameOver()
        {
            return Battlefield.IsGameOver();
        }

        public bool Shoot(int x, int y, bool isHit)
        {
            if (!OpponentBattlefield.IsShot(x, y))
            {
                OpponentBattlefield.SetFieldAsShot(x, y);
                if (isHit)
                {
                    OpponentBattlefield.SetFieldAsShip(x, y);
                    Points++;
                }
                return isHit;
            }

            return true;
        }

        public void TakeShot(int x, int y)
        {
            Battlefield.SetFieldAsShot(x, y);
        }
    }
}
