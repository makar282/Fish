namespace Fishes
{
    /// <summary>
    /// Класс FreshwaterFish представляет рыб пресной воды.
    /// </summary>
    public class FreshwaterFish : WaterForFish
    {
        ///<summary>
        /// pH воды, в которой обитает рыба.
        ///</summary>
        private double _disambiguation;
        ///<summary>
        /// Жесткость воды, в которой обитает рыба.
        ///</summary>
        private double _hardness;



        ///<summary>
        /// pH воды, в которой обитает рыба.
        ///</summary>
        public double Salinity
        {
            get { return _disambiguation; }
            set { _disambiguation = value; }
        }

        ///<summary>
        /// Жесткость воды, в которой обитает рыба.
        ///</summary>
        public double Hardness
        {
            get { return _hardness; }
            set { _hardness = value; }
        }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public FreshwaterFish()
        {
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parDisambiguation"></param>
        /// <param name="parHardness"></param>
        /// <param name="parName"></param>
        /// <param name="parIsSaltwaterFish"></param>
        /// <param name="parIsFreshwaterFish"></param>
        /// <param name="parSize"></param>
        /// <param name="parTemperature"></param>
        /// <param name="parClass"></param>
        /// <param name="parOrder"></param>
        /// <param name="parFamily"></param>
        /// <param name="parReproduction"></param>
        public FreshwaterFish(string parName,
                              int parSize,
                              double parTemperature,
                              Classes parClass,
                              Orders parOrder,
                              Families parFamily,
                              Reproductions parReproduction,
                              bool parIsSaltwaterFish,
                              bool parIsFreshwaterFish,
                              double parDisambiguation,
                              double parHardness) : base(parName, parSize, parTemperature, parClass, parOrder, parFamily, parReproduction, parIsSaltwaterFish, parIsFreshwaterFish)
        {
            _disambiguation = parDisambiguation;
            _hardness = parHardness;
        }

        /// <summary>
        /// Констуктор копирования
        /// </summary>
        /// <param name="parFish">Художественная принадлежность</param>
        public FreshwaterFish(Fish parFish) : base(parFish)
        {
            this.Copy(parFish);
        }

        /// <summary>
        ///Метод для получения информации о воде
        /// </summary>
        /// <returns>Информация о воде</returns>
        public override string GetInfo()
        {
            return $"{base.GetInfo()} , Кислотность: {Salinity}, Жесткость: {Hardness}";
        }

        /// <summary>
        /// Копирование объекта
        /// </summary>
        /// <param name="parFish">Рыба</param>
        public override void Copy(Fish parFish)
        {
            FreshwaterFish freshwaterFish = (FreshwaterFish)parFish;
            this.Salinity = freshwaterFish.Salinity;
            this.Hardness = freshwaterFish.Hardness;
            base.Copy(parFish);
        }

        /// <summary>
        /// Клонирование объекта
        /// </summary>
        /// <returns>Пресноводная рабы</returns>
        public override object Clone()
        {
            return new FreshwaterFish(this);
        }

    }
}
