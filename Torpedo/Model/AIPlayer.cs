using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Torpedo.Model
{
    public class AIPlayer
    {

        private List<Field> _hits = new List<Field>();

        public AIPlayer()
        {
            Battlefield = new Battlefield();
            OpponentBattlefield = new Battlefield();
            Points = 0;
            Direction = 0;
            Vertical = true;
            NextTarget = null;
        }

        public int Direction { get; set; }
        public bool Vertical { get; set; }
        public Field NextTarget { get; set; }
        public int Points { get; set; }
        public Battlefield Battlefield { get; }
        public Battlefield OpponentBattlefield { get; }
        public void PlaceShips()
        {
            Random random = new Random();
            for (int i = 1; i <= 5; i++)
            {
                int x = random.Next(0, 9);
                int y = random.Next(0, 9);
                bool isHorizontal = random.Next(0, 2) == 1;
                while(!Battlefield.CheckShipPlace(x, y, i, isHorizontal))
                {
                    x = random.Next(0, 9);
                    y = random.Next(0, 9);
                    isHorizontal = random.Next(0, 2) == 1;
                }
                PlaceShip(x, y, i, isHorizontal);
            }
        }

        public bool FieldIsShot(int x, int y)
        {
            return Battlefield.IsShot(x, y);
        }

        public bool IsGameOver()
        {
            return Battlefield.IsGameOver();
        }

        private void PlaceShip(int x, int y, int size, bool isHorizontal)
        {
            for (int i = 0; i < size; i++)
            {
                if (isHorizontal)
                {
                    Battlefield.SetFieldAsShip(x, y + i);
                } else
                {
                    Battlefield.SetFieldAsShip(x + i, y);
                }
            }
        }

        public bool ShipPlacedAtField(int x, int y)
        {
            return Battlefield.IsShip(x, y);
        }

        public Field Shoot()
        {
            if (Direction == 0)
            {
                RandomNextTarget();
            }

            while(!Field.IsValidField(NextTarget.X, NextTarget.Y))
            {
                SetDirection();
                if(Direction == 0)
                {
                    RandomNextTarget();
                    break;
                }
                SetNextTarget();
            }

            return NextTarget;
        }

        private void RandomNextTarget()
        {
            Random random = new Random();
            int x;
            int y;
            do
            {
                x = random.Next(0, 10);
                y = random.Next(0, 10);
            }
            while (OpponentBattlefield.IsShot(x, y));
            NextTarget = new Field(x, y);
            OpponentBattlefield.SetFieldAsShot(NextTarget.X, NextTarget.Y);
        }

        public void Update(Field field, bool didHit)
        {
            OpponentBattlefield.SetFieldAsShot(field.X, field.Y);
            if (didHit && !_hits.Contains(field))
            {
                _hits.Add(field);
                Points++;
                if (Direction == 0)
                {
                    SetDirection();
                }
                SetNextTarget();
            }
            else
            {
                if (Direction != 0)
                {
                    SetDirection();
                    SetNextTarget();
                }
            }
        }

        private void SetNextTarget()
        {
            if (Vertical)
            {
                NextTarget = new Field(NextTarget.X + Direction, NextTarget.Y);
                while (_hits.Contains(NextTarget))
                {
                    NextTarget = new Field(NextTarget.X + Direction, NextTarget.Y);
                }
            }
            else
            {
                NextTarget = new Field(NextTarget.X, NextTarget.Y + Direction);
                while (_hits.Contains(NextTarget))
                {
                    NextTarget = new Field(NextTarget.X, NextTarget.Y + Direction);
                }
            }
        }

        public void TakeShot(int x, int y)
        {
            Battlefield.SetFieldAsShot(x, y);
        }

        private void SetDirection()
        {

            if (Direction == 0)
            {
                Direction = -1;
            }
            else if (Direction == -1)
            {
                Direction = 1;
            }
            else if (Direction == 1 && _hits.Count == 1)
            {
                Vertical = false;
                NextTarget = _hits[0];
                Direction = -1;
            }
            else if (Direction == 1 && !Vertical)
            {
                Reset();
            }
            else {
                Reset();
            }
        }

        private void Reset()
        {
            Direction = 0;
            _hits.Clear();
            Vertical = true;
        }
    }
}
