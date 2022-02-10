using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
