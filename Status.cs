using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Status
    {
        public void ShowStatus(Animal animal)
        {
            Console.WriteLine("Тварина: " + animal.Name);
            Console.WriteLine("Очі: " + (animal.Eyes ? "наявні" : "відсутні"));
            Console.WriteLine("Лапи: " + (animal.Paws ? "наявні" : "відсутні"));
            Console.WriteLine("Крила: " + (animal is Birds ? "наявні" : "відсутні"));
            Console.WriteLine("Здатність їсти: " + (animal.Eating ? "може" : "не може"));
            Console.WriteLine("Здатність співати: " + (animal is IFlying flyAnimal && flyAnimal.singing ? "співає" : "не співає"));
            Console.WriteLine("Голод: " + (animal.Hungry ? "голодна" : "сита"));
            if (animal is Birds && !animal.Hungry)
            {
                Console.WriteLine("Тип переміщення: " + (animal is IFlying flyingAnimal && flyingAnimal.flying ? "літає\n" : "не літає\n"));
            }
            else if (animal is Mammals && !animal.Hungry)
            {
                Console.WriteLine("Тип переміщення: " + (animal is IRunning runningAnimal && runningAnimal.running ? "бігає\n" : "не бігає\n"));
            }
            else
            {
                Console.WriteLine("Тип переміщення: " + (animal is ICrawling crawlingAnimal && crawlingAnimal.crawling ? "повзає\n" : "не повзає\n"));
            }
            Console.WriteLine("Тварина: " + (animal.Happiness ? "щаслива" : "не щаслива"));
            Console.ReadLine();
        }

        public void ShowAnimals(List<Animal> animals)
        {
            Console.WriteLine("Всі тварини що проживають у цьому середовищі:\n");
            for (int i = 0; i < animals.Count; i++)
            {
                Console.WriteLine(i + 1 + " " + animals[i].Name + "\n");
            }
        }

        public void ShowPet(Animal animal)
        {
            Console.WriteLine("Домашній улюбленець: " + animal.Name + "\n");
        }

        public void simulationEnd(List<Animal> animals)
        {
            bool DeadAnimals = false;
            foreach (Animal animal in animals)
            {
                if (!animal.Life)
                {
                    DeadAnimals = true;
                    break;
                }
            }
            if (DeadAnimals)
            {
                Console.WriteLine("Всі тварини що померли у цьому середовищі під час симуляції:\n");
                int i = 1;
                foreach (Animal animal in animals)
                {
                    if (!animal.Life)
                    {
                        Console.WriteLine(i + " " + animal.Name + "\n");
                        i++;
                    }
                }
            }
            else
            {
                Console.WriteLine("під час симуляції не померла жодна тварина");
            }
        }

        public void HouseSimulationEnd(Animal animal)
        {
            if (!animal.Life)
            {
                Console.WriteLine("На жаль домашній улюбленець господаря " + animal.Name + " не пережив цю симуляцію\n");
            }
            else
            {
                Console.WriteLine("Домашній улюбленець господаря " + animal.Name + " пережив симуляцію");
            }
        }
    }
}
