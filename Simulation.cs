using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Simulation
    {
        private Lists list;
        public Simulation(Lists lists)
        {
            this.list = lists;
        }

        private Status st = new Status();
        private Feeding fd = new Feeding();
        AnimalStateEvents Events = new AnimalStateEvents();
        public void wildSimulation(List<Animal> animals, int days, string environment)
        {
            for (int i = 0; i < days; i++)
            {
                foreach (Animal animal1 in animals)
                {
                    animal1.mealsCount = 0;
                }
                Console.WriteLine("День: " + (i + 1) + "\n");
                for (int a = 0; a < 24; a++)
                {
                    foreach (Animal animal in animals)
                    {
                        if (animal.Life)
                        {
                            fd.wildFeeding(animal, a, Events);
                            if (animal.mealsCount == 6)
                            {
                                list.Death(animal, a, Events);
                                continue;
                            }
                            animal.GotHungry(a, Events);
                        }
                    }
                }
                foreach (Animal animal in animals)
                {
                    if (animal.Life && animal.mealsCount == 0)
                    {
                        list.Death(animal, 0, Events);
                    }
                }
            }
            st.simulationEnd(animals);
            list.DeleteAnimals(animals);
        }
        public void StoreControlSimulation(List<Animal> animals, int days, int amount, bool cleaning)
        {
            for (int i = 0; i < days; i++)
            {
                foreach (Animal animal1 in animals)
                {
                    animal1.mealsCount = 0;
                }
                Console.WriteLine("День: " + (i + 1) + "\n");
                for (int a = 0; a < 24; a++)
                {
                    foreach (Animal animal in animals)
                    {
                        if (animal.Life)
                        {
                            fd.controlFeeding(animal, a, amount, Events);
                            if (animal.mealsCount == 6)
                            {
                                list.Death(animal, a, Events);
                                continue;
                            }
                            animal.GotHungry(a, Events);
                        }
                    }
                }
                foreach (Animal animal in animals)
                {
                    if (animal.Life)
                    {
                        if (animal.mealsCount == 0)
                        {
                            list.Death(animal, 0, Events);
                        }
                        if (cleaning)
                        {
                            Events.TriggerOnClean(animal);
                        }
                        else
                        {
                            Events.TriggerOffClean(animal);
                        }
                    }
                }
            }
            st.simulationEnd(animals);
            list.DeleteAnimals(animals);
        }
        public void StoreNoControlSimulation(List<Animal> animals, int days, int foodAmount)
        {
            Random rand = new Random();
            for (int i = 0; i < days; i++)
            {
                foreach (Animal animal1 in animals)
                {
                    animal1.mealsCount = 0;
                }
                Console.WriteLine("День: " + (i + 1) + "\n");
                for (int a = 0; a < 24; a++)
                {
                    int amount = rand.Next(2, 5);
                    foreach (Animal animal in animals)
                    {
                        if (animal.Life)
                        {
                            fd.noControlFeeding(animal, a, amount, ref foodAmount, Events);
                            if (animal.mealsCount == 6)
                            {
                                Events.TriggerDeath(animal);
                                list.Death(animal, a, Events);
                                continue;
                            }
                            animal.GotHungry(a, Events);
                        }
                    }
                }
                foreach (Animal animal in animals)
                {
                    if (animal.Life)
                    {
                        if (animal.mealsCount == 0)
                        {
                            Events.TriggerDeath(animal);
                            list.Death(animal, 0, Events);
                        }
                        Events.TriggerOffClean(animal);
                    }
                }
            }
            st.simulationEnd(animals);
            list.DeleteAnimals(animals);
        }
        public void HouseControlSimulation(Animal animal, int days, int amount, bool cleaning)
        {
            for (int i = 0; i < days; i++)
            {
                animal.mealsCount = 0;
                Console.WriteLine("День: " + (i + 1) + "\n");
                for (int a = 0; a < 24; a++)
                {
                    fd.controlFeeding(animal, a, amount, Events);
                    if (animal.mealsCount == 6)
                    {
                        Events.TriggerDeath(animal);
                        list.Death(animal, a, Events);
                        break;
                    }
                    animal.GotHungry(a, Events);
                }
                if (animal.mealsCount == 0)
                {
                    Events.TriggerDeath(animal);
                    list.Death(animal, 0, Events);
                }
                if (cleaning)
                {
                    Events.TriggerOnClean(animal);
                }
                else
                {
                    Events.TriggerOffClean(animal);
                }
            }
            st.HouseSimulationEnd(animal);
            list.PetDeath();
        }
        public void HouseNoControlSimulation(Animal animal, int days, int foodAmount)
        {
            Random rand = new Random();
            for (int i = 0; i < days; i++)
            {
                animal.mealsCount = 0;
                Console.WriteLine("День: " + (i + 1) + "\n");
                int amount = rand.Next(2, 5);
                for (int a = 0; a < 24; a++)
                {
                    fd.noControlFeeding(animal, a, amount, ref foodAmount, Events);
                    if (animal.mealsCount == 6)
                    {
                        list.Death(animal, a, Events);
                        i = days;
                        break;
                    }
                    animal.GotHungry(a, Events);
                }
                if (animal.mealsCount == 0)
                {
                    list.Death(animal, 0, Events);
                }
                Events.TriggerOffClean(animal);
            }
            st.HouseSimulationEnd(animal);
            list.PetDeath();
        }
    }
}
