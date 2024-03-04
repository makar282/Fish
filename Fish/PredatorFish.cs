namespace Fishes
{
    ///<summary>
    ///Класс Хищные рыбы
    ///</summary>
    public class PredatorFish : FishFood
    {
        ///<summary>Хищность рыбы</summary>
        private bool _isPredator;

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public PredatorFish()
        {
        }

        ///<summary>Хищность рыбы get & set</summary>
        public bool IsPredator
        {
            get { return _isPredator; }
            set
            {
                _isPredator = value;
                NotifyPropertyChanged(nameof(IsPredator));
            }
        }

        /// <summary>
        /// Конструктор класса хищных рыб
        /// </summary>
        /// <param name="parName"></param>
        /// <param name="parSize"></param>
        /// <param name="parClass"></param>
        /// <param name="parOrder"></param>
        /// <param name="parFamily"></param>
        /// <param name="parReproduction"></param>
        /// <param name="parFoodType"></param>
        /// <param name="parProteinContent"></param>
        /// <param name="parSizeClassification"></param>
        /// <param name="parIsPredator"></param>
        public PredatorFish(string parName,
                            int parSize,
                            Classes parClass,
                            Orders parOrder,
                            Families parFamily,
                            Reproductions parReproduction,
                            FoodType parFoodType,
                            int parProteinContent,
                            int parSizeClassification,
                            bool parIsPredator) : base(parName, parSize, parClass, parOrder, parFamily,
                                parReproduction, parFoodType, parProteinContent, parSizeClassification)
        {
            IsPredator = parIsPredator;
            IsPredator = true;
        }

        /// <summary>
        /// Констуктор копирования
        /// </summary>
        /// <param name="parFish">Художественная принадлежность</param>
        public PredatorFish(Fish parFish) : base(parFish)
        {
            this.Copy(parFish);
        }

        /// <summary>
        ///Метод для получения информации о рыбе
        /// </summary>
        /// <returns>Информация о рыбе</returns>
        public override string GetInfo()
        {
            return $"{base.GetInfo()} , Хищность: {IsPredator}";
        }

        /// <summary>
        /// Копирование объекта
        /// </summary>
        /// <param name="parFish">Рыба</param>
        public override void Copy(Fish parFish)
        {
            PredatorFish predatorFish = (PredatorFish)parFish;
            this.IsPredator = predatorFish.IsPredator;
            base.Copy(parFish);
        }

        /// <summary>
        /// Клонирование объекта
        /// </summary>
        /// <returns>PredatorFish</returns>
        public override object Clone()
        {
            return new PredatorFish(this);
        }
    }
}
