namespace ZooProject.Foods
{
    internal class FoodEventArgs : EventArgs
    {
        public Food Food { get; set; }
        public FoodEventArgs(Food food)
        {
            Food = food;
        }
    }
}
