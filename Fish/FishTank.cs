namespace Fish
{
    public class FishTank : AquariumFish
    {
        private readonly List<AquariumFish> _fishList;
        private readonly FishFood _fishFood;
        /// <summary>
        /// Объем аквариума
        /// </summary>
        private readonly double _tankVolume;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parName"></param>
        /// <param name="parSize"></param>
        /// <param name="parClass"></param>
        /// <param name="parOrder"></param>
        /// <param name="parFamily"></param>
        /// <param name="parPredatorFish"></param>
        /// <param name="parReproduction"></param>
        /// <param name="parFreshwaterFish"></param>
        /// <param name="tankVolume"></param>
        /// <param name="fishFood"></param>
        public FishTank(string parName,
                        int parSize,
                        Classes parClass,
                        Orders parOrder,
                        Families parFamily,
                        PredatorFish parPredatorFish,
                        Reproduction parReproduction,
                        FreshwaterFish parFreshwaterFish,
                        double tankVolume,
                        FishFood fishFood) : base(parName, parSize, parClass, parOrder, parFamily, parReproduction)
        {
            _fishList = new List<AquariumFish>();
            _fishFood = fishFood;
            _tankVolume = tankVolume;
        }

        /// <summary>
        /// Добавить рыбу
        /// </summary>
        /// <param name="fish"></param>
        public void AddFish(AquariumFish fish)
        {
            _fishList.Add(fish);
        }

        /// <summary>
        /// Удалить рыбу
        /// </summary>
        /// <param name="fish"></param>
        public void RemoveFish(AquariumFish fish)
        {
            _fishList.Remove(fish);
        }

        /// <summary>
        /// Еда рыб
        /// </summary>
        public void FeedFish()
        {
            foreach (AquariumFish fish in _fishList)
            {
                if (_fishFood.NeedsHighProteinFood(fish.IsPredatory()))
                {
                    Console.WriteLine("Feeding {0} with high protein food");
                }
                else if (_fishFood.NeedsLowProteinFood(fish.IsHerbivorous()))
                {
                    Console.WriteLine("Feeding {0} with low protein food");
                }
            }
        }
    }
}