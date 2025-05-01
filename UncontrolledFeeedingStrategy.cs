using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class UncontrolledFeedingStrategy : IFeedingStrategy
    {
        public void Feed(Animal animal, FeedingData context, int time, AnimalStateEvents events)
        {
            if (context.FoodAmount == 0) return;

            int interval = GetFeedingInterval(context.MealsAmount);
            int foodAmount = context.FoodAmount;
            if (time != 0 && time % interval == 0)
            {
                FeedAnimal(animal, time, ref foodAmount, events);
            }
            else
            {
                animal.TimeWithoutFood++;
            }

            context.FoodAmount = foodAmount;
        }

        private int GetFeedingInterval(int mealsAmount)
        {
            return mealsAmount switch
            {
                3 => 7,
                2 or 4 or 5 => 20 / mealsAmount,
                1 => 13,
                _ => 25
            };
        }

        private void FeedAnimal(Animal animal, int time, ref int foodAmount, AnimalStateEvents stateEvents)
        {
            animal.TimeWithoutFood = 0;
            Console.WriteLine($"{(time < 10 ? "0" + time : time)}:00 Тварина {animal.Name} поїла\n");
            animal.MealsCount++;
            foodAmount--;
            stateEvents.TriggerSatiety(animal);
        }
    }
}
