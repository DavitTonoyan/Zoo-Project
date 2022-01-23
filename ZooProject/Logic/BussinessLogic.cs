using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooProject.Logic
{
    internal class BussinessLogic :IDisposable
    {
        private List<Animal> animals  = new List<Animal>();
        //private ManageHungryTime manageHungry = new ManageHungryTime();

        public void AddAnimal(int typeOfAnimal, string name,double weight)
        {
            Animal animal = null;
            switch (typeOfAnimal)
            {
                case 1:
                    {
                        animal = new Lion(name,weight);
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

            animals.Add(animal);
            //manageHungry.AddAnimal(animal);
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

        public void FeedAnimal(int animalId, Food food)
        {

            foreach(var animal in animals)
            {
                if(animal.Id == animalId)
                {
                    animal.Eat(food);
                    return;
                }
            }
        }

        public void KillAnimal(int id)
        {
            foreach(var animal in animals)
            {
                if(animal.Id == id)
                    animal.Dead();
            }
        }

        public string ShowAnimals()
        {
            StringBuilder sb = new StringBuilder();

            foreach(var animal in animals)
            {
                sb.Append(animal.ToString());
                sb.Append("\n\n");
            }
            return sb.ToString();
        }

        public void Dispose()
        {
            //manageHungry.Dispose();
        }
    }
}
