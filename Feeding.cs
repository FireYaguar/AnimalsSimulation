using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab3
{
    public class Feeding
    {
        private static Random rand = new Random();
        public void wildFeeding(Animal animal, int time, AnimalStateEvents stateEvents)
        {
            if (rand.NextDouble() < 0.0915)
            {
                animal.timeWithoutFood = 0;
                Console.WriteLine((time < 10 ? "0" + time : time) + ":00 " + "Тварина " + animal.Name + " поїла\n");
                animal.mealsCount++;
                stateEvents.TriggerGotHungry(animal);
            }
            else
            {
                animal.timeWithoutFood++;
            }
        }
        public int noControlFeeding(Animal animal, int time, int amount, ref int foodAmount, AnimalStateEvents stateEvents)
        {
            int interval = 0;
            if (amount == 3)
            {
                interval = 21 / amount;
            }
            else if (amount == 5 || amount == 4 || amount == 2)
            {
                interval = 20 / amount;
            }
            if (foodAmount != 0 && time != 0 && time % interval == 0)
            {
                animal.timeWithoutFood = 0;
                Console.WriteLine((time < 10 ? "0" + time : time) + ":00 " + "Тварина " + animal.Name + " поїла\n");
                animal.mealsCount++;
                foodAmount--;
                stateEvents.TriggerGotHungry(animal);
            }
            return foodAmount;
        }
        public void controlFeeding(Animal animal, int time, int foodAmount, AnimalStateEvents stateEvents)
        {
            int interval = 0;
            if (foodAmount == 2 || foodAmount == 4 || foodAmount == 5)
            {
                interval = 20 / foodAmount;
            }
            else if (foodAmount == 1)
            {
                interval = 13;
            }
            else if (foodAmount == 3)
            {
                interval = 21 / foodAmount;
            }
            if (foodAmount != 0 && time != 0 && time % interval == 0)
            {
                animal.timeWithoutFood = 0;
                Console.WriteLine((time < 10 ? "0" + time : time) + ":00 " + "Тварина " + animal.Name + " поїла\n");
                animal.mealsCount++;
                stateEvents.TriggerGotHungry(animal);
            }
        }
    }
}
