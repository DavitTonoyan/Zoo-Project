using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooProject.Cages
{
    class Cage : ICageAnimal
    {
        private static int id;
        private readonly int idCage;
        private readonly Type typeAnimal;
        private readonly FoodType typeFood;   
        private List<Animal> animals;
        private int countAnimals;
        private Timer timer;
        public event Action<Food> FeedingAnimals;

        public Cage(Type typeOfAnimal, FoodType food)
        {
            id++;
            typeAnimal = typeOfAnimal;
            typeFood = food;
            idCage = id;
            animals = new List<Animal>();
            FeedingAnimals += FinishFeeding;
        }

        public void AddAnimal(Animal animal)
        {
            if(animal.GetType() != typeAnimal )
            {
                throw new Exception($"{animal.GetType()} doesnt corresponding to cage type");
            }

            if(countAnimals + 1 >5)
            {
                throw new IndexOutOfRangeException("ERROR: count of animals can't be greater than 5 ");
            }


            countAnimals++; 
            animals.Add(animal);
        }

        public void RemoveAnimal(int animalId)
        {
            Animal animal = null;
            foreach(var an in animals)
            {
                if(an.Id == animalId)
                {
                    animal = an;
                    countAnimals--;
                    break;
                }
            }

            if(animal != null)
            {
                animals.Remove(animal);
            }
        }

        public void KillAnimal(int animalId)
        {
            foreach(var animal in animals)
            {
                if(animal.Id == animalId)
                {
                    animal.Dead();
                    return;
                }
            }
        }

        public void FeedAnimals(Food food)
        {
            if(food.FoodType != typeFood)
                throw new ArgumentException($"{typeAnimal.Name}s can't eat  {food.FoodType} ");

            timer = new Timer(o => FeedingAnimals(food));
            timer.Change(0, 1000);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($" Cage id:  {idCage}  \n");

            foreach (var animal in animals)
            {
                sb.Append(animal.ToString() + "\n\n");
            }

            return sb.ToString();
        }

        private void FinishFeeding(Food food)
        {
            if(food.FoodWeight == 0)
            {
                timer.Dispose();
            }
        }

        
    }
}
