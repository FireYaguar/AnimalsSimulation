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
            Lists lists = new Lists();
            lists.CreateAnimals("Ссавці", "Ведмідь", "Wild");
            lists.CreateAnimals("Ссавці", "Заєць", "Wild");
            lists.CreateAnimals("Ссавці", "Хом'як", "Store");
            lists.CreateAnimals("Ссавці", "Собака", "Store");
            lists.CreateAnimals("Рептилії", "Змія", "Wild");
            lists.CreateAnimals("Рептилії", "Черепаха", "Store");
            lists.CreateAnimals("Рептилії", "Ігуана", "Store");
            lists.CreateAnimals("Рептилії", "Полоз", "Wild");
            lists.CreateAnimals("Птахи", "Горобець", "Wild");
            lists.CreateAnimals("Птахи", "Папуга", "Store");
            lists.CreateAnimals("Птахи", "Соловей", "Store");
            lists.CreateAnimals("Птахи", "Ворона", "Wild");
            lists.CreateAnimals("Ссавці", "Кіт", "House");
            Menu menu = new Menu(lists);
            menu.Start();
        }
    }
}