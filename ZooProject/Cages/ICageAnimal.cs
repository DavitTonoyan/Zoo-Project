﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooProject.Cages
{
    internal interface ICageAnimal
    {
        void AddAnimal(Animal animal);
        void RemoveAnimal(int animalId);
        void KillAnimal(int animalId);
        void FeedAnimals(Food food);
        event Action<Food> FeedingAnimals;

    }
}
