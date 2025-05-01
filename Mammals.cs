//Mammals.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Mammals : Animal, IRunning, ICrawling
    {
        public bool Running { get; set; } = true;
        public bool Crawling { get; set; } = false;

        public Mammals(string name, string environment) : base(name, environment) { }
    }
}