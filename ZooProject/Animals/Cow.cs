using ZooProject.Foods;

namespace ZooProject.Animals
{
    internal class Cow : Animal
    {
        public Cow(string name, double weight) : base(name, weight, FoodType.Grass)
        {
        }
    }
}
