using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakePie
{
    public class Filling
    {
        public FillingType FillingType { get; set; }
        
        public Boolean isDone { get; set; }

        public Filling(FillingType fillingType)
        {
            FillingType = fillingType;
        }

    }

    public enum FillingType
    {
        Apple,
        Cherry,
        Blueberry,
        Pear,
        Rhubarb
    }
}
