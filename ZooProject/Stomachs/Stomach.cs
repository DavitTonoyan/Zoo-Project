using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooProject.Foods;

namespace ZooProject.Stomachs
{
    internal class Stomach:IStomach
    {
        private static Random _rand = new Random();
        private readonly double _deltaHungryWeight;
        private double _weight;

        public Stomach(double weight)
        {
            this._weight = weight;
            _deltaHungryWeight = _weight * _rand.Next(2, 5) / 100;
            MaxStomachSize = _weight + _weight * 20 / 100;
        }

        public double Weight
        {
            get
            {
                return _weight;
            }
            private set
            {
                if (value < 0)
                    _weight = 0;
                else
                    _weight = value;
            }
        }
        public double MaxStomachSize { get; }


        public double GetEatWeight(FoodEventArgs foodEventArgs)
        {
            Food food = foodEventArgs.Food;
            double hungrySize = MaxStomachSize - Weight;

            if (hungrySize <= 0)
                return 0;

            double ateWeight = 0;
            double weightToEatPerSecond = Weight * _rand.Next(2, 5) / 100;


            if (food.FoodWeight < weightToEatPerSecond)
            {
                if (food.FoodWeight < hungrySize)
                {
                    Weight += food.FoodWeight;
                    ateWeight = food.FoodWeight;
                    food.FoodWeight = 0;
                }
                else
                {
                    Weight += hungrySize;
                    ateWeight = hungrySize;
                    food.FoodWeight -= hungrySize;
                }
            }

            else
            {
                if (weightToEatPerSecond < hungrySize)
                {
                    Weight += weightToEatPerSecond;
                    ateWeight = weightToEatPerSecond;
                    food.FoodWeight -= weightToEatPerSecond;
                }
                else
                {
                    Weight += hungrySize;
                    ateWeight = hungrySize;
                    food.FoodWeight -= weightToEatPerSecond;
                }
            }

            return ateWeight;

        }

        public bool IsDyingForHungry()
        {
            Weight -= _deltaHungryWeight;
            bool isDying = Weight <= 2 * _deltaHungryWeight;

            return isDying;
        }

    }
}
