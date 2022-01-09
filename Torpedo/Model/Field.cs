using System;
using System.Collections.Generic;
using System.Text;

namespace Torpedo.Model
{
    public struct Field
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
    }
}
