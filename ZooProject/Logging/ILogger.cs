using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooProject.Logging
{
    interface ILogger
    {
        void Information(string info);
        void Warning(string warning);
        void Error(string error);
    }
}
