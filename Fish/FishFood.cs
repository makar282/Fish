using System;
using System.Formats.Asn1;

namespace Fish
{
    /// <summary>
    /// Корм для рыб
    /// </summary>
    public class FishFood : AquariumFish
    {
        /// <summary>
        /// Тип корма
        /// </summary>
        private FoodType _foodType;
        /// <summary>
        /// Размер корма
        /// </summary>
        private int _sizeClassification;
        /// <summary>
        /// Содержание белка
        /// </summary>
        private int _proteinContent;

        /// <summary>
        /// Конструктор класса FishFood
        /// </summary>
        public FishFood(                        int parSize,
                        int parProteinContent,
                        string parName,
                        int parSizeClassification,
                        Classes parClass,
                        Orders parOrder,
                        Families parFamily,
                        PredatorFish parPredatorFish,
                        Reproduction parReproduction,
                        FreshwaterFish parFreshwaterFish,
                        FoodType foodType) : base(parName, parSize, parClass, parOrder, parFamily, parReproduction)
        {
            _foodType = foodType;
            _sizeClassification = parSizeClassification;
            _proteinContent = parProteinContent;
        }

        /// <summary>
        /// Get и Set методы для атрибутов класса FishFood
        /// </summary>
        public FoodType FoodType
        {
            get { return _foodType; }
            set { _foodType = value; }
        }

        public int SizeClassification
        {
            get { return _sizeClassification; }
            set { _sizeClassification = value; }
        }

        public int ProteinContent
        {
            get { return _proteinContent; }
            set { _proteinContent = value; }
        }

        /// <summary>
        /// Метод для проверки, нужен ли корм с содержанием белка минимум 50%
        /// </summary>
        /// <returns></returns>
        public bool NeedsHighProteinFood(PredatorFish predatorFish)
        {
            if (predatorFish.IsPredator && _proteinContent >= 50)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Метод для проверки, нужен ли корм с низким содержанием белка и не является ли он Bloodworm
        /// </summary>
        /// <returns></returns>
        public bool NeedsLowProteinFood(HerbivorousFish herbivorousFish)
        {
            if (herbivorousFish.IsHerbivorous && _proteinContent <= 30)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Метод для получения информации о корме
        /// </summary>
        /// <returns></returns>
        public string GetFoodInfo()
        {
            return $"Тип корма: {_foodType}, Классификация по размеру: {_sizeClassification}, Содержание белка: {_proteinContent}%";
        }
    }
}
