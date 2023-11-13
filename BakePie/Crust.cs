using System;
using System.Collections.Generic;
using System.Text;

namespace BakePie
{
    class Crust
    {
        Boolean isDone;
        Boolean isBurned;

        public bool IsBurned { get => isBurned; set => isBurned = value; }
        public bool IsDone { get => isDone; set => isDone = value; }
    }
}
