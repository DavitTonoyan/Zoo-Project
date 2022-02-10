using ZooProject.Foods;

namespace ZooProject.Animals
{
    internal class Lion : Animal
    {
        public Lion(string name, double weight) : base(name, weight, FoodType.Meat)
        {
        }
    }
}
