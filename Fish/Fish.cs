namespace Fish
{
    /// <summary>
    /// Рыбы
    /// </summary>
    public abstract class Fish
    {
        /// <summary>
        /// Название
        /// </summary>
        private string _name;

        /// <summary>
        /// Длина
        private int _size;

        /// <summary>
        /// Класс
        /// </summary>
        private Classes _class;

        /// <summary>
        /// Отряд
        /// </summary>
        private Orders _order;

        /// <summary>
        /// Семейство
        /// </summary>
        private Families _family;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
            }
        }

        public int Size
        {
            get => _size;
            set => _size = value;
        }

        public Classes Class
        {
            get => _class;
            set => _class = value;
        }

        public Orders Order
        {
            get => _order;
            set => _order = value;
        }

        public Families Family
        {
            get => _family;
            set => _family = value;
        }


        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parName">Название</param>
        /// <param name="parSize">Длина</param>
        /// <param name="parOrder">Отряд</param>
        /// <param name="parClass">Класс</param>
        /// <param name="parFamily">Семейство</param>

        public Fish(string parName, int parSize, Classes parClass, Orders parOrder, Families parFamily)
        {
            _name = parName;
            _size = parSize;
            _family = parFamily;
            _class = parClass;
            _order = parOrder;
        }

        /// <summary>
        /// Получение информации о рыбе
        /// </summary>
        /// <returns>Информация о рыбе</returns>
        public virtual string GetInfo()
        {
            return $"{Class}, {Family}, {Order}, {Name}, {Size} ft long";
        }
    }
}