using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakePie
{
    public class Recipe
    {
        public Topping PieTopping { get; set; }

        public Recipe()
        {
            PieTopping = Topping.None;
        }
    }

}
