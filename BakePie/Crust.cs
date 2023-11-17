using System;
using System.Collections.Generic;
using System.Text;

namespace BakePie
{
    public class Crust
    {
        Boolean isDone { get; set; }
        Boolean isBurned { get; set; }
        public Filling pieFilling { get; set; }

        public bool IsBurned { get => isBurned; set => isBurned = value; }
        public bool IsDone { get => isDone; set => isDone = value; }
    }
}
