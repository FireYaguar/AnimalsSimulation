using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class OnCleanObserver : IStateObserver
    {
        private event AnimalStateChangeHandler OnClean;

        public OnCleanObserver()
        {
            OnClean += OnCleanState;
        }

        public void UpdateState(Animal animal, AnimalEvent _event)
        {
            if (_event == AnimalEvent.Clean)
            {
                TriggerOnClean(animal);
            }   
        }

        public void TriggerOnClean(Animal animal) => OnClean?.Invoke(animal);

        private void OnCleanState(Animal animal) => animal.Happiness = true;
    }
}
