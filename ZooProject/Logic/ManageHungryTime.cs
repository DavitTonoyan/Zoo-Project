using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ZooProject.Logic
{
    //TODO: էս մենեջերը չպետքա կենդանուն սովածացնի, թայմերը պետքա լինի կենդանու ներսում
//    internal class ManageHungryTime :IDisposable
//    {
//        private List<Animal> animals = new List<Animal>();
//        private Action<object> hungryAnimal;
//        private Timer timer;

//        public ManageHungryTime()
//        {
//            hungryAnimal = RemoveAnimal;
//            GetHungry();
//        }

//        public void AddAnimal(Animal animal)
//        {
//            this.animals.Add(animal);
//            hungryAnimal += animal.GetHungry;
//        }

//        public void Dispose()
//        {
//            timer.Dispose();
//        }

//        private void GetHungry()
//        {
//            object ob = new object();
//            timer = new Timer(o => hungryAnimal(o));
//            timer.Change(5000, 5000);
//        }

//        private void RemoveAnimal(object ob)
//        {
//            foreach (var animal in animals)
//            {
//                if (animal.Weight <= 0)
//                {
//                    hungryAnimal -= animal.GetHungry;
//                    animal.Dead();
//                }
//                else if (!animal.IsAlive)
//                {
//                    hungryAnimal -= animal.GetHungry;
//                }

//            }
//            animals = animals.Where(an => an.IsAlive).ToList();
//        }

//    }
}
