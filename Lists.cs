using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab3
{
    public class Lists
    {
        private List<Animal> WildAnimals = new List<Animal>();
        private List<Animal> StoreAnimals = new List<Animal>();
        private Animal? HouseAnimal;

        public List<Animal> wildAnimals => WildAnimals;
        public List<Animal> storeAnimals => StoreAnimals;
        public Animal? houseAnimal => HouseAnimal;

        public void CreateAnimals(string group, string name, string envoriment)
        {
            Animal animal;
            if (group == "Ссавці")
            {
                animal = new Mammals(name, envoriment);
            }
            else if (group == "Рептилії")
            {
                animal = new Reptiles(name, envoriment);
            }
            else
            {
                animal = new Birds(name, envoriment);
            }
            AddAnimals(animal);
        }
        public void AddAnimals(Animal animal)
        {
            if (animal.Envoriment == "Wild")
            {
                WildAnimals.Add(animal);
            }
            else if (animal.Envoriment == "Store")
            {
                StoreAnimals.Add(animal);
            }
            else
            {
                HouseAnimal = animal;
            }
        }
        public void Death(Animal animal, int time, AnimalStateEvents stateEvents)
        {
            if (time != 0)
            {
                Console.WriteLine((time < 10 ? "0" + time : time) + ":00 " + "Тварина " + animal.Name + " померла від переїдання\n");
            }
            else
            {
                Console.WriteLine("Тварина " + animal.Name + " померла від голоду через відсутність їжі протягом доби\n");
            }
            stateEvents.TriggerDeath(animal);
        }

        public void DeleteAnimals(List<Animal>? animals)
        {
            int i = 0;
            while (animals.Count > i)
            {
                if (!animals[i].Life)
                {
                    animals.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
        }

        public void PetDeath()
        {
            if (!HouseAnimal.Life)
            {
                HouseAnimal = null;
            }
        }
    }
}
