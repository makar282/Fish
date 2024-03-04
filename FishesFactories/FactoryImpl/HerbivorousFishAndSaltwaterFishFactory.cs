using Fishes;

namespace FishesFactories
{
    /// <summary>
    /// Фабрика создания HerbivorousFishAndSaltwaterFishFactory
    /// </summary>
    public class HerbivorousFishAndSaltwaterFishFactory : AbstractFishFactory
    {
        /// <summary>
        /// Создание HerbivorousFish
        /// </summary>
        /// <returns>Пресноводная</returns>
        public override FishFood CreateFishFood()
        {
            return new HerbivorousFish();
        }

        /// <summary>
        /// Создание морской рыбы
        /// </summary>
        /// <returns>Морская рыба</returns>
        public override WaterForFish CreateWaterForFish()
        {
            return new SaltwaterFish();
        }

        /// <summary>
        /// Метод получения информации о классе
        /// </summary>
        /// <returns>Информация о классе</returns>
        public override string ToString()
        {
            return "Herbivorous or marine";
        }
    }
}
