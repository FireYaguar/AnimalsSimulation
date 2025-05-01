//IFlying.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public interface IFlying
    {
        bool Wings { get; set; }
        bool Singing { get; set; }
        bool Flying { get; set; }
    }
}
