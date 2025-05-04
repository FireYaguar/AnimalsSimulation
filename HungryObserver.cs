using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class HungryObserver : IStateObserver
    {
        private event AnimalStateChangeHandler OnGotHungry;

        public HungryObserver()
        {
            OnGotHungry += HungryState;
        }
        public void UpdateState(Animal animal, AnimalEvent _event)
        {
            if (_event == AnimalEvent.Hungry)
            {
                TriggerGotHungry(animal);
            }
        }

        public void TriggerGotHungry(Animal animal) => OnGotHungry?.Invoke(animal);

        private void HungryState(Animal animal)
        {
            animal.Hungry = true;

            if (animal is ICrawling crawlingAnimal)
            {
                crawlingAnimal.Crawling = true;

                if (animal is IRunning runningAnimal)
                {
                    runningAnimal.Running = false;
                }
                else if (animal is IFlying flyingAnimal)
                {
                    flyingAnimal.Flying = false;
                    flyingAnimal.Singing = false;
                }
            }
        }
    }
}
