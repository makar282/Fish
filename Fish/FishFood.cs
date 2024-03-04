namespace Fishes
{
    /// <summary>
    /// Корм для рыб
    /// </summary>
    public abstract class FishFood : Fish
    {
        /// <summary>
        /// </summary>
        private FoodType _foodType;
        /// <summary>
        /// Тип корма
        /// Размер корма
        /// </summary>
        private int _sizeClassification;
        /// <summary>
        /// Содержание белка
        /// </summary>
        private int _proteinContent;

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public FishFood()
        {
        }

        /// <summary>
        /// Конструктор класса FishFood
        /// </summary>
        /// <param name="parName"></param>
        /// <param name="parSize"></param>
        /// <param name="parTemperature"></param>
        /// <param name="parClass"></param>
        /// <param name="parOrder"></param>
        /// <param name="parFamily"></param>
        /// <param name="parReproduction"></param>
        /// <param name="parFoodType"></param>
        /// <param name="parProteinContent"></param>
        /// <param name="parSizeClassification"></param>
        public FishFood(string parName,
                        int parSize,
                        Classes parClass,
                        Orders parOrder,
                        Families parFamily,
                        Reproductions parReproduction,
                        FoodType parFoodType,
                        int parProteinContent,
                        int parSizeClassification) : base(parName, parSize, parClass, parOrder, parFamily, parReproduction)
        {
            _foodType = parFoodType;
            _sizeClassification = parSizeClassification;
            _proteinContent = parProteinContent;
        }

        /// <summary>
        /// Констуктор копирования
        /// </summary>
        /// <param name="parFish">Художественная принадлежность</param>
        public FishFood(Fish parFish) : base(parFish)
        {
            this.Copy(parFish);
        }

        /// <summary>
        /// Get и Set методы для атрибутов класса FishFood
        /// </summary>
        public FoodType FoodType
        {
            get { return _foodType; }
            set { _foodType = value; }
        }

        /// <summary>
        /// Get и Set методы для классификации размеров корма
        /// </summary>
        public int SizeClassification
        {
            get { return _sizeClassification; }
            set { _sizeClassification = value; }
        }

        /// <summary>
        /// Get и Set методы для содержания белка в корме
        /// </summary>
        public int ProteinContent
        {
            get { return _proteinContent; }
            set { _proteinContent = value; }
        }

        /// <summary>
        /// Метод для проверки, нужен ли корм с содержанием белка минимум 50%
        /// </summary>
        /// <returns></returns>
        public bool NeedsHighProteinFood(PredatorFish parPredatorFish)
        {
            if (parPredatorFish.IsPredator && _proteinContent >= 50)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Метод для проверки, нужен ли корм с низким содержанием белка и не является ли он Bloodworm
        /// </summary>
        /// <returns></returns>
        public bool NeedsLowProteinFood(HerbivorousFish parHerbivorousFish)
        {
            if (parHerbivorousFish.IsHerbivorous && _proteinContent <= 30)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        ///Метод для получения информации о корме
        /// </summary>
        /// <returns>Информация о информации о корме</returns>
        public override string GetInfo()
        {
            return $"{base.GetInfo()} , Тип корма: {FoodType}, Размер корма: {SizeClassification}, Содержание белка: {ProteinContent}";
        }


        /// <summary>
        /// Копирование объекта
        /// </summary>
        /// <param name="parFish">Рыба</param>
        public override void Copy(Fish parFish)
        {
            FishFood fishFood = (FishFood)parFish;
            this.FoodType = fishFood.FoodType;
            this.SizeClassification = fishFood.SizeClassification;
            this.ProteinContent = fishFood.ProteinContent;
            base.Copy(parFish);
        }

        /// <summary>
        /// Клонирование объекта
        /// </summary>
        /// <returns>Рыба</returns>
        public override abstract object Clone();

    }
}
