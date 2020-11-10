using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_Theme_03
{
    class Program
    {
        static void Main(string[] args)
        {
            // Написать игру, в которою могут играть два игрока.
            // При старте, игрокам предлагается ввести свои никнеймы.
            // Никнеймы хранятся до конца игры.
            // Программа загадывает случайное число gameNumber от 12 до 120 сообщая это число игрокам.
            // Игроки ходят по очереди(игра сообщает о ходе текущего игрока)
            // Игрок, ход которого указан вводит число userTry, которое может принимать значения 1, 2, 3 или 4,
            // введенное число вычитается из gameNumber
            // Новое значение gameNumber показывается игрокам на экране.
            // Выигрывает тот игрок, после чьего хода gameNumber обратилась в ноль.
            // Игра поздравляет победителя, предлагая сыграть реванш
            // 
            // * Бонус:
            // Подумать над возможностью реализации разных уровней сложности.
            // В качестве уровней сложности может выступать настраиваемое, в начале игры,
            // значение userTry, изменение диапазона gameNumber, или указание большего количества игроков (3, 4, 5...)

            // *** Сложный бонус
            // Подумать над возможностью реализации однопользовательской игры
            // т е игрок должен играть с компьютером


            // Демонстрация
            // Число: 12,
            // Ход User1: 3
            //
            // Число: 9
            // Ход User2: 4
            //
            // Число: 5
            // Ход User1: 2
            //
            // Число: 3
            // Ход User2: 3
            //
            // User2 победил!

            string playerName; // имя игрока
            int minValue = 12; // минимальное значение для случайного числа
            int maxValue = 120; // максимальное значение для случайного числа
            int minUserTry = 1; // минимальное число, которое может ввести игрок 
            int maxUserTry = 0; // максимальное значение, которое может ввести игрок (будет зависеть от выбранного уровня сложности)
            int gameLevel = 0;  // уровень сложности
            int userTry = 0; // число, которое вводит игрок
            string errorMessage = "Введено неверное значение"; // текст ошибки, которая возникает при вводе ошибочного значения

            Random randomize = new Random(); // генерируем случайное число от minValue до maxValue
            int gameNumber = randomize.Next(minValue, maxValue + 1);

            Console.Write("Введите ваше имя: ");
            playerName = Console.ReadLine(); // записываем имя игрока
            Console.Write("Укажите сложность игры (от 1 до 3): ");
            gameLevel = int.Parse(Console.ReadLine()); // устанавливаем уровень сложности
            switch (gameLevel) // определяем максимальное число (4,8,12), которое может ввести игрок, в зависимости от выбранного уровня сложности. По умолчанию назначается максимальный уровень.
            {
                case 1:
                    maxUserTry = 4;
                    break;
                case 2:
                    maxUserTry = 8;
                    break;
                default:
                    maxUserTry = 12;
                    break;
            }
            Console.WriteLine($"================================");
            Console.WriteLine($"Игра {playerName} vs ПК началась");
            Console.WriteLine($"================================");
            Console.WriteLine($"Текущее число: {gameNumber}");
            for (; ; ) // бесконечный цикл для ходов в игре
            {
                Console.Write($"Ход {playerName} (введите число от {minUserTry} до {maxUserTry}): ");
                userTry = int.Parse(Console.ReadLine()); // ввод числа игроком
                if (userTry >= minUserTry && userTry <= maxUserTry) // проверка на то, что введеное число входит в нужный промежуток
                {
                    gameNumber -= userTry; // определяем число, которое получилось, после ввода и вычитания его из gameNumber
                    Console.WriteLine($"Текущее число: {gameNumber} ");
                    Console.WriteLine("---");
                    if (gameNumber == 0) // если число равно нулю, то игрок победил
                    {
                        Console.WriteLine("############");
                        Console.WriteLine($"Победа {playerName}! ");
                        Console.WriteLine("############");
                        break;
                    }
                    else if (gameNumber < 0) // если число меньше нуля, то победил другой игрок
                    {
                        Console.WriteLine("############");
                        Console.WriteLine($"Победа ПК! ");
                        Console.WriteLine("############");
                        break;

                    }
                    else // иначе переход хода к другому игроку
                    {
                        userTry = randomize.Next(minUserTry, maxUserTry + 1); // генерация случайного хода ПК (число от minUserTry до maxUserTry)
                        Console.WriteLine($"Ход ПК: {userTry} ");
                        gameNumber -= userTry; // определяем число, которое получилось, после ввода и вычитания его из gameNumber
                        Console.WriteLine($"Текущее число: {gameNumber} ");
                        Console.WriteLine("---");
                        if (gameNumber == 0) // если число равно нулю, то ПК победил
                        {
                            Console.WriteLine("############");
                            Console.WriteLine($"Победа ПК! ");
                            Console.WriteLine("############");
                            break;
                        }
                        else if (gameNumber < 0) // если число меньше нуля, то победил другой игрок
                        {
                            Console.WriteLine("############");
                            Console.WriteLine($"Победа {playerName}! ");
                            Console.WriteLine("############");
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine(errorMessage); // вывод ошибки
                }

            }

            Console.ReadLine();
        }
    }
}
