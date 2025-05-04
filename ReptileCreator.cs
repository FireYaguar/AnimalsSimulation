using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class ReptileCreator : IAnimalCreator
    {
        public Animal Create(string name, string environment)
        {
            return new Reptiles(name, environment);
        }
    }
}
