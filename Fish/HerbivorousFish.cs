namespace Fishes
{
    ///<summary>
    ///Класс Травоядные рыбы
    ///</summary>
    public class HerbivorousFish : FishFood
    {
        ///<summary>Травоядность рыбы</summary>
        private readonly bool _isHerbivorous;

        ///<summary>Травоядность get & set</summary>
        public bool IsHerbivorous
        {
            get { return _isHerbivorous; }
            set
            {
                NotifyPropertyChanged(nameof(IsHerbivorous));
            }
        }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public HerbivorousFish()
        {
        }

        /// <summary>
        /// Конструктор класса травоядных рыб
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
        /// <param name="parIsHerbivorous"></param>
        public HerbivorousFish(string parName,
                               int parSize,
                               Classes parClass,
                               Orders parOrder,
                               Families parFamily,
                               Reproductions parReproduction,
                               FoodType parFoodType,
                               int parProteinContent,
                               int parSizeClassification,
                               bool parIsHerbivorous) : base(parName, parSize, parClass, parOrder, parFamily,
                        parReproduction, parFoodType, parProteinContent, parSizeClassification)
        {
            _isHerbivorous = parIsHerbivorous;
            _isHerbivorous = true;
        }

        /// <summary>
        /// Констуктор копирования
        /// </summary>
        /// <param name="parFish">Художественная принадлежность</param>
        public HerbivorousFish(Fish parFish) : base(parFish)
        {
            this.Copy(parFish);
        }

        /// <summary>
        ///Метод для получения информации о рыбе
        /// </summary>
        /// <returns>Информация о рыбе</returns>
        public override string GetInfo()
        {
            return $"{base.GetInfo()} , Травоядность: {IsHerbivorous} ";
        }

        /// <summary>
        /// Копирование объекта
        /// </summary>
        /// <param name="parFish">Рыба</param>
        public override void Copy(Fish parFish)
        {
            HerbivorousFish herbivorousFish = (HerbivorousFish)parFish;
            this.IsHerbivorous = herbivorousFish.IsHerbivorous;
            base.Copy(parFish);
        }

        /// <summary>
        /// Клонирование объекта
        /// </summary>
        /// <returns>HerbivorousFish</returns>
        public override object Clone()
        {
            return new HerbivorousFish(this);
        }

    }
}
