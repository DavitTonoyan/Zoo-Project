﻿using ZooProject.Logging;
using ZooProject.Foods;
using ZooProject.Attributes;
using System.Reflection;
using ZooProject.Stomachs;

namespace ZooProject.Animals
{
    internal abstract class Animal
    {
        private static int _id;
        private static ILogger _logger = Logger.CreateInstance();
        private IStomach _stomach;
        private Timer _timerForHungry;

        public bool IsAlive { get; private set; } = true;
        public string Name { get; set; }
        [IdLimit(5)]
        public int Id { get; }

        public Animal(string name, double weight)
        {
            _id++;
            var property = this.GetType().GetProperty("Id");

            if (Attribute.IsDefined(property, typeof(IdLimitAttribute)))
            {
                var limit = property.GetCustomAttribute<IdLimitAttribute>().Max;
                if (_id >= limit)
                {
                    throw new Exception(" Attribute limit ");
                }
            }

            this.Name = name;
            Id = _id;
            _stomach = new Stomach(weight);

            _timerForHungry = new Timer(GetHungry);
            _timerForHungry.Change(5000, 5000);
        }

        public void Dead()
        {
            _timerForHungry.Dispose();
            IsAlive = false;
            _logger.Information($"{this.GetType().Name} {Name} is die ");
        }

        public void Eat(object sender, FoodEventArgs foodArgs)
        {
            if (!this.IsAlive)
                return;

            double ateWeight = _stomach.GetEatWeight(foodArgs);

            _logger.Information($"{this.GetType().Name} {Name} ate {ateWeight} {foodArgs.Food.FoodType} ");
        }

        public override string ToString()
        {
            string s = "Animal " +
                      $"    ID:   {Id}  \n" +
                      $"    Name:    {Name} \n" +
                      $"    Weight:  {_stomach.Weight}  \\  {_stomach.MaxStomachSize} \n" +
                      $"    Type:    {this.GetType().Name}  \n" +
                      $"    Alive:   {IsAlive} \n";

            return s;
        }

        private void GetHungry(object ob)
        {
            bool isDying = _stomach.IsDyingForHungry();

            if (isDying)
            {
                _logger.Warning($"the {this.GetType().Name}: {Name} is going to die soon ");
            }

            if (_stomach.Weight == 0)
            {
                Dead();
            }
        }
    }
}
