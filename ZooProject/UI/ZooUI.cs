using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooProject.Logic;

namespace ZooProject.UI
{
    internal class ZooUI :IDisposable
    {
        private BussinessLogic logic = new BussinessLogic();

        public void Start()
        {
            while (true)
            {
                Console.Clear();
                ShowAnimals();


                Console.WriteLine("Choose your option  ");
                Console.WriteLine("1) Add animal \n2) Feed to animal \n3) Kill animal \n" +
                                  " Press esc to exit \n");

                ConsoleKey key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:

                        AddAnimal();
                        break;

                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:

                        FeedToAnimal();
                        break;

                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:

                        KillAnimal();
                        break;

                    case ConsoleKey.Escape:
                        return;
                }

            }
        }

        public void Dispose()
        {
            logic.Dispose();
        }

        private void AddAnimal()
        {
            Console.WriteLine("Enter Type of Animal: ");
            int typeOfAnimal = int.Parse(ReadWithLabel("1) Lion  2) Cow  3) Fish "));

            string name = ReadWithLabel(" Enter name ");
            double weight = double.Parse(ReadWithLabel(" Enter weight of animal: "));

            logic.AddAnimal(typeOfAnimal, name, weight);
        }

        private void FeedToAnimal()
        {
            Console.WriteLine(" Enter food type: ");
            int foodType = int.Parse(ReadWithLabel(" 1) Meet,  2) Grass,  3) Worm "));
            double weight = double.Parse(ReadWithLabel("Enter weight of food: "));

            Food food;

            try
            {
               food = logic.SetFood(foodType, weight);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Press any key to continue ");
                Console.ReadKey();
                return;
            }


            int animalId = int.Parse(ReadWithLabel("Enter Id of animal "));

            try
            {
                logic.FeedAnimal(animalId, food);
            }
            catch(InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Press any key to continue ");
                Console.ReadKey();
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Press any key to continue ");
                Console.ReadKey();
            }
        }

        private void KillAnimal()
        {
            int id = int.Parse(ReadWithLabel(" Enter Id of animal: "));

            logic.KillAnimal(id);
        }

        private void ShowAnimals()
        {
            string s = logic.ShowAnimals();

            Console.WriteLine(s);
        }

        private string ReadWithLabel(string text)
        {
            Console.WriteLine(text);
            string s = Console.ReadLine();

            return s;
        }
    }
}
