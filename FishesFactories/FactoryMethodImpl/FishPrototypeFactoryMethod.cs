using Fishes;
using FishesFactories.PrototypeImpl;


namespace FishesFactories
{
    /// <summary>
     /// Реализация фабричного метода для создания фабрики прототипов
     /// </summary>
    public class FishPrototypeFactoryMethod : FishFactoryMethod
    {
        /// <summary>
         /// Вода для рыбы
          /// </summary>
        private WaterForFish _waterForFish = null;

        /// <summary>
         /// Еда для рыбы
          /// </summary>
        private FishFood _fishFood = null;

        /// <summary>
         /// Конструктор
         /// </summary>
         /// <param name="parWaterForFish">Вода для рыбы</param>
         /// <param name="parFishFood">Еда для рыбы</param>
        public FishPrototypeFactoryMethod(WaterForFish parWaterForFish, FishFood parFishFood)
        {
            this._waterForFish = parWaterForFish;
            this._fishFood = parFishFood;
        }

        /// <summary>
         /// Создание фабрики прототипов
         /// </summary>
         /// <returns>Фабрика прототипов</returns>
        public override IFishFactory CreateFishFactory()
        {
            return new FishPrototypeFactory(_waterForFish, _fishFood);
        }
    }
}
