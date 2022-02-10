using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooProject.Foods;

namespace ZooProject.Stomachs
{
    internal interface IStomach
    {
        double Weight { get; }
        double MaxStomachSize { get; }
        double GetEatWeight(FoodEventArgs foodEventArgs);
        bool IsDyingForHungry();
    }
}
