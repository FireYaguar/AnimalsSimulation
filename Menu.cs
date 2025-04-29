using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Menu
    {
        private Status status = new Status();
        private Validation valid = new Validation();
        private bool active = true;
        private Lists lists;
        private Simulation sim;
        private const int MAX_DAYS = 100;
        private string Message = "Виберіоть один з навединих вище варіантів дій:\n";
        public Menu(Lists lists)
        {
            this.lists = lists;
            sim = new Simulation(lists);
        }

        public void Start()
        {
            while (active)
            {
                Console.WriteLine("Виберіть середовище або додайте тварину до середовища:\n" +
                    "1. Дика природа\n" +
                    "2. Зоомагазин\n" +
                    "3. Будинок власника\n" +
                    "4. Додати тварину до середовища\n" +
                    "5. Завершити симуляцію");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        bool active1 = true;
                        Console.Clear();
                        while (active1)
                        {
                            status.ShowAnimals(lists.wildAnimals);
                            Console.WriteLine("Виберіть дію:\n" +
                                "1. Переглянути статус відповідної тварини\n" +
                                "2. Запустити симуляцію\n" +
                                "3. Повернутися назад\n");

                            string? choice1 = Console.ReadLine();

                            switch (choice1)
                            {
                                case "1":
                                    int index = valid.ReadIntInRange("Виберіть номер тварини:\n", 1, lists.wildAnimals.Count);
                                    status.ShowStatus(lists.wildAnimals[index - 1]);
                                    break;
                                case "2":
                                    int days = valid.ReadIntInRange("Введіть кількість днів симуляції (1-100):\n", 1, MAX_DAYS);
                                    sim.wildSimulation(lists.wildAnimals, days, "Wild");
                                    break;
                                case "3":
                                    active1 = false;
                                    break;
                                default:
                                    Console.WriteLine(Message);
                                    break;
                            }
                        }
                        break;
                    case "2":
                        bool active2 = true;
                        Console.Clear();
                        while (active2)
                        {
                            status.ShowAnimals(lists.storeAnimals);
                            Console.WriteLine("Виберіть дію:\n" +
                                "1. Переглянути статус відповідної тварини\n" +
                                "2. Запустити симуляцію зоомагазину під контролем працівників\n" +
                                "3. Запустити симуляцію зоомагазину без контролю працівників\n" +
                                "4. Повернутися назад\n");

                            string? choice1 = Console.ReadLine();

                            switch (choice1)
                            {
                                case "1":
                                    int index = valid.ReadIntInRange("Виберіть номер тварини:\n", 1, lists.storeAnimals.Count);
                                    status.ShowStatus(lists.storeAnimals[index - 1]);
                                    break;
                                case "2":
                                    int days1 = valid.ReadIntInRange("Введіть кількість днів симуляції:\n", 1, MAX_DAYS);
                                    int amount1 = valid.ReadIntInRange("Введіть скільки разів на день тварин годують під час симуляції (1-5):\n", 1, 5);
                                    bool Cleaning = valid.AskYesNo("Чи прибирають працівники за тваринами та чи слідкують за чистотою їх місця проживання ? (Так/Ні)\n");
                                    sim.StoreControlSimulation(lists.storeAnimals, days1, amount1, Cleaning);
                                    break;
                                case "3":
                                    int days = valid.ReadIntInRange("Введіть кількість днів симуляції:\n", 1, MAX_DAYS);
                                    int amount = valid.ReadIntInRange("Введіть скільки їжі господар залишив тварині на час його відутності:\n", 0, int.MaxValue);
                                    sim.StoreNoControlSimulation(lists.storeAnimals, days, amount);
                                    break;
                                case "4":
                                    active2 = false;
                                    break;
                                default:
                                    Console.WriteLine(Message);
                                    break;
                            }
                        }
                        break;
                    case "3":
                        bool active3 = true;
                        Console.Clear();
                        while (active3)
                        {

                            if (lists.houseAnimal != null)
                            {
                                status.ShowPet(lists.houseAnimal);
                            }
                            Console.WriteLine("Виберіть дію:\n" +
                                "1. Переглянути статус домашнього улюбленця\n" +
                                "2. Запустити симуляцію звичайного життя тварини з господарем\n" +
                                "3. Запустити симуляцію життя тварини на самоті поки господаря немає дома\n" +
                                "4. Повернутися назад\n");

                            string? choice1 = Console.ReadLine();

                            switch (choice1)
                            {
                                case "1":
                                    if (lists.houseAnimal != null)
                                    {
                                        status.ShowStatus(lists.houseAnimal);
                                    }
                                    break;
                                case "2":
                                    if (lists.houseAnimal != null)
                                    {
                                        int days = valid.ReadIntInRange("Введіть кількість днів симуляції:\n", 1, MAX_DAYS);
                                        int amount = valid.ReadIntInRange("Введіть скільки разів на день тварин годують під час симуляції:\n", 0, 6);
                                        bool Cleaning = valid.AskYesNo("Чи прибирає господар за твариною та чи слідкує за чистотою її місця проживання ? (Так/Ні)\n");
                                        sim.HouseControlSimulation(lists.houseAnimal, days, amount, Cleaning);
                                    }
                                    break;
                                case "3":
                                    if (lists.houseAnimal != null)
                                    {
                                        int days = valid.ReadIntInRange("Введіть кількість днів симуляції:\n", 1, MAX_DAYS);
                                        int amount = valid.ReadIntInRange("Введіть скільки їжі господар залишив тварині на час його відутності:\n", 0, int.MaxValue);
                                        sim.HouseNoControlSimulation(lists.houseAnimal, days, amount);
                                    }
                                    break;
                                case "4":
                                    active3 = false;
                                    break;
                                default:
                                    Console.WriteLine(Message);
                                    break;
                            }
                        }
                        break;
                    case "4":
                        string group = valid.AskValidGroup();
                        string name = valid.AskAnimalName();
                        string envoriment = valid.AskValidEnvironment();
                        lists.CreateAnimals(group, name, envoriment);
                        break;
                    case "5":
                        Console.WriteLine("Завершення роботи");
                        active = false;
                        break;
                    default:
                        Console.WriteLine(Message);
                        break;
                }
                Console.Clear();
            }
        }
    }
}
