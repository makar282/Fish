namespace Fishes
{
    ///<summary>
    ///Класс вода для рыбы
    ///</summary>
    public abstract class WaterForFish : Fish
    {
        ///<summary>
        ///Морская рыба
        ///</summary>
        private bool _isSaltwaterFish;
        ///<summary>
        ///Пресноводная рыба
        ///</summary>
        private bool _isFreshwaterFish;
        ///<summary>
        ///Температура воды, в которой обитает рыба.
        ///</summary>
        private double _temperature;

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public WaterForFish()
        {
        }

        /// <summary>
        /// Конструктор класса WaterForFish
        /// </summary>
        /// <param name="parName"></param>
        /// <param name="parSize"></param>
        /// <param name="parTemperature"></param>
        /// <param name="parClass"></param>
        /// <param name="parOrder"></param>
        /// <param name="parFamily"></param>
        /// <param name="parReproduction"></param>
        /// <param name="parIsSaltwaterFish"></param>
        /// <param name="parIsFreshwaterFish"></param>
        public WaterForFish(string parName,
                            int parSize,
                            double parTemperature,
                            Classes parClass,
                            Orders parOrder,
                            Families parFamily,
                            Reproductions parReproduction,
                            bool parIsSaltwaterFish,
                            bool parIsFreshwaterFish) : base(parName, parSize, parClass, parOrder, parFamily, parReproduction)
        {
            _isSaltwaterFish = parIsSaltwaterFish;
            _isFreshwaterFish = parIsFreshwaterFish;
            _temperature = parTemperature;
        }

        /// <summary>
        /// Констуктор копирования
        /// </summary>
        /// <param name="parFish">Художественная принадлежность</param>
        public WaterForFish(Fish parFish) : base(parFish)
        {
            this.Copy(parFish);
        }

        ///<summary>
        ///Get и set методы для атрибута Морская рыба
        ///</summary>
        public bool IsSaltwaterFish
        {
            get { return _isSaltwaterFish; }
            set { _isSaltwaterFish = value; }
        }

        ///<summary>
        /// Температура воды, в которой обитает рыба.
        ///</summary>
        public double Temperature
        {
            get { return _temperature; }
            set { _temperature = value; }
        }

        ///<summary>
        ///Get и set методы для атрибута пресноводная рыба
        ///</summary>
        public bool IsFreshwaterFish
        {
            get { return _isFreshwaterFish; }
            set { _isFreshwaterFish = value; }
        }


        /// <summary>
        ///Метод для получения информации о рыбе
        /// </summary>
        /// <returns>Информация о рыбе</returns>
        public override string GetInfo()
        {
            return $"{base.GetInfo()} , Пресноводная: {IsSaltwaterFish}, Морская: {IsFreshwaterFish}, Температура: {Temperature}";
        }

        /// <summary>
        /// Копирование объекта
        /// </summary>
        /// <param name="parFish">Рыба</param>
        public override void Copy(Fish parFish)
        {
            WaterForFish waterForFish = (WaterForFish)parFish;
            this.IsSaltwaterFish = waterForFish.IsSaltwaterFish;
            this.IsFreshwaterFish = waterForFish.IsFreshwaterFish;
            this.Temperature = waterForFish.Temperature;

            base.Copy(parFish);
        }

        /// <summary>
        /// Клонирование объекта
        /// </summary>
        /// <returns>Рыба</returns>
        public override abstract object Clone();

    }
}