using ZooProject.Logging;
using ZooProject.Logic;

namespace ZooProject.UI
{
    internal class ZooUI
    {
        private Zoo _logic = new Zoo();
        private ILogger _logger = Logger.CreateInstance();

        public void Start()
        {
            while (true)
            {
                Console.Clear();
                ShowCages();

                Console.WriteLine("Choose your option  ");
                Console.WriteLine("1) Add cage \n2) Add animal \n3) Feed animals of the cage \n" +
                                  "4) Kill animal \n5) Remove animal \n" +
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
                _logic.AddCage(type);
                _logger.Information($" New cage added");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _logger.Error(ex.Message);
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
                _logic.AddAnimal(cageId, typeOfAnimal, name, weight);
                _logger.Information($" New animal added  in {cageId+1} cage");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                _logger.Error(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                _logger.Error(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _logger.Error(ex.Message);
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
                food = _logic.SetFood(foodType, weight);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                _logger.Error(ex.Message);

                Console.WriteLine("Press any key to continue ");
                Console.ReadKey();
                return;
            }


            int cageId = int.Parse(ReadWithLabel("Enter Id of cage "));
            cageId--;
            try
            {
                _logic.FeedAnimal(cageId, food);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                _logger.Error(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                _logger.Error(ex.Message);
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
                bool isKilled = _logic.KillAnimalFromCage(cageId, animalId);

                if (isKilled)
                    _logger.Information($"{animalId} id animal is Killed in cage {cageId}");

                else
                    _logger.Information($"{animalId} id animal does Not found in cage {cageId}");

            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                _logger.Error(ex.Message);
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
                bool isRemoved = _logic.RemoveAnimalFromCage(cageId, animalId);

                if (isRemoved)
                    _logger.Information($"{animalId} id animal is Killed in cage {cageId}");

                else
                    _logger.Information($"{animalId} id animal does Not found in cage {cageId}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                _logger.Error(ex.Message);
            }

            Console.WriteLine("Press any key to continue ");
            Console.ReadKey();
        }

        private void ShowCages()
        {
            string s = _logic.ShowCages();
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
