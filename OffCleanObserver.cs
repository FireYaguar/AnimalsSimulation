using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class OffCleanObserver : IStateObserver
    {
        private event AnimalStateChangeHandler OffClean;

        public OffCleanObserver()
        {
            OffClean += OffCleanState;
        }

        public void UpdateState(Animal animal, AnimalEvent _event)
        {
            if (_event == AnimalEvent.OffClean)
            {
                TriggerOffClean(animal);
            }
        }

        public void TriggerOffClean(Animal animal) => OffClean?.Invoke(animal);

        private void OffCleanState(Animal animal) => animal.Happiness = false;
    }
}
