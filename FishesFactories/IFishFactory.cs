using Fishes;

namespace FishesFactories
{
  /// <summary>
  /// Интерфейс фабрики рыб
  /// </summary>
  public interface IFishFactory
  {
        /// <summary>
        /// Создание WaterForFish
        /// </summary>
        /// <returns>WaterForFish</returns>
        WaterForFish CreateWaterForFish();

        /// <summary>
        /// Создание FishFood
        /// </summary>
        /// <returns>FishFood</returns>
        FishFood CreateFishFood();
    }
}