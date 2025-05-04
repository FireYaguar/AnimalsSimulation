using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class DeathObserver : IStateObserver
    {
        private event AnimalStateChangeHandler OnDeath;

        public DeathObserver()
        {
            OnDeath += DeathState;
        }

        public void UpdateState(Animal animal, AnimalEvent _event)
        {
            if (_event == AnimalEvent.Death)
            {
                TriggerDeath(animal);
            }
        }

        public void TriggerDeath(Animal animal) => OnDeath?.Invoke(animal);

        private void DeathState(Animal animal) => animal.Life = false;
    }
}
