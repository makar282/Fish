namespace Fish
{
    ///<summary>
    ///Класс Хищные рыбы
    ///</summary>
    public class FreshwaterFish : Fish
    {
        ///<summary>Морская рыба</summary>
        private bool _isSaltwaterFish;
        ///<summary>Пресноводная рыба</summary>
        private bool _isFreshwaterFish;

        ///<summary>Конструктор класса</summary>
        public FreshwaterFish(string parName,
                               int parSize,
                               Classes parClass,
                               Orders parOrder,
                               Families parFamily) : base(parName, parSize, parClass, parOrder, parFamily)
        {
            _isSaltwaterFish = false;
            _isFreshwaterFish = true;

        }

        ///<summary>
        ///Get и set методы для атрибутов
        ///</summary>
        public bool IsSaltwaterFish
        {
            get { return _isSaltwaterFish; }
            set { _isSaltwaterFish = value; }
        }

        public bool IsFreshwaterFish
        {
            get { return _isFreshwaterFish; }
            set { _isFreshwaterFish = value; }
        }

        ///<summary>
        ///Метод для получения информации о рыбе<
        ////summary>
        public string GetFishInfo()
        {
            return "Название: " + Name + ", Морская: " + _isSaltwaterFish + ", Пресноводная: " + _isFreshwaterFish;
        }
    }
}