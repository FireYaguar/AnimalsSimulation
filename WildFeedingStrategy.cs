using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class WildFeedingStrategy : IFeedingStrategy
    {
        private static readonly Random _random = new Random();

        public void Feed(Animal animal, FeedingData context, int time, AnimalStateEvents events)
        {
            if (_random.NextDouble() < 0.0915)
            {
                FeedAnimal(animal, time, events);
            }
            else
            {
                animal.TimeWithoutFood++;
            }
        }

        private void FeedAnimal(Animal animal, int time, AnimalStateEvents stateEvents)
        {
            animal.TimeWithoutFood = 0;
            Console.WriteLine($"{(time < 10 ? "0" + time : time)}:00 Тварина {animal.Name} поїла\n");
            animal.MealsCount++;
            stateEvents.TriggerGotHungry(animal);
        }
    }
}
