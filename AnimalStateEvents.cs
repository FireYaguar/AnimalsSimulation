//AnimalStateEvents.cs
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public delegate void AnimalStateChangeHandler(Animal animal);

    public class AnimalStateEvents
    {
        private event AnimalStateChangeHandler OnGotHungry;
        private event AnimalStateChangeHandler OnSatiety;
        private event AnimalStateChangeHandler OnClean;
        private event AnimalStateChangeHandler OffClean;
        private event AnimalStateChangeHandler OnDeath;

        public AnimalStateEvents()
        {
            OnGotHungry += HungryState;
            OnSatiety += SatietyState;
            OnClean += OnCleanState;
            OffClean += OffCleanState;
            OnDeath += DeathState;
        }

        public void TriggerGotHungry(Animal animal) => OnGotHungry?.Invoke(animal);
        public void TriggerSatiety(Animal animal) => OnSatiety?.Invoke(animal);
        public void TriggerOnClean(Animal animal) => OnClean?.Invoke(animal);
        public void TriggerOffClean(Animal animal) => OffClean?.Invoke(animal);
        public void TriggerDeath(Animal animal) => OnDeath?.Invoke(animal);

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

        private void OnCleanState(Animal animal) => animal.Happiness = true;
        private void OffCleanState(Animal animal) => animal.Happiness = false;
        private void DeathState(Animal animal) => animal.Life = false;
    }
}