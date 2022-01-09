using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Torpedo.Model
{
    public class AIPlayer
    {

        private List<Field> hits = new List<Field>();
        private int direction = 0;
        private bool horizontal = true;
        private Field nextTarget;

        public AIPlayer()
        {
            Battlefield = new Battlefield();
            OpponentBattlefield = new Battlefield();
            Points = 0;
        }

        public int Points { get; set; }
        public Battlefield Battlefield { get; }
        public Battlefield OpponentBattlefield { get; }
        public void PlaceShips()
        {
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                PlaceShip(random.Next(0, 4), random.Next(0, 4), i, false);
            }
        }

        private void PlaceShip(int x, int y, int size, bool isHorizontal)
        {
            for (int i = 0; i < size; i++)
            {
                Battlefield.SetFieldAsShip(x + i, y);
            }
        }

        public bool ShipPlacedAtField(int x, int y)
        {
            return Battlefield.IsShip(x, y);
        }

        public Field Shoot()
        {
            Random random = new Random();
            if (direction == 0)
            {
                nextTarget = new Field(random.Next(0, 9), random.Next(0, 9));
                OpponentBattlefield.SetFieldAsShot(nextTarget.X, nextTarget.Y);
            }

            return nextTarget;
        }

        public void Update(Field field, bool didHit)
        {
            if (didHit)
            {
                hits.Add(field);
                Points++;
                if (direction == 0)
                {
                    SetDirection();
                }
                SetNextTarget();
            }
            else
            {
                if (direction != 0)
                {
                    SetDirection();
                    SetNextTarget();
                }
            }
        }

        private void SetNextTarget()
        {
            if (horizontal)
            {
                nextTarget = new Field(nextTarget.X + direction, nextTarget.Y);
                while (hits.Contains(nextTarget))
                {
                    nextTarget = new Field(nextTarget.X + direction, nextTarget.Y);
                }
            }
            else
            {
                nextTarget = new Field(nextTarget.X, nextTarget.Y + direction);
                while (hits.Contains(nextTarget))
                {
                    nextTarget = new Field(nextTarget.X, nextTarget.Y + direction);
                }
            }
        }

        public void TakeShot(int x, int y)
        {
            Battlefield.SetFieldAsShot(x, y);
        }

        private void SetDirection()
        {

            if (direction == 0)
            {
                direction = -1;
            }
            else if (direction == -1)
            {
                direction = 1;
            }
            else if (direction == 1 && hits.Count == 1)
            {
                horizontal = false;
                nextTarget = hits[0];
                direction = -1;
            }
            else if (direction == 1 && !horizontal)
            {
                Reset();
            }
            else {
                Reset();
            }
        }

        private void Reset()
        {
            direction = 0;
            hits.Clear();
            horizontal = true;
        }
    }
}
