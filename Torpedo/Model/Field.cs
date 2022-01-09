using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

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

        public bool Equals(Field other)
        {
            return this.X == other.X && this.Y == other.Y;
        }
    }
}
