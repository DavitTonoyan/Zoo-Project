namespace ZooProject
{
    internal abstract class Animal
    {
        private static Random rand = new Random();
        private static int id;
        private readonly double deltaHungryTime;
        private readonly double maxStomachSize;
        private readonly double maxWeightToEat;
        private double _weight;
        private FoodType _foodType;
        private Timer _timer;


        public bool IsAlive { get; private set; } = true;
        public string Name { get; set; }
        public int Id { get; }
        public double Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                if (value < 0)
                    _weight = 0;
                else
                    _weight = value;
            }
        }

        public Animal(string name, double weight, FoodType food)
        {
            id++;
            this.Name = name;
            this.Weight = weight;
            Id = id;
            _foodType = food;

            deltaHungryTime = weight * rand.Next(5, 10) / 100;
            maxStomachSize = weight + weight * 20 / 100;
            maxWeightToEat = weight * rand.Next(2, 5) / 100;

            _timer = new Timer(GetHungry);
            _timer.Change(5000, 5000);
        }

        public void Dead()
        {
            _timer.Dispose();
            IsAlive = false;
        }

        public void Eat(Food food)
        {
            if (!this.IsAlive)
                return;

            double hungrySize = maxStomachSize - Weight;

            if (hungrySize <= 0)
                return;

            if (food.FoodWeight < maxWeightToEat)
            {
                if (food.FoodWeight < hungrySize)
                {
                    Weight += food.FoodWeight;
                    food.FoodWeight = 0;
                    return;
                }

                Weight += hungrySize;
                food.FoodWeight -= hungrySize;
            }

            else
            {
                if (maxWeightToEat < hungrySize)
                {
                    Weight += maxWeightToEat;
                    food.FoodWeight -= maxWeightToEat; 
                }
                else
                {
                    Weight += hungrySize;
                    food.FoodWeight -= maxWeightToEat;
                }
            }
        }

        public override string ToString()
        {
            string s = "Animal " +
                      $"    ID:   {Id}  \n" +
                      $"    Name:    {Name} \n" +
                      $"    Weight:  {Weight}  \\  {maxStomachSize} \n" +
                      $"    Type:    {this.GetType().Name}  \n" +
                      $"    Alive:   {IsAlive} \n";

            return s;
        }

        private void GetHungry(object ob)
        {
            Weight -= deltaHungryTime;

            if (Weight == 0)
            {
                Dead();
            }
        }
    }
}
