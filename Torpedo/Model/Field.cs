using System;

namespace Torpedo.Model
{
    public class Field : IEquatable<Field>
    {
        public Field(int x, int y)
        {
            X = x;
            Y = y;
            Ship = false;
            Shot = false;
        }
    
        public int X { get; }
        public int Y { get; }
        public bool Ship { get; set; }
        public bool Shot { get; set; }

        public static bool IsValidShipPlace(int x, int y, int size, bool isHorizontal) 
        {
            if (isHorizontal)
            {
                return y + size <= 10;
            }
            else { 
                return x + size <= 10;
            }
        }

        public static bool IsValidField(int x, int y)
        {
            return x < 10 && x >= 0 && y < 10 && y >= 0;
        }

        public bool Equals(Field other)
        {
            return this.X == other.X && this.Y == other.Y;
        }
    }
}
