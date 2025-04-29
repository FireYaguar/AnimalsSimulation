using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Mammals : Animal, IRunning, ICrawling
    {
        public bool running { get; set; } = true;
        public bool crawling { get; set; } = false;

        public Mammals(string name, string envoriment) : base(name, envoriment)
        {

        }
    }
}
