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
