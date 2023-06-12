namespace Fish
{
    /// <summary>
    /// Аквариумные рыбы
    /// </summary>
    public class AquariumFish : Fish
    {
        /// <summary>
        /// Тип размножения
        /// </summary>
        public Reproduction _reproduction;

        public Reproduction Reproduction
        {
            get => _reproduction;
            set => _reproduction = value;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parPredatory">Хищность</param>
        /// <param name="parSize"></param>
        /// <param name="parName"></param>
        public AquariumFish(string parName,
                            int parSize,
                            Classes parClass,
                            Orders parOrder,
                            Families parFamily,
                            Reproduction parReproduction) : base(parName, parSize, parClass, parOrder, parFamily)
        {
            _reproduction = parReproduction;
        }

        internal PredatorFish IsPredatory()
        {
            throw new NotImplementedException();
        }

        internal HerbivorousFish IsHerbivorous()
        {
            throw new NotImplementedException();
        }
    }
}
