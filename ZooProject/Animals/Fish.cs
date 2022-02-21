using ZooProject.Foods;

namespace ZooProject.Animals
{
    internal class Fish : Animal
    {
        public Fish(string name, double weight) : base(name, weight, FoodType.Warm)
        {
        }
    }
}
