using Fishes;

namespace FishesFactories
{
    /// <summary>
    /// Абстрактная фабрика
    /// </summary>
    public abstract class AbstractFishFactory : IFishFactory
    {
        /// <summary>
        /// Создание WaterForFish
        /// </summary>
        /// <returns>WaterForFish</returns>
        public abstract WaterForFish CreateWaterForFish();

        /// <summary>
        /// Создание FishFood
        /// </summary>
        /// <returns>FishFood</returns>
        public abstract FishFood CreateFishFood();
    }
}
