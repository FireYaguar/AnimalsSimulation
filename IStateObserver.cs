using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public delegate void AnimalStateChangeHandler(Animal animal);

    public interface IStateObserver
    {
        void UpdateState(Animal animal, AnimalEvent _event);
    }
}