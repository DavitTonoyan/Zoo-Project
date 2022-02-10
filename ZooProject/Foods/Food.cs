namespace ZooProject
{
    internal class Food
    {
        private double _foodWeight;

        public double FoodWeight
        {
            get
            {
                return _foodWeight;
            }
            set
            {
                if (value <= 0)
                    _foodWeight = 0;

                _foodWeight = value;
            }
        }
        public FoodType FoodType { get; }

        public Food(FoodType foodType)
        {
            this.FoodType = foodType;
        } 
        public Food(FoodType foodType, double foodWeight) :this(foodType)
        {
            FoodWeight = foodWeight;
        }

    }
}
