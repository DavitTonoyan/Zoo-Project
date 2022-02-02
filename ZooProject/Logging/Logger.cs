using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooProject.Logging
{
    sealed class Logger : ILogger
    {
        private static ILogger _instatnce;

        private Logger()
        { }

        public static ILogger CreateInstance()
        {
            if (_instatnce == null)
            {
                _instatnce = new Logger();
            }
            return _instatnce;
        }

        public void Error(string error)
        {
            string msg = $"ERROR: {DateTime.Now}  {error}  \n";
            AppendToFile(msg);
        }

        public void Information(string info)
        {
            string msg = $"Information: {DateTime.Now}  {info}  \n";
            AppendToFile(msg);
        }

        public void Warning(string warning)
        {
            string msg = $"Information: {DateTime.Now}  {warning}  \n";
            AppendToFile(msg);
        }



        private void AppendToFile(string massage)
        {
            string location = GetFileLocation();
            File.AppendAllText(location, massage);
        }

        private string GetFileLocation()
        {
            string location = $"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}-{DateTime.Now.Minute}.txt";
            return location;
        }
    }
}
