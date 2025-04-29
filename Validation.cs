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
            int result;
            bool valid = false;

            do
            {
                Console.WriteLine(prompt);
                string? input = Console.ReadLine();

                if (int.TryParse(input, out result) && result >= min && result <= max)
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine($"Будь ласка, введіть число від {min} до {max}.");
                }

            } while (!valid);

            return result;
        }
        public string AskValidGroup()
        {
            string group;
            do
            {
                Console.WriteLine("Введіть групу до якої належить тварина (Ссавці/Рептилії/Птахи):");
                group = Console.ReadLine();
            } while (group != "Ссавці" && group != "Рептилії" && group != "Птахи");
            return group;
        }

        public string AskAnimalName()
        {
            string name;
            do
            {
                Console.WriteLine("Введіть назву тварини:");
                name = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(name));
            return name;
        }

        public string AskValidEnvironment()
        {
            string environment;
            do
            {
                Console.WriteLine("Виберіть середовище проживання тварини (Wild/Store/House):");
                environment = Console.ReadLine();
            } while (environment != "Wild" && environment != "Store" && environment != "House");
            return environment;
        }

        public bool AskYesNo(string message)
        {
            while (true)
            {
                Console.WriteLine(message);
                string answer = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(answer))
                {
                    continue;
                }

                if (answer == "Так")
                {
                    return true;
                }
                else if (answer == "Ні")
                {
                    return false;
                }
            }
        }

    }
}
