using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooProject.Foods
{
    internal class FoodEventArgs: EventArgs
    {
        public Food Food { get; set; }
        public FoodEventArgs(Food food)
        {
            Food = food;
        }
    }
}
