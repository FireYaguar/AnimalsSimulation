using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class State : IState
    {
        List<IStateObserver> stateObservers = new List<IStateObserver>();

        public void Attach (IStateObserver observer)
        {
            stateObservers.Add(observer);
        }

        public void Detach (IStateObserver observer)
        {
            stateObservers.Remove(observer);
        }

        public void Notify (Animal animal, AnimalEvent _event)
        {
            foreach (IStateObserver observer in stateObservers)
            {
                observer.UpdateState(animal, _event);
            }
        }
    }
}
