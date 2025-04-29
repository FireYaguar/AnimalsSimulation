using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Birds : Animal, IFlying, ICrawling
    {
        public bool wings { get; set; } = true;
        public bool flying { get; set; } = true;
        public bool crawling { get; set; } = false;
        public bool singing { get; set; } = true;

        public Birds(string name, string envoriment) : base(name, envoriment)
        {

        }
    }
}
