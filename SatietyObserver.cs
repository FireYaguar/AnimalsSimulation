using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class SatietyObserver : IStateObserver
    {
        private event AnimalStateChangeHandler OnSatiety;

        public SatietyObserver()
        {
            OnSatiety += SatietyState;
        }
        public void UpdateState(Animal animal, AnimalEvent _event)
        {
            if (_event == AnimalEvent.Satiety)
            {
                TriggerSatiety(animal);
            }
        }

        public void TriggerSatiety(Animal animal) => OnSatiety?.Invoke(animal);

        private void SatietyState(Animal animal)
        {
            animal.Hungry = false;

            if (animal is ICrawling crawlingAnimal && crawlingAnimal.Crawling)
            {
                crawlingAnimal.Crawling = false;

                if (animal is IRunning runningAnimal)
                {
                    runningAnimal.Running = true;
                }
                else if (animal is IFlying flyingAnimal)
                {
                    flyingAnimal.Flying = true;
                    flyingAnimal.Singing = true;
                }
            }
        }
    }
}
