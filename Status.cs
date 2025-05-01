//Status.cs
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
            Console.WriteLine($"Тварина: {animal.Name}");
            Console.WriteLine($"Очі: {(animal.Eyes ? "наявні" : "відсутні")}");
            Console.WriteLine($"Лапи: {(animal.Paws ? "наявні" : "відсутні")}");
            Console.WriteLine($"Крила: {(animal is Birds ? "наявні" : "відсутні")}");
            Console.WriteLine($"Здатність їсти: {(animal.Eating ? "може" : "не може")}");

            if (animal is IFlying flyingAnimal)
            {
                Console.WriteLine($"Здатність співати: {(flyingAnimal.Singing ? "співає" : "не співає")}");
            }

            Console.WriteLine($"Голод: {(animal.Hungry ? "голодна" : "сита")}");
            Console.WriteLine($"Тип переміщення: {GetMovementType(animal)}\n");
            Console.WriteLine($"Тварина: {(animal.Happiness ? "щаслива" : "не щаслива")}");
            Console.ReadLine();
        }

        private string GetMovementType(Animal animal)
        {
            if (animal.Hungry)
            {
                return "повзає";
            }
            else
            {
                if (animal is IFlying flying && flying.Flying)
                    return "літає";

                else if (animal is IRunning running && running.Running)
                    return "бігає";

                else
                    return "повзає";
            }
        }

        public void ShowAnimals(List<Animal> animals)
        {
            Console.WriteLine("Всі тварини що проживають у цьому середовищі:\n");
            for (int i = 0; i < animals.Count; i++)
            {
                Console.WriteLine($"{i + 1} {animals[i].Name}\n");
            }
        }

        public void ShowPet(Animal animal)
        {
            if (animal != null)
                Console.WriteLine($"Домашній улюбленець: {animal.Name}\n");
        }

        public void ShowSimulationEnd(IEnumerable<Animal> animals)
        {
            var deadAnimals = new List<Animal>();

            foreach (var animal in animals)
            {
                if (!animal.Life)
                {
                    deadAnimals.Add(animal);
                }
            }

            if (deadAnimals.Count > 0)
            {
                Console.WriteLine("Всі тварини що померли у цьому середовищі під час симуляції:\n");
                for (int i = 0; i < deadAnimals.Count; i++)
                {
                    Console.WriteLine($"{i + 1} {deadAnimals[i].Name}\n");
                }
            }
            else
            {
                Console.WriteLine("Під час симуляції не померла жодна тварина");
            }
        }

        public void ShowHouseSimulationEnd(Animal animal)
        {
            Console.WriteLine(animal.Life
                ? $"Домашній улюбленець господаря {animal.Name} пережив симуляцію"
                : $"На жаль домашній улюбленець господаря {animal.Name} не пережив цю симуляцію\n");
        }
    }
}