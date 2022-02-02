using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooProject.Logging;

namespace ZooProject.Cages
{
    class Cage : ICageAnimal
    {
        private static int _id;
        private static ILogger _logger = Logger.CreateInstance();
        private readonly int _idCage;
        private readonly Type _typeAnimal;
        private readonly FoodType _typeFood;   
        private List<Animal> _animals;
        private int _countAnimals;
        private Timer _timer;
        public event Action<Food> FeededAnimals;

        public Cage(Type typeOfAnimal, FoodType food)
        {
            _id++;
            _typeAnimal = typeOfAnimal;
            _typeFood = food;
            _idCage = _id;
            _animals = new List<Animal>();

            _logger.Information($" New cage added  id - {_idCage}  Type of animal - {typeOfAnimal.Name}");

            FeededAnimals += FinishFeeding;
        }

        public void AddAnimal(Animal animal)
        {
            if(animal.GetType() != _typeAnimal )
            {
                throw new Exception($"{animal.GetType()} doesnt suitable to cage type");
            }

            if(_countAnimals + 1 >5)
            {
                throw new IndexOutOfRangeException("count of animals can't be greater than 5 ");
            }


            _countAnimals++; 
            _animals.Add(animal);

            _logger.Information($" New animal added  in {_idCage} cage animal Type - {_typeAnimal.Name},  Name -{animal.Name}");
        }

        public void RemoveAnimal(int animalId)
        {
            Animal animal = null;
            foreach(var an in _animals)
            {
                if(an.Id == animalId)
                {
                    animal = an;
                    _countAnimals--;
                    _logger.Information($" {animalId} id animal is removed in cage {_idCage} ");
                    break;
                }
            }

            if(animal != null)
            {
                _animals.Remove(animal);
            }
        }

        public void KillAnimal(int animalId)
        {
            foreach(var animal in _animals)
            {
                if(animal.Id == animalId)
                {
                    animal.Dead();
                    _logger.Information($"{animalId} id animal is Killed in cage {_idCage}");
                    return;
                }
            }
        }

        public void FeedAnimals(Food food)
        {
            if(food.FoodType != _typeFood)
                throw new ArgumentException($"{_typeAnimal.Name}s can't eat  {food.FoodType} ");

            _timer = new Timer(o => FeededAnimals(food));
            _timer.Change(0, 1000);
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

        private void FinishFeeding(Food food)
        {
            if(food.FoodWeight == 0)
            {
                _logger.Information($" The animals ate all {food.FoodType} in cage {_idCage} ");
                _timer.Dispose();
            }
        }

        
    }
}
