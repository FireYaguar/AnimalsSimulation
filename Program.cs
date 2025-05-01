//Program.cs
using System;
using System.Text;

namespace Lab3
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            var animals = new Lists();
            InitializeDefaultAnimals(animals);

            var menu = new Menu(animals);
            menu.Start();
        }

        private static void InitializeDefaultAnimals(Lists animals)
        {
            animals.CreateAnimal("Ссавці", "Ведмідь", "Wild");
            animals.CreateAnimal("Ссавці", "Заєць", "Wild");
            animals.CreateAnimal("Ссавці", "Хом'як", "Store");
            animals.CreateAnimal("Ссавці", "Собака", "Store");
            animals.CreateAnimal("Рептилії", "Змія", "Wild");
            animals.CreateAnimal("Рептилії", "Черепаха", "Store");
            animals.CreateAnimal("Рептилії", "Ігуана", "Store");
            animals.CreateAnimal("Рептилії", "Полоз", "Wild");
            animals.CreateAnimal("Птахи", "Горобець", "Wild");
            animals.CreateAnimal("Птахи", "Папуга", "Store");
            animals.CreateAnimal("Птахи", "Соловей", "Store");
            animals.CreateAnimal("Птахи", "Ворона", "Wild");
            animals.CreateAnimal("Ссавці", "Кіт", "House");
        }
    }
}