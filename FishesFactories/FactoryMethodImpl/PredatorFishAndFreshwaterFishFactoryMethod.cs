namespace FishesFactories.FactoryMethodImpl
{
    /// <summary>
    /// Реализация фабричного метода
    /// </summary>
    public class PredatorFishAndFreshwaterFishFactoryMethod : FishFactoryMethod
    {
        /// <summary>
        /// Создание фабрики
        /// </summary>
        /// <returns>Фабрика хищных и пресноводных рыб</returns>
        public override IFishFactory CreateFishFactory()
        {
            return new PredatorFishAndFreshwaterFishFactory();
        }
    }
}
