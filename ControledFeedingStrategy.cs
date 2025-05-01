using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class ControlledFeedingStrategy : IFeedingStrategy
    {
        public void Feed(Animal animal, FeedingData context, int time, AnimalStateEvents events)
        {
            int interval = GetFeedingInterval(context.MealsAmount);

            if (time != 0 && time % interval == 0)
            {
                FeedAnimal(animal, time, events);
            }
        }

        private int GetFeedingInterval(int mealsAmount)
        {
            return mealsAmount switch
            {
                2 or 4 or 5 => 20 / mealsAmount,
                1 => 13,
                3 => 7,
                6 => 3,
                0 => 25
            };
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
