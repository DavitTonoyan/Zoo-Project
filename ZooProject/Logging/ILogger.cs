namespace ZooProject.Logging
{
    interface ILogger
    {
        void Information(string info);
        void Warning(string warning);
        void Error(string error);
    }
}
