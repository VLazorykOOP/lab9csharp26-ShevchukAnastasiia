using System;
using System.Collections;
using System.IO;
using System.Text;

namespace Lab9CSharp
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("==================================================");
                Console.WriteLine("          ЛАБОРАТОРНА РОБОТА №9 (Варіант 21)      ");
                Console.WriteLine("==================================================");
                Console.WriteLine(" 1 - Завдання 1.1 (Stack: Числа у зворотному порядку)");
                Console.WriteLine(" 2 - Завдання 2.1 (Queue: Символи, потім цифри)");
                Console.WriteLine(" 3 - Завдання 3   (ArrayList: Задачі 1.1 та 2.1)");
                Console.WriteLine(" 4 - Завдання 4   (Hashtable: Каталог CD-дисків)");
                Console.WriteLine(" 0 - Вихід");
                Console.WriteLine("==================================================");
                Console.Write("Оберіть завдання: ");

                string choice = Console.ReadLine() ?? "";
                if (choice == "0") break;

                Console.WriteLine("\n--------------------------------------------------");

                switch (choice)
                {
                    case "1": Task1_Stack(); break;
                    case "2": Task2_Queue(); break;
                    case "3": Task3_ArrayList(); break;
                    case "4": Task4_Hashtable(); break;
                    default: Console.WriteLine("Невірний вибір!"); break;
                }

                Console.WriteLine("\n[Натисніть будь-яку клавішу для повернення в меню...]");
                Console.ReadKey();
            }
        }

        // ========================================================================
        // ЗАВДАННЯ 1.1: Використання Stack (Стек)
        // ========================================================================
        static void Task1_Stack()
        {
            string inFile = "t1_input.txt";
            string outFile = "t1_output.txt";

            // Створюємо тестовий файл із числами
            File.WriteAllText(inFile, "10 20 30 40 50 60 70");
            string text = File.ReadAllText(inFile);
            Console.WriteLine($"Початковий файл ({inFile}): {text}");

            // Розбиваємо текст на окремі числа
            string[] numbers = text.Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            
            // Використовуємо Стек (Останнім прийшов - першим вийшов)
            Stack stack = new Stack();
            foreach (string num in numbers)
            {
                stack.Push(num); // Додаємо на вершину стеку
            }

            // Записуємо у другий файл
            using (StreamWriter sw = new StreamWriter(outFile))
            {
                Console.Write($"Результат у файлі ({outFile}): ");
                while (stack.Count > 0)
                {
                    string val = stack.Pop().ToString(); // Витягуємо з вершини
                    sw.Write(val + " ");
                    Console.Write(val + " ");
                }
            }
            Console.WriteLine();
        }

        // ========================================================================
        // ЗАВДАННЯ 2.1: Використання Queue (Черга)
        // ========================================================================
        static void Task2_Queue()
        {
            string inFile = "t2_input.txt";
            File.WriteAllText(inFile, "A1B2C3D4!@5#6");
            string text = File.ReadAllText(inFile);
            
            Console.WriteLine("Завдання: вивести спочатку всі символи, відмінні від цифр, а потім цифри.");
            Console.WriteLine($"Початковий текст: {text}");

            // Використовуємо Чергу для тимчасового зберігання цифр (Першим прийшов - першим вийшов)
            Queue digitQueue = new Queue();

            Console.Write("Результат: ");
            
            // Один перегляд файлу (рядка)
            foreach (char c in text)
            {
                if (char.IsDigit(c))
                {
                    digitQueue.Enqueue(c); // Якщо цифра - ставимо в чергу
                }
                else
                {
                    Console.Write(c); // Якщо не цифра - друкуємо одразу
                }
            }

            // Після перегляду всього файлу дістаємо всі цифри з черги і друкуємо їх
            while (digitQueue.Count > 0)
            {
                Console.Write(digitQueue.Dequeue());
            }
            Console.WriteLine();
        }

        // ========================================================================
        // ЗАВДАННЯ 3: Використання ArrayList для задач 1.1 та 2.1
        // ========================================================================
        static void Task3_ArrayList()
        {
            Console.WriteLine("--- Рішення задачі 1.1 через ArrayList ---");
            string text1 = "11 22 33 44 55";
            Console.WriteLine($"Початкові числа: {text1}");
            
            ArrayList arrayList1 = new ArrayList(text1.Split(' '));
            arrayList1.Reverse(); // ArrayList має зручний метод для перевертання
            
            Console.Write("Зворотній порядок: ");
            foreach (var item in arrayList1) Console.Write(item + " ");
            Console.WriteLine("\n");

            Console.WriteLine("--- Рішення задачі 2.1 через ArrayList ---");
            string text2 = "X9Y8Z7(6)5";
            Console.WriteLine($"Початковий текст: {text2}");
            
            ArrayList digitsList = new ArrayList();
            Console.Write("Результат: ");
            
            foreach (char c in text2)
            {
                if (char.IsDigit(c)) digitsList.Add(c); // Додаємо в масив
                else Console.Write(c); // Друкуємо не цифри
            }
            
            // Друкуємо масив з цифрами
            foreach (char c in digitsList) Console.Write(c);
            Console.WriteLine();
        }

        // ========================================================================
        // ЗАВДАННЯ 4: Використання Hashtable (Каталог музичних CD)
        // ========================================================================
        static void Task4_Hashtable()
        {
            // Головна хеш-таблиця: Ключ = Назва Диска, Значення = Хеш-таблиця пісень
            Hashtable catalog = new Hashtable();

            Console.WriteLine("--- Створення каталогу та додавання дисків/пісень ---");
            
            // Створюємо Диск 1
            Hashtable cd1 = new Hashtable();
            cd1.Add("Bohemian Rhapsody", "Queen");
            cd1.Add("We Will Rock You", "Queen");
            catalog.Add("Greatest Hits Queen", cd1);
            Console.WriteLine("[+] Додано диск: 'Greatest Hits Queen' з піснями.");

            // Створюємо Диск 2
            Hashtable cd2 = new Hashtable();
            cd2.Add("Yesterday", "The Beatles");
            cd2.Add("Let It Be", "The Beatles");
            cd2.Add("Radio Ga Ga", "Queen"); // Додали Queen на інший диск для тесту пошуку
            catalog.Add("Mix Hits 80s", cd2);
            Console.WriteLine("[+] Додано диск: 'Mix Hits 80s' з піснями.");

            // 1. Перегляд вмісту цілого каталогу
            Console.WriteLine("\n--- Вміст цілого каталогу ---");
            foreach (DictionaryEntry cd in catalog)
            {
                Console.WriteLine($"Диск: [{cd.Key}]");
                Hashtable songs = (Hashtable)cd.Value;
                foreach (DictionaryEntry song in songs)
                {
                    Console.WriteLine($"   - Пісня: '{song.Key}', Виконавець: {song.Value}");
                }
            }

            // 2. Видалення пісні
            Console.WriteLine("\n--- Видаляємо пісню 'Let It Be' з диску 'Mix Hits 80s' ---");
            ((Hashtable)catalog["Mix Hits 80s"]).Remove("Let It Be");
            Console.WriteLine("Пісню видалено.");

            // 3. Пошук усіх записів заданого виконавця (наприклад, "Queen")
            string targetArtist = "Queen";
            Console.WriteLine($"\n--- Пошук усіх пісень виконавця: {targetArtist} ---");
            
            int count = 0;
            foreach (DictionaryEntry cd in catalog)
            {
                Hashtable songs = (Hashtable)cd.Value;
                foreach (DictionaryEntry song in songs)
                {
                    if (song.Value.ToString() == targetArtist)
                    {
                        Console.WriteLine($"Знайдено: '{song.Key}' (на диску '{cd.Key}')");
                        count++;
                    }
                }
            }
            if (count == 0) Console.WriteLine("Пісень не знайдено.");
        }
    }
}