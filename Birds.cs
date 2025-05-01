//Birds.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Birds : Animal, IFlying, ICrawling
    {
        public bool Wings { get; set; } = true;
        public bool Flying { get; set; } = true;
        public bool Crawling { get; set; } = false;
        public bool Singing { get; set; } = true;

        public Birds(string name, string environment) : base(name, environment) { }
    }
}
