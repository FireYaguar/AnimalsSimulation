//Lists.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

using System.Collections.Generic;

namespace Lab3
{
    public class Lists
    {
        private CreatorSelection selection = new CreatorSelection(); 
        private readonly List<Animal> _wildAnimals = new List<Animal>();
        private readonly List<Animal> _storeAnimals = new List<Animal>();
        private Animal? _houseAnimal;

        public List<Animal> WildAnimals => _wildAnimals;
        public List<Animal> StoreAnimals => _storeAnimals;
        public Animal HouseAnimal => _houseAnimal;

        public void CreateAnimal(string group, string name, string environment)
        {
            Animal animal = selection.Selection(group, name, environment);
            AddAnimal(animal);
        }

        public void AddAnimal(Animal animal)
        {
            switch (animal.Environment)
            {
                case "Wild":
                    _wildAnimals.Add(animal);
                    break;
                case "Store":
                    _storeAnimals.Add(animal);
                    break;
                case "House":
                    _houseAnimal = animal;
                    break;
            }
        }

        public void HandleDeath(Animal animal, int time, State stateEvents)
        {
            string message = time != 0
                ? $"{(time < 10 ? "0" + time : time)}:00 Тварина {animal.Name} померла від переїдання\n"
                : $"Тварина {animal.Name} померла від голоду через відсутність їжі протягом доби\n";

            Console.WriteLine(message);
            stateEvents.Notify(animal, AnimalEvent.Death);
        }

        public void RemoveDeadAnimals(List<Animal> animals)
        {
            animals.RemoveAll(animal => !animal.Life);
        }

        public void CheckPetStatus()
        {
            if (_houseAnimal != null && !_houseAnimal.Life)
            {
                _houseAnimal = null;
            }
        }
    }
}