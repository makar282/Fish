namespace Fish
{
    ///<summary>
    ///Класс Хищные рыбы
    ///</summary>
    public class PredatorFish : Fish
    {
        ///<summary>Хищность рыбы</summary>
        private bool _isPredator;
        ///<summary>Травоядность рыбы</summary>
        private bool _isHerbivorous;

        public bool IsPredator
        {
            get { return _isPredator; }
            set { _isPredator = value; }
        }

        public bool IsHerbivorous
        {
            get { return _isHerbivorous; }
            set { _isHerbivorous = value; }
        }

        ///<summary>Конструктор класса</summary>
        public PredatorFish(string parName,
                            int parSize,
                            Classes parClass,
                            Orders parOrder,
                            Families parFamily) : base(parName, parSize, parClass, parOrder, parFamily)
        {
            _isPredator = true;
            _isHerbivorous = false;
        }

        ///<summary>
        ///Метод для получения информации о рыбе
        ///<summary>
        public string GetFishInfo()
        {
            return "Название: " + Name + ", Хищность: " + _isPredator + ", Травоядность: " + _isHerbivorous;
        }
    }
}
