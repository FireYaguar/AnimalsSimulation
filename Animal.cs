//Animal.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

// Animal.cs
namespace Lab3
{
    public abstract class Animal
    {
        public string Name { get; protected set; }
        public bool Hungry { get; set; }
        public bool Eyes { get; } = true;
        public bool Paws { get; set; } = true;
        public bool Eating { get; } = true;
        public bool Happiness { get; set; } = true;
        public bool Life { get; set; } = true;

        public int TimeWithoutFood { get; set; } = 0;
        public int MealsCount { get; set; }
        public string Environment { get; }

        protected Animal(string name, string environment)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Environment = environment ?? throw new ArgumentNullException(nameof(environment));
        }

        public void GotHungry(int time, AnimalStateEvents stateEvents)
        {
            if (stateEvents == null) throw new ArgumentNullException(nameof(stateEvents));

            if (TimeWithoutFood == 9)
            {
                Console.WriteLine($"{(time < 10 ? "0" + time : time)}:00 Тварина {Name} не їла 8 годин, вона може лише повзати\n");
                stateEvents.TriggerGotHungry(this);
            }
        }
    }
}
