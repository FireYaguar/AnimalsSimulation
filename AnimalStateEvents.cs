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
        private event AnimalStateChangeHandler? OnGotHungry;
        private event AnimalStateChangeHandler? OnSatiety;
        private event AnimalStateChangeHandler? OnClean;
        private event AnimalStateChangeHandler? OffClean;
        private event AnimalStateChangeHandler? OnDeath;

        public AnimalStateEvents()
        {
            OnGotHungry += HungryState;
            OnSatiety += SatietyState;
            OnClean += onCleanState;
            OffClean += offCleanState;
            OnDeath += DeathState;
        }

        public void TriggerGotHungry(Animal animal)
        {
            OnGotHungry?.Invoke(animal);
        }
        public void TriggerSatiety(Animal animal)
        {
            OnSatiety?.Invoke(animal);
        }
        public void TriggerOnClean(Animal animal)
        {
            OnClean?.Invoke(animal);
        }
        public void TriggerOffClean(Animal animal)
        {
            OffClean?.Invoke(animal);
        }
        public void TriggerDeath(Animal animal)
        {
            OnDeath?.Invoke(animal);
        }

        private void HungryState(Animal animal)
        {
            animal.Hungry = true;

            if (animal is ICrawling crawl)
            {
                crawl.crawling = true;

                if (animal is IRunning run)
                {
                    run.running = false;
                }
                else if (animal is IFlying fly)
                {
                    fly.flying = false;
                    fly.singing = false;
                }
            }
        }

        private void SatietyState(Animal animal)
        {
            animal.Hungry = false;

            if (animal is ICrawling crawl && crawl.crawling)
            {
                crawl.crawling = false;

                if (this is IRunning run)
                {
                    run.running = true;
                }
                else if (this is IFlying fly)
                {
                    fly.flying = true;
                    fly.singing = true;
                }
            }
        }
        private void onCleanState(Animal animal)
        {
            animal.Happiness = true;
        }

        private void offCleanState(Animal animal)
        {
            animal.Happiness = false;
        }

        private void DeathState(Animal animal)
        {
            animal.Life = false;
        }
    }
}
