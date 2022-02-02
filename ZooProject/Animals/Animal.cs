using ZooProject.Logging;

namespace ZooProject
{
    internal abstract class Animal
    {
        private static Random _rand = new Random();
        private static int _id;
        private static ILogger _logger = Logger.CreateInstance();
        private readonly double _deltaHungryTime;
        private readonly double _maxStomachSize;
        private readonly double _weightToEatPerSecond;
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
            _id++;
            this.Name = name;
            this.Weight = weight;
            Id = _id;
            _foodType = food;

            _deltaHungryTime = weight * _rand.Next(5, 10) / 100;
            _maxStomachSize = weight + weight * 20 / 100;
            _weightToEatPerSecond = weight * _rand.Next(2, 5) / 100;

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

            double hungrySize = _maxStomachSize - Weight;

            if (hungrySize <= 0)
                return;

            double ateWeight = 0;

            if (food.FoodWeight < _weightToEatPerSecond)
            {
                if (food.FoodWeight < hungrySize)
                {
                    Weight += food.FoodWeight;
                    ateWeight = food.FoodWeight;
                    food.FoodWeight = 0;
                    return;
                }

                Weight += hungrySize;
                ateWeight = hungrySize;
                food.FoodWeight -= hungrySize;
            }

            else
            {
                if (_weightToEatPerSecond < hungrySize)
                {
                    Weight += _weightToEatPerSecond;
                    ateWeight = _weightToEatPerSecond;
                    food.FoodWeight -= _weightToEatPerSecond; 
                }
                else
                {
                    Weight += hungrySize;
                    ateWeight = hungrySize;
                    food.FoodWeight -= _weightToEatPerSecond;
                }
            }

            _logger.Information($"{this.GetType().Name} {Name} ate {ateWeight} {food.FoodType} ");
        }

        public override string ToString()
        {
            string s = "Animal " +
                      $"    ID:   {Id}  \n" +
                      $"    Name:    {Name} \n" +
                      $"    Weight:  {Weight}  \\  {_maxStomachSize} \n" +
                      $"    Type:    {this.GetType().Name}  \n" +
                      $"    Alive:   {IsAlive} \n";

            return s;
        }

        private void GetHungry(object ob)
        {
            Weight -= _deltaHungryTime;

            if(Weight <= 2* _deltaHungryTime)
            {
                _logger.Warning($"the {this.GetType()}: {Name} is going to die soon ");
            }

            if (Weight == 0)
            {
                Dead();
            }
        }
    }
}
