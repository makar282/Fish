namespace Fish
{
    public class FishTank : AquariumFish
    {
        private readonly List<AquariumFish> _fishList;
        private readonly FishFood _fishFood;
        private readonly double _tankVolume;

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

        public void AddFish(AquariumFish fish)
        {
            _fishList.Add(fish);
        }

        public void RemoveFish(AquariumFish fish)
        {
            _fishList.Remove(fish);
        }

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