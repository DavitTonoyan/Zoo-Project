namespace ZooProject.Attributes
{
    internal class IdLimitAttribute : Attribute
    {
        public int Max { get; set; }
        public IdLimitAttribute(int max)
        {
            Max = max;
        }
    }
}
