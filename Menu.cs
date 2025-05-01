//Menu.cs
namespace Lab3
{
    public class Menu
    {
        private readonly Status _status;
        private readonly Validation _validator;
        private readonly Lists _animals;
        private readonly Simulation _simulation;
        private readonly FeedingData context = new FeedingData();

        private const int MaxDays = 100;
        private const string DefaultMessage = "Виберіть один з наведених вище варіантів дій:\n";

        public Menu(Lists animals)
        {
            _animals = animals ?? throw new ArgumentNullException(nameof(animals));
            _status = new Status();
            _validator = new Validation();
            _simulation = new Simulation(_animals);
        }

        public void Start()
        {
            while (true)
            {
                Console.WriteLine("Виберіть середовище або додайте тварину до середовища:\n" +
                              "1. Дика природа\n" +
                              "2. Зоомагазин\n" +
                              "3. Будинок власника\n" +
                              "4. Додати тварину до середовища\n" +
                              "5. Завершити симуляцію");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        HandleWildEnvironment();
                        break;
                    case "2":
                        Console.Clear();
                        HandleStoreEnvironment();
                        break;
                    case "3":
                        Console.Clear();
                        HandleHouseEnvironment();
                        break;
                    case "4":
                        AddNewAnimal();
                        break;
                    case "5":
                        Console.WriteLine("Завершення роботи");
                        return;
                    default:
                        Console.WriteLine(DefaultMessage);
                        break;
                }
                Console.Clear();
            }
        }

        private void HandleWildEnvironment()
        {
            while (true)
            {
                _status.ShowAnimals(_animals.WildAnimals);
                Console.WriteLine("Виберіть дію:\n" +
                                "1. Переглянути статус відповідної тварини\n" +
                                "2. Запустити симуляцію\n" +
                                "3. Повернутися назад\n");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        int index = _validator.ReadIntInRange("Виберіть номер тварини:\n", 1, _animals.WildAnimals.Count);
                        _status.ShowStatus(_animals.WildAnimals[index - 1]);
                        break;
                    case "2":
                        int days = _validator.ReadIntInRange("Введіть кількість днів симуляції (1-100):\n", 1, MaxDays);
                        _simulation.RunWildSimulation(days, context);
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine(DefaultMessage);
                        break;
                }
            }
        }

        private void HandleStoreEnvironment()
        {
            while (true)
            {
                _status.ShowAnimals(_animals.StoreAnimals);
                Console.WriteLine("Виберіть дію:\n" +
                                "1. Переглянути статус відповідної тварини\n" +
                                "2. Запустити симуляцію зоомагазину під контролем працівників\n" +
                                "3. Запустити симуляцію зоомагазину без контролю працівників\n" +
                                "4. Повернутися назад\n");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        int index = _validator.ReadIntInRange("Виберіть номер тварини:\n", 1, _animals.StoreAnimals.Count);
                        _status.ShowStatus(_animals.StoreAnimals[index - 1]);
                        break;
                    case "2":
                        int days = _validator.ReadIntInRange("Введіть кількість днів симуляції:\n", 1, MaxDays);
                        context.MealsAmount = _validator.ReadIntInRange("Введіть скільки разів на день тварин годують під час симуляції (1-5):\n", 1, 5);
                        context.Cleaning = _validator.AskYesNo("Чи прибирають працівники за тваринами та чи слідкують за чистотою їх місця проживання? (Так/Ні)\n");
                        _simulation.RunStoreControlledSimulation(days, context);
                        break;
                    case "3":
                        int daysNoControl = _validator.ReadIntInRange("Введіть кількість днів симуляції:\n", 1, MaxDays);
                        context.FoodAmount = _validator.ReadIntInRange("Введіть скільки їжі працівники залишили тваринам на час їхньої відсутності:\n", 0, int.MaxValue);
                        _simulation.RunStoreUncontrolledSimulation(daysNoControl, context);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine(DefaultMessage);
                        break;
                }
            }
        }

        private void HandleHouseEnvironment()
        {
            if (_animals.HouseAnimal == null)
            {
                Console.WriteLine("Немає домашньої тварини");
                return;
            }

            while (true)
            {
                _status.ShowPet(_animals.HouseAnimal);
                Console.WriteLine("Виберіть дію:\n" +
                                "1. Переглянути статус домашнього улюбленця\n" +
                                "2. Запустити симуляцію звичайного життя тварини з господарем\n" +
                                "3. Запустити симуляцію життя тварини на самоті поки господаря немає дома\n" +
                                "4. Повернутися назад\n");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        _status.ShowStatus(_animals.HouseAnimal);
                        break;
                    case "2":
                        int days = _validator.ReadIntInRange("Введіть кількість днів симуляції:\n", 1, MaxDays);
                        context.MealsAmount = _validator.ReadIntInRange("Введіть скільки разів на день тварин годують під час симуляції:\n", 0, 6);
                        context.Cleaning = _validator.AskYesNo("Чи прибирає господар за твариною та чи слідкує за чистотою її місця проживання? (Так/Ні)\n");
                        _simulation.RunHouseControlledSimulation(days, context);
                        break;
                    case "3":
                        int daysAlone = _validator.ReadIntInRange("Введіть кількість днів симуляції:\n", 1, MaxDays);
                        context.FoodAmount = _validator.ReadIntInRange("Введіть скільки їжі господар залишив тварині на час його відсутності:\n", 0, int.MaxValue);
                        _simulation.RunHouseUncontrolledSimulation(daysAlone, context);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine(DefaultMessage);
                        break;
                }
            }
        }

        private void AddNewAnimal()
        {
            string group = _validator.AskValidGroup();
            string name = _validator.AskAnimalName();
            string environment = _validator.AskValidEnvironment();
            _animals.CreateAnimal(group, name, environment);
        }
    }
}
