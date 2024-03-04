using Fishes;
using System;
using System.Linq;

namespace Form1.Helpers
{
    /// <summary>
    /// Генератор лодок
    /// </summary>
    public class FishGenerator
    {
        /// <summary>
        /// Минимальный индекс
        /// </summary>
        private const int MIN_INDEX = 0;

        /// <summary>
        /// Максимальный индекс
        /// </summary>
        private const int MAX_INDEX = 4;

        /// <summary>
        /// Минимальное значение доступные для рандома
        /// </summary>
        private const int MIN_VALUE = 5;

        /// <summary>
        /// Максимальное значение доступные для рандома
        /// </summary>
        private const int MAX_VALUE = 100;

        /// <summary>
        /// Символы доступные для рандома
        /// </summary>
        private const string CHARS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// Объект генератора случайных элементов
        /// </summary>
        private static readonly Random _fishRandom = new Random();

        /// <summary>
        /// Генерация наследника Fish
        /// </summary>
        /// <returns>Объект Fish</returns>
        /// <exception cref="Exception">Исключение, если не найден тип Fish</exception>
        public static Fish GenerateTestFish()
        {
             int randomClassIndex = _fishRandom.Next(MIN_INDEX, MAX_INDEX);

            switch (randomClassIndex)
            {
                case 0:
                    return GenerateSaltwaterFish();
                case 1:
                    return GenerateFreshwaterFish();
                case 2:
                    return GeneratePredatorFish();
                case 3:
                    return GenerateHerbivorousFish();
                default:
                    throw new Exception("Not found this type of object");
            }
        }

        /// <summary>
        /// Генерация объекта SaltwaterFish
        /// </summary>
        /// <returns>Объект SaltwaterFish</returns>
        private static SaltwaterFish GenerateSaltwaterFish()
        {
            return new SaltwaterFish(parName: "Clupeidae",
                                     parSize: 20,
                                     parTemperature: 20,
                                     parClass: Classes.Sarcopterygii,
                                     parOrder: Orders.Perciformes,
                                     parFamily: Families.Salmonidae,
                                     parReproduction: Reproductions.Hermaphroditism,
                                     parIsFreshwaterFish: true,
                                     parIsSaltwaterFish: true,
                                     parSalinity: 10,
                                     parDensity: 60);
        }

        /// <summary>
        /// Генерация объекта FreshwaterFish
        /// </summary>
        /// <returns>Объект FreshwaterFish</returns>
        private static FreshwaterFish GenerateFreshwaterFish()
        {
            return new FreshwaterFish(parName: "Carassius",
                                      parSize: 20,
                                      parTemperature: 20,
                                      parClass: Classes.Actinopterygii,
                                      parOrder: Orders.Perciformes,
                                      parFamily: Families.Salmonidae,
                                      parReproduction: Reproductions.Hermaphroditism,
                                      parIsFreshwaterFish: true,
                                      parIsSaltwaterFish: false,
                                      parDisambiguation: 10,
                                      parHardness: 7);
        }

        /// <summary>
        /// Генерация объекта PredatorFish
        /// </summary>
        /// <returns>Объект PredatorFish</returns>
        private static PredatorFish GeneratePredatorFish()
        {
            return new PredatorFish(parName: "Perch",
                                    parSize: 5,
                                    parClass: Classes.Osteichthyes,
                                    parOrder: Orders.Serraniformes,
                                    parFamily: Families.Clupeidae,
                                    parReproduction: Reproductions.Hermaphroditism,
                                    parFoodType: FoodType.Bloodworm,
                                    parProteinContent: 20,
                                    parSizeClassification: 10,
                                    parIsPredator: true);
        }

        /// <summary>
        /// Генерация объекта HerbivorousFish
        /// </summary>
        /// <returns>Объект HerbivorousFish</returns>
        private static HerbivorousFish GenerateHerbivorousFish()
        {
            return new HerbivorousFish(parName: "Cupid",
                                       parSize: 5,
                                       parClass: Classes.Osteichthyes,
                                       parOrder: Orders.Serraniformes,
                                       parFamily: Families.Clupeidae,
                                       parReproduction: Reproductions.Hermaphroditism,
                                       parFoodType: FoodType.Bloodworm,
                                       parProteinContent: 20,
                                       parSizeClassification: 10,
                                       parIsHerbivorous: true);
        }

        /// <summary>
        /// Генерация случайного вещественного числа
        /// </summary>
        /// <returns>Вещественное число</returns>
        private static double GenerateRandomDouble()
        {
            return Math.Round(_fishRandom.NextDouble() * (MAX_VALUE - MIN_VALUE) + MIN_VALUE, 2);
        }/// <summary>
         /// Генерация случайного целого числа
         /// </summary>
         /// <returns>Целое число</returns>
        private static int GenerateRandomInt()
        {
            return _fishRandom.Next(MIN_VALUE, MAX_VALUE);
        }

        /// <summary>
        /// Генерация случайного значения из заданного перечисления
        /// </summary>
        /// <typeparam name="T">Перечисление</typeparam>
        /// <returns>Элемент перечисления</returns>
        private static T GenerateRandomEnumValue<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(_fishRandom.Next(v.Length))!;
        }

        /// <summary>
        /// Генерация случайной строки
        /// </summary>
        /// <param name="parLength">Длина генерируемой строки</param>
        /// <returns>Случайная строка</returns>
        private static string GenerateRandomString(int parLength)
        {
            return new string(Enumerable.Repeat(CHARS, parLength)
                .Select(s => s[_fishRandom.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Генерация случайного булевого значения
        /// </summary>
        /// <param name="parLength">Длина генерируемой строки</param>
        /// <returns>Случайная строка</returns>
        private static bool GenerateRandomBoolean()
        {
            return _fishRandom.Next(0, 1) > 0;
        }
    }
}
