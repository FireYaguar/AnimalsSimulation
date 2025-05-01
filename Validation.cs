//Validation.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class Validation
    {
        public int ReadIntInRange(string prompt, int min, int max)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                if (int.TryParse(Console.ReadLine(), out int result) && result >= min && result <= max)
                {
                    return result;
                }
                Console.WriteLine($"Будь ласка, введіть число від {min} до {max}.");
            }
        }

        public string AskValidGroup()
        {
            while (true)
            {
                Console.WriteLine("Введіть групу до якої належить тварина (Ссавці/Рептилії/Птахи):");
                string? group = Console.ReadLine();
                if (group == "Ссавці" || group == "Рептилії" || group == "Птахи")
                {
                    return group;
                }
            }
        }

        public string AskAnimalName()
        {
            while (true)
            {
                Console.WriteLine("Введіть назву тварини:");
                string? name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name))
                {
                    return name;
                }
            }
        }

        public string AskValidEnvironment()
        {
            while (true)
            {
                Console.WriteLine("Виберіть середовище проживання тварини (Wild/Store/House):");
                string? environment = Console.ReadLine();
                if (environment == "Wild" || environment == "Store" || environment == "House")
                {
                    return environment;
                }
            }
        }

        public bool AskYesNo(string message)
        {
            while (true)
            {
                Console.WriteLine(message);
                string? answer = Console.ReadLine()?.Trim();

                if (answer == "Так") return true;
                if (answer == "Ні") return false;
            }
        }
    }
}
