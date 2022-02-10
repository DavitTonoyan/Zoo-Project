using ZooProject.Foods;

namespace ZooProject.Cages
{
    internal interface ICageAnimal
    {
        void AddAnimal(Animal animal);
        bool RemoveAnimal(int animalId);
        bool KillAnimal(int animalId);
        void PutFood(Food food);
        event EventHandler<FoodEventArgs> FeededAnimals;
    }
}
