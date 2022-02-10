using System.Text;
using ZooProject.Animals;
using ZooProject.Foods;
using ZooProject.Logging;

namespace ZooProject.Cages
{
    class Cage : ICageAnimal
    {
        private static int _id;
        private static ILogger _logger = Logger.CreateInstance();
        private readonly int _idCage;
        private readonly Type _typeAnimal;
        private Food _food;
        private List<Animal> _animals;
        private Timer _timerToEatPerSecond;
        public event EventHandler<FoodEventArgs> FeededAnimals;

        public Cage(Type typeOfAnimal, FoodType foodType)
        {
            _id++;
            _typeAnimal = typeOfAnimal;
            _food = new Food(foodType);
            _idCage = _id;
            _animals = new List<Animal>();
        }

        public void AddAnimal(Animal animal)
        {
            if (animal.GetType() != _typeAnimal)
            {
                throw new Exception($"{animal.GetType()} doesnt suitable to cage type");
            }

            if (_animals.Count > 5)
            {
                throw new IndexOutOfRangeException("count of animals can't be greater than 5 ");
            }

            _animals.Add(animal);
        }

        public bool RemoveAnimal(int animalId)
        {
            var animal = _animals.FirstOrDefault(an => an.Id == animalId);

            if (animal != null)
            {
                _animals.Remove(animal);
                return true;
            }
            return false;
        }

        public bool KillAnimal(int animalId)
        {
            var animal = _animals.FirstOrDefault(an => an.Id == animalId);

            if (animal != null)
            {
                animal.Dead();
                return true;
            }
            return false;
        }

        public void PutFood(Food food)
        {
            if (food.FoodType != _food.FoodType)
                throw new ArgumentException($"{_typeAnimal.Name}s can't eat  {food.FoodType} ");

            _food.FoodWeight += food.FoodWeight;
            FeedAnimals();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($" Cage id:  {_idCage}  \n");

            foreach (var animal in _animals)
            {
                sb.Append(animal.ToString() + "\n\n");
            }

            return sb.ToString();
        }


        private void FeedAnimals()
        {
            _timerToEatPerSecond = new Timer(o => FeedingCallback());
            _timerToEatPerSecond.Change(0, 1000);
        }

        private void FeedingCallback()
        {
            foreach (var item in FeededAnimals.GetInvocationList())
            {
                try
                {
                    item.DynamicInvoke(this, new FoodEventArgs(_food));
                    if (_food.FoodWeight == 0)
                    {
                        _logger.Information($" The {_typeAnimal.Name}s ate all the {_food.FoodType} in cage {_idCage} ");
                        _timerToEatPerSecond.Dispose();
                        return;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    _logger.Error(ex.Message);
                }
                catch(ArgumentException ex)
                {
                    _logger.Warning(ex.Message);
                }
                catch(Exception ex)
                {
                    _logger.Warning(ex.Message);
                }
            }
        }
    }
}
