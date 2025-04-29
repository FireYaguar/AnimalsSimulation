using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab3
{
    public abstract class Animal
    {
        public string? Name { get; set; }
        public bool Hungry { get; set; } = false;
        public bool Eyes { get; } = true;
        public bool Paws { get; set; } = true;
        public bool Eating { get; } = true;
        public bool Happiness { get; set; } = true;
        public bool Life { get; set; } = true;

        public int timeWithoutFood = 0;
        public int mealsCount;
        public int DeathTime;
        public string Envoriment;
        protected Animal(string name, string envoriment)
        {
            this.Name = name;
            this.Envoriment = envoriment;
        }
        public void GotHungry(int time, AnimalStateEvents stateEvents)
        {
            if (timeWithoutFood == 9)
            {
                Console.WriteLine((time < 10 ? "0" + time : time) + ":00 " + "Тварина " + Name + " не їла 8 годин, вона може лише повзати\n");
                stateEvents.TriggerGotHungry(this);
            }
        }
    }
}
