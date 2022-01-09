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
        private bool horizontal = false;
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
            Field target;
            if (direction == 0)
            {
                target = new Field(random.Next(0, 9), random.Next(0, 9));
                OpponentBattlefield.SetFieldAsShot(target.X, target.Y);
                Trace.WriteLine($"{target.Y}, {target.X}");
                return target;
            }
            else {
                return nextTarget;
            }
        }

        public void Update(Field field, bool didHit)
        {
            if (didHit)
            {
                hits.Add(field);

                if (direction == 0)
                {
                    SetDirection();
                }
                if (horizontal)
                {
                    nextTarget = new Field(field.X + direction, field.Y);
                    while (hits.Contains(nextTarget)) 
                    { 
                        nextTarget = new Field(nextTarget.X + direction, nextTarget.Y);
                    }
                }
                else
                {
                    nextTarget = new Field(field.X, field.Y + direction);
                    while (hits.Contains(nextTarget))
                    {
                        nextTarget = new Field(nextTarget.X, nextTarget.Y + direction);
                    }
                }
            }
            else
            {
                if (direction != 0)
                {
                    SetDirection();
                }
            }
        }

        public void TakeShot(int x, int y)
        {
            Battlefield.SetFieldAsShot(x, y);
        }

        private void SetDirection()
        {
            if(direction == 0)
            {
                direction = -1;
            }else if(direction == -1)
            {
                direction = 1;
            }else if (direction == 1)
            {
                horizontal = true;
                direction = -1;
            } else if(direction == 1 && horizontal)
            {
                horizontal = false;
                direction = 0;
            }
        }
    }
}
