using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakePie
{
    public class Pie
    {
        // Properties for crust, filling, and topping
        public Crust PieCrust { get; set; }
        public Filling PieFilling { get; set; }
        public Topping PieTopping { get; set; }

        // Constructor to initialize default values
        public Pie(Crust crust, Filling filling)
        {
            // Set default values
            PieCrust = crust;
            PieFilling = filling;
            PieTopping = Topping.None;
        }
    }
    public enum Topping
    {
        None,
        Fruit,
        WhippedCream,
        Nuts,
        Chocolate,
        Sprinkles
    }
}
