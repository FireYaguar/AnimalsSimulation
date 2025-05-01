//Simulation.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Simulation
    {
        private readonly Lists _animals;
        private readonly Status _status;
        public AnimalStateEvents _events = new AnimalStateEvents();

        private readonly IFeedingStrategy _wildFeeding = new WildFeedingStrategy();
        private readonly IFeedingStrategy _controlledFeeding = new ControlledFeedingStrategy();

        public Simulation(Lists animals)
        {
            _animals = animals ?? throw new ArgumentNullException(nameof(animals));
            _status = new Status();
        }

        public void RunWildSimulation(int days, FeedingData context)
        {
            var strategy = new WildFeedingStrategy();
            RunSimulation(_animals.WildAnimals, days, strategy, context);
        }

        public void RunStoreControlledSimulation(int days, FeedingData context)
        {
            var strategy = new ControlledFeedingStrategy();
            RunSimulation(_animals.StoreAnimals, days, strategy, context);
        }

        public void RunStoreUncontrolledSimulation(int days, FeedingData context)
        {
            var strategy = new UncontrolledFeedingStrategy();
            RunSimulation(_animals.StoreAnimals, days, strategy, context);
        }

        public void RunHouseControlledSimulation(int days, FeedingData context)
        {
            if (_animals.HouseAnimal == null) return;

            var strategy = new ControlledFeedingStrategy();
            RunSingleAnimalSimulation(_animals.HouseAnimal, days, strategy, context);
        }

        public void RunHouseUncontrolledSimulation(int days, FeedingData context)
        {
            if (_animals.HouseAnimal == null) return;

            var strategy = new UncontrolledFeedingStrategy();
            RunSingleAnimalSimulation(_animals.HouseAnimal, days, strategy, context);
        }

        private void RunSimulation(List<Animal> animals, int days, IFeedingStrategy feedingStrategy, FeedingData context)
        {
            for (int day = 0; day < days; day++)
            {
                Console.WriteLine($"День: {day + 1}\n");
                ResetDailyStats(animals);

                for (int hour = 0; hour < 24; hour++)
                {
                    SimulateHour(animals, hour, feedingStrategy, context);
                }

                CheckForStarvation(animals, context);
                HandleCleaning(animals, context);
            }

            _status.ShowSimulationEnd(animals);
            _animals.RemoveDeadAnimals(animals);
        }

        private void RunSingleAnimalSimulation(Animal animal, int days, IFeedingStrategy feedingStrategy, FeedingData context)
        {

            for (int day = 0; day < days; day++)
            {
                Console.WriteLine($"День: {day + 1}\n");
                animal.MealsCount = 0;

                for (int hour = 0; hour < 24; hour++)
                {
                    if (!animal.Life) break;
                    feedingStrategy.Feed(animal, context, hour, _events);

                    if (animal.MealsCount == 6)
                    {
                        _animals.HandleDeath(animal, hour, _events);
                        break;
                    }

                    animal.GotHungry(hour, _events);
                }

                if (animal.Life && animal.MealsCount == 0)
                {
                    _animals.HandleDeath(animal, 0, _events);
                }

                if (context.Cleaning)
                {
                    _events.TriggerOnClean(animal);
                }
                else
                {
                    _events.TriggerOffClean(animal);
                }
            }

            _status.ShowHouseSimulationEnd(animal);
            _animals.CheckPetStatus();
        }

        private void ResetDailyStats(IEnumerable<Animal> animals)
        {
            foreach (var animal in animals)
            {
                animal.MealsCount = 0;
            }
        }

        private void SimulateHour(List<Animal> animals, int hour, IFeedingStrategy feedingStrategy, FeedingData context)
        {
            foreach (var animal in animals)
            {
                if (!animal.Life) continue;

                feedingStrategy.Feed(animal, context, hour, _events);

                if (animal.MealsCount == 6)
                {
                    _animals.HandleDeath(animal, hour, _events);
                    continue;
                }

                animal.GotHungry(hour, _events);
            }
        }

        private void CheckForStarvation(IEnumerable<Animal> animals, FeedingData context)
        {
            foreach (var animal in animals)
            {
                if (animal.Life && animal.MealsCount == 0)
                {
                    _animals.HandleDeath(animal, 0, _events);
                }
            }
        }

        private void HandleCleaning(IEnumerable<Animal> animals, FeedingData context)
        {
            foreach (var animal in animals)
            {
                if (animal.Life)
                {
                    if (context.Cleaning)
                    {
                        _events.TriggerOnClean(animal);
                    }
                    else
                    {
                        _events.TriggerOffClean(animal);
                    }
                }
            }
        }
    }
}
