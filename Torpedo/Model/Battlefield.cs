using System;
using System.Collections.Generic;
using System.Text;

namespace Torpedo.Model
{
    public class Battlefield
    {
        private const int Battlefield_Height = 10;
        private const int Battlefield_Width = 10;
        private Field[,] _fields = new Field[Battlefield_Height, Battlefield_Width];

        public void ResetField()
        {
            for (int i = 0; i < Battlefield_Height; i++)
            {
                for (int j = 0; j < Battlefield_Width; j++)
                {
                    _fields[i, j] = new Field(i, j);
                }
            }
        }

        public Battlefield()
        {
            for (int i = 0; i < Battlefield_Height; i++)
            {
                for (int j = 0; j < Battlefield_Width; j++)
                {
                    _fields[i, j] = new Field(i, j);
                }
            }
        }

        public void SetFieldAsShip(int x, int y)
        {
            Field field = _fields[x, y];
            field.Ship = true;
            _fields[x, y] = field;
        }

        public void SetFieldAsShot(int x, int y)
        {
            Field field = _fields[x, y];
            field.Shot = true;
            _fields[x, y] = field;
        }

        public bool IsShip(int x, int y)
        {
            return _fields[x, y].Ship;
        }

        public bool IsShot(int x, int y)
        {
            return _fields[x, y].Shot;
        }

        public bool IsGameOver()
        {
            for (int i = 0; i < _fields.GetLength(0); i++)
            {
                for (int j = 0; j < _fields.GetLength(1); j++)
                {
                    if(_fields[i, j].Ship && !_fields[i, j].Shot)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool CheckShipPlace(int x, int y, int size, bool isHorizontal)
        {
            if(!Field.IsValidShipPlace(x, y, size, isHorizontal))
            {
                return false;
            }
            for (int i = 0; i < size; i++)
            {
                int xx = isHorizontal ? x : (x + i);
                int yy = isHorizontal ? (y + i) : y;
                if (_fields[xx, yy].Ship)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
