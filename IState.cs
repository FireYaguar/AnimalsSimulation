using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public interface IState
    {
        void Attach(IStateObserver observer);
        void Detach(IStateObserver observer);
        void Notify(Animal animal, AnimalEvent _event);
    }
}