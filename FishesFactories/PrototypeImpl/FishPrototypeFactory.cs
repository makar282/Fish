using Fishes;

namespace FishesFactories.PrototypeImpl
{
    /// <summary>
     /// Фабрика прототипов
     /// </summary>
    public class FishPrototypeFactory : IFishFactory
    {
        /// <summary>
        /// Хищная рыба
        /// </summary>
        private WaterForFish _waterForFish = null;

        /// <summary>
        /// Пресноводная рыба
        /// </summary>
        private FishFood _fishFood = null;

        /// <summary>
        /// /// Конструктор
        /// /// </summary>
        /// <param name="parWaterForFish">Хищная рыба</param>
        /// <param name="parFishFood">Пресноводная рыба</param>
        public FishPrototypeFactory(WaterForFish parWaterForFish, FishFood parFishFood)
        {
            this._waterForFish = parWaterForFish;
            this._fishFood = parFishFood;
        }



        /// <summary>
        /// Создание хищника
        /// </summary>
        /// <returns>Хищник</returns>
        public WaterForFish CreateWaterForFish()
        {
            return (WaterForFish)this._waterForFish.Clone();
        }

        /// <summary>
        /// Создание пресноводной рыбы
        /// </summary>
        /// <returns>Пресноводная рыба</returns>
        public FishFood CreateFishFood()
        {
            return (FishFood)this._fishFood.Clone();
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
