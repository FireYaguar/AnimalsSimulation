//Reptiles.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Reptiles : Animal, ICrawling
    {
        public bool Crawling { get; set; } = true;

        public Reptiles(string name, string environment) : base(name, environment) { }
    }
}