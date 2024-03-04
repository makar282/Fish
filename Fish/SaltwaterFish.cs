namespace Fishes
{
    /// <summary>
    /// Класс SaltwaterFish представляет рыб морской воды.
    /// </summary>
    public class SaltwaterFish : WaterForFish
    {
        ///<summary>
        /// Соленость воды
        ///</summary>
        private double _salinity;

        ///<summary>
        /// Плотность воды
        ///</summary>
        private double _density;


        ///<summary>
        /// Соленость
        ///</summary>
        public double Salinity
        {
            get { return _salinity; }
            set { _salinity = value; }
        }

        ///<summary>
        /// Плотность
        ///</summary>
        public double Density
        {
            get { return _density; }
            set { _density = value; }
        }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public SaltwaterFish()
        {
        }

        /// <summary>
        /// Конструктор SaltwaterFish
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
        /// <param name="parSalinity"></param>
        /// <param name="parDensity"></param>
        public SaltwaterFish(string parName,
                            int parSize,
                            double parTemperature,
                            Classes parClass,
                            Orders parOrder,
                            Families parFamily,
                            Reproductions parReproduction,
                            bool parIsSaltwaterFish,
                            bool parIsFreshwaterFish,
                            double parSalinity,
                            double parDensity) : base(parName, parSize, parTemperature, parClass, parOrder, parFamily, parReproduction, parIsSaltwaterFish, parIsFreshwaterFish)
        {
            _salinity = parSalinity;
            _density = parDensity;
        }

        /// <summary>
        /// Констуктор копирования
        /// </summary>
        /// <param name="parFish">Художественная принадлежность</param>
        public SaltwaterFish(Fish parFish) : base(parFish)
        {
            this.Copy(parFish);
        }

        /// <summary>
        ///Метод для получения информации о воде
        /// </summary>
        /// <returns>Информация о воде</returns>
        public override string GetInfo()
        {
            return $"{base.GetInfo()} , Соленость: {Salinity}, Плотность: {Density}";
        }

        /// <summary>
        /// Копирование объекта
        /// </summary>
        /// <param name="parFish">Рыба</param>
        public override void Copy(Fish parFish)
        {
            SaltwaterFish saltwaterFish = (SaltwaterFish)parFish;
            this.Salinity = saltwaterFish.Salinity;
            this.Density = saltwaterFish.Density;
            base.Copy(parFish);
        }

        /// <summary>
        /// Клонирование объекта
        /// </summary>
        /// <returns>SaltwaterFish</returns>
        public override object Clone()
        {
            return new SaltwaterFish(this);
        }

    }
}
