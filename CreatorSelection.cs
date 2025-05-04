using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab3
{
    public class CreatorSelection
    {
        public Animal Selection(string group, string name, string environment)
        {
            IAnimalCreator creator = group switch
            {
                "Ссавці" => new MammalCreator(),
                "Рептилії" => new ReptileCreator(),
                _ => new BirdCreator()
            };

            return creator.Create(name, environment);
        }
    }
}
