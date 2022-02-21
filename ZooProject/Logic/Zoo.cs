using System.Text;
using ZooProject.Animals;
using ZooProject.Cages;
using ZooProject.Foods;

namespace ZooProject.Logic
{
    internal class Zoo
    {
        private List<ICageAnimal> _cages = new List<ICageAnimal>();

        public void AddCage(int typeOfAnimal)
        {
            Type typeAnimal = null;
            FoodType typeFood;
            switch (typeOfAnimal)
            {
                case 1:
                    {
                        typeAnimal = typeof(Lion);
                        typeFood = FoodType.Meat;
                        break;
                    }
                case 2:
                    {
                        typeAnimal = typeof(Cow);
                        typeFood = FoodType.Grass;
                        break;
                    }
                case 3:
                    {
                        typeAnimal = typeof(Fish);
                        typeFood = FoodType.Warm;
                        break;
                    }
                default:
                    {
                        throw new ArgumentException(" The type of animal doesn't exist ");
                    }
            }

            _cages.Add(new Cage(typeAnimal, typeFood));
        }

        public void AddAnimal(int cageId, int typeOfAnimal, string name, double weight)
        {
            Animal animal = null;
            switch (typeOfAnimal)
            {
                case 1:
                    {
                        animal = new Lion(name, weight);
                        break;
                    }
                case 2:
                    {
                        animal = new Cow(name, weight);
                        break;
                    }
                case 3:
                    {
                        animal = new Fish(name, weight);
                        break;
                    }
                default:
                    {
                        throw new ArgumentException(" The type of animal doesn't exist ");
                    }
            }

            _cages[cageId].AddAnimal(animal);
            _cages[cageId].FeededAnimals += animal.Eat;
        }

        public Food SetFood(int foodType, double foodWeight)
        {
            Food food = null;
            FoodType fType;

            switch (foodType)
            {
                case 1:
                    {
                        fType = FoodType.Meat;
                        break;
                    }
                case 2:
                    {
                        fType = FoodType.Grass;
                        break;
                    }
                case 3:
                    {
                        fType = FoodType.Warm;
                        break;
                    }
                default:
                    {
                        throw new ArgumentException(" The food type doesn't exist ");
                    }
            }

            food = new Food(fType, foodWeight);
            return food;
        }

        public void FeedAnimal(int cageId, Food food)
        {
            _cages[cageId].PutFood(food);
        }

        public bool KillAnimalFromCage(int cageId, int animalId)
        {
            if (cageId < 0 || cageId >= _cages.Count)
            {
                throw new ArgumentOutOfRangeException("Cage Id  is  out of range");
            }

            return _cages[cageId].KillAnimal(animalId);
        }

        public bool RemoveAnimalFromCage(int cageId, int animalId)
        {
            if (cageId < 0 || cageId >= _cages.Count)
            {
                throw new ArgumentOutOfRangeException("Cage Id  is  out of range");
            }

            return _cages[cageId].RemoveAnimal(animalId);
        }
        public string ShowCages()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var cage in _cages)
            {
                sb.Append(cage.ToString());
                sb.Append("\n\n");
            }
            return sb.ToString();
        }
    }
}
