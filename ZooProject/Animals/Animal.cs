namespace ZooProject
{
    internal abstract class Animal
    {
        private static Random rand = new Random();
        private static int id;
        private readonly double deltaHungryTime;
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
            {
                throw new InvalidOperationException("The animal is dead");
            }

            CanEat(food);
            this.Weight += food.FoodWeight;
        }

        public override string ToString()
        {
            string s = "Animal " +
                      $"    ID:      {Id}  \n" +
                      $"    Name:    {Name} \n" +
                      $"    Weight:  {Weight} \n" +
                      $"    Type:    {this.GetType().Name}  \n" +
                      $"    Alive:   {IsAlive} \n";

            return s;
        }

        private void CanEat(Food food)
        {
            if (food.FoodType != _foodType)
            {
                throw new ArgumentException($" {Name} can't eat  {food.FoodType} ");
            }
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
