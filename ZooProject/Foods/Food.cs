using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooProject
{
    internal class Food
    {
        private double foodWeight;

        public double FoodWeight
        {
            get 
            {
                return foodWeight;
            }
            set
            {
                if (value <= 0)
                    foodWeight = 0;

                foodWeight = value;
            } 
        }
        public FoodType FoodType { get; }
        
        public Food(FoodType foodType ,  double foodWeight)
        {
            FoodType = foodType;
            FoodWeight = foodWeight;
        }

    }
}
