using Fishes;

namespace FishesFactories
{
    /// <summary>
    /// Фабрика создания PredatorFishAndFreshwaterFishFactory
    /// </summary>
    public class PredatorFishAndFreshwaterFishFactory : AbstractFishFactory
    {
        /// <summary>
        /// Создание хищной рыбы
        /// </summary>
        /// <returns>Хищная рыба</returns>
        public override FishFood CreateFishFood()
        {
            return new PredatorFish();
        }

        /// <summary>
        /// Создание пресноводной рыбы
        /// </summary>
        /// <returns>Пресноводная рыба</returns>
        public override WaterForFish CreateWaterForFish()
        {
            return new FreshwaterFish();
        }

        /// <summary>
        /// Метод получения информации о классе
        /// </summary>
        /// <returns>Информация о классе</returns>
        public override string ToString()
        {
            return "Predator or freshwater";
        }
    }
}
