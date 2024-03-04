namespace FishesFactories
{
    /// <summary>
     /// Реализация фабричного метода для создания фабрики травоядных и морских рыб
     /// </summary>
    public class HerbivorousFishAndSaltwaterFishFactoryMethod : FishFactoryMethod
    {
        /// <summary>
          /// Создание фабрики травоядных и морских рыб
          /// </summary>
          /// <returns>Фабрика травоядных и морских рыб</returns>
        public override IFishFactory CreateFishFactory()
        {
            return new HerbivorousFishAndSaltwaterFishFactory();
        }
    }
}
