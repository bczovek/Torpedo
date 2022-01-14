namespace Torpedo.Model
{
    public class Player
    {
        private Battlefield _battlefield;

        private Battlefield _opponentBattlefield;

        public Player(string name)
        {
            _battlefield = new Battlefield();
            _opponentBattlefield = new Battlefield();
            Name = name;
            Points = 0;
        }

        public int Points { get; set; }
        public string Name { get; } 

        public bool PlaceShip(int x, int y, int size, bool isHorizontal)
        {
            if (_battlefield.CheckShipPlace(x, y, size, isHorizontal))
            {
                for (int i = 0; i < size; i++)
                {
                    if (isHorizontal)
                    {
                        _battlefield.SetFieldAsShip(x, y + i);
                    }
                    else
                    {
                        _battlefield.SetFieldAsShip(x + i, y);
                    }
                }
                return true;
            }

            return false;
        }

        public bool ShipPlacedAtField(int x, int y)
        {
            return _battlefield.IsShip(x, y);
        }

        public bool FieldIsShot(int x, int y)
        {
            return _battlefield.IsShot(x, y);
        }

        public void ClearShips()
        {
            this._battlefield.ResetField();
        }

        public bool IsGameOver()
        {
            return _battlefield.IsGameOver();
        }

        public bool Shoot(int x, int y, bool isHit)
        {
            if (!_opponentBattlefield.IsShot(x, y))
            {
                _opponentBattlefield.SetFieldAsShot(x, y);
                if (isHit)
                {
                    _opponentBattlefield.SetFieldAsShip(x, y);
                    Points++;
                }
                return isHit;
            }

            return true;
        }

        public void TakeShot(int x, int y)
        {
            _battlefield.SetFieldAsShot(x, y);
        }
    }
}
