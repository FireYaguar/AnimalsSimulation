using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Reptiles : Animal, ICrawling
    {
        public bool crawling { get; set; } = true;

        public Reptiles(string name, string envoriment) : base(name, envoriment)
        {

        }
    }
}
