﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Torpedo.Model
{
    public class AIPlayer
    {

        private List<Field> hits = new List<Field>();
        private int direction = 0;
        private bool vertical = true;
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
            if (direction == 0)
            {
                RandomNextTarget();
            }

            while(!Field.IsValidField(nextTarget.X, nextTarget.Y))
            {
                SetDirection();
                if(direction == 0)
                {
                    RandomNextTarget();
                    break;
                }
                SetNextTarget();
            }

            return nextTarget;
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
            nextTarget = new Field(x, y);
            OpponentBattlefield.SetFieldAsShot(nextTarget.X, nextTarget.Y);
        }

        public void Update(Field field, bool didHit)
        {
            OpponentBattlefield.SetFieldAsShot(field.X, field.Y);
            if (didHit && !hits.Contains(field))
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
            if (vertical)
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
                vertical = false;
                nextTarget = hits[0];
                direction = -1;
            }
            else if (direction == 1 && !vertical)
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
            vertical = true;
        }
    }
}
