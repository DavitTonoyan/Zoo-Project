using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooProject.Logic;

namespace ZooProject.UI
{
    internal class ZooUI
    {
        private Zoo logic = new Zoo();

        public void Start()
        {
            while (true)
            {
                Console.Clear();
                ShowCages();

                Console.WriteLine("Choose your option  ");
                Console.WriteLine("1) Add cage \n2) Add animal \n3) Feed animals of the cage \n"+
                                  "4) Kill animal \n5) Remove animal \n"+
                                  " Press esc to exit \n");

                ConsoleKey key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:

                        AddCage();
                        break;

                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:

                        AddAnimal();
                        break;

                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:

                        FeedCageAnimal();
                        break;

                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4:

                        KillAnimal();
                        break;

                    case ConsoleKey.NumPad5:
                    case ConsoleKey.D5:

                        RemoveAnimalFromCage();
                        break;

                    case ConsoleKey.Escape:
                        return;
                }

            }
        }

        private void AddCage()
        {
            Console.WriteLine("Enter type of animal ");
            int type = int.Parse(ReadWithLabel("1. Lion   2. Cow   3. Fish"));

            try
            {
                logic.AddCage(type);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            Console.WriteLine("Press any key to continue ");
            Console.ReadKey();
        }

        private void AddAnimal()
        {
            int cageId = int.Parse(ReadWithLabel(" Enter cage Id "));
            cageId--;
            Console.WriteLine("Enter Type of Animal: ");
            int typeOfAnimal = int.Parse(ReadWithLabel("1) Lion  2) Cow  3) Fish "));

            string name = ReadWithLabel(" Enter name ");
            double weight = double.Parse(ReadWithLabel(" Enter weight of animal: "));
            try
            {
                logic.AddAnimal(cageId, typeOfAnimal, name, weight);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Press any key to continue ");
            Console.ReadKey();
        }

        private void FeedCageAnimal()
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


            int cageId = int.Parse(ReadWithLabel("Enter Id of cage "));
            cageId--;
            try
            {
                logic.FeedAnimal(cageId, food);
            }
            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Press any key to continue ");
            Console.ReadKey();
        }

        private void KillAnimal()
        {
            int cageId = int.Parse(ReadWithLabel(" Enter Id of cage: "));
            int animalId = int.Parse(ReadWithLabel(" Enter Id of animal: "));
            cageId--;

            try
            {
                logic.KillAnimalFromCage(cageId, animalId);
            }
            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Press any key to continue ");
            Console.ReadKey();
        }

        private void RemoveAnimalFromCage()
        {
            int cageId = int.Parse(ReadWithLabel(" Enter Id of cage: "));
            int animalId = int.Parse(ReadWithLabel(" Enter Id of animal: "));
            cageId--;
            try
            {
                logic.RemoveAnimalFromCage(cageId, animalId);
            }
            catch(ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Press any key to continue ");
            Console.ReadKey();
        }

        private void ShowCages()
        {
            string s = logic.ShowCages();
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
