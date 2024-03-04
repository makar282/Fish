using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Fishes
{
    /// <summary>
    /// Рыбы
    /// </summary>
    public abstract class Fish : INotifyPropertyChanged
    {
        /// <summary>
        /// Название
        /// </summary>
        private string _name;

        /// <summary>
        /// Длина
        /// </summary>
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

        /// <summary>
        /// Размножение
        /// </summary>
        private Reproductions _reproduction;

        /// <summary>
        /// Событие изменения свойства
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Название get&set
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
            }
        }

        /// <summary>
        /// Размер get&set
        /// </summary>
        public Reproductions Reproduction
        {
            get => _reproduction;
            set => _reproduction = value;
        }

        /// <summary>
        /// Размер get&set
        /// </summary>
        public int Size
        {
            get => _size;
            set => _size = value;
        }

        /// <summary>
        /// Класс get&set
        /// </summary>
        public Classes Class
        {
            get => _class;
            set => _class = value;
        }

        /// <summary>
        /// Отряды get&set
        /// </summary>
        public Orders Order
        {
            get => _order;
            set => _order = value;
        }

        /// <summary>
        /// Семейства get&set
        /// </summary>
        public Families Family
        {
            get => _family;
            set => _family = value;
        }

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        protected Fish()
        {
        }

        /// <summary>
        /// Уведомляет об изменении значения свойства.
        /// </summary>
        /// <param name="parPropertyName">Название свойства для изменения</param>
        protected void NotifyPropertyChanged([CallerMemberName] string parPropertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(parPropertyName));
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parName"></param>
        /// <param name="parSize"></param>
        /// <param name="parClass"></param>
        /// <param name="parOrder"></param>
        /// <param name="parFamily"></param>
        /// <param name="parReproduction"></param>
        public Fish(string parName, int parSize, Classes parClass, Orders parOrder, Families parFamily, Reproductions parReproduction)
        {
            _name = parName;
            _size = parSize;
            _class = parClass;
            _order = parOrder;
            _family = parFamily;
            _reproduction = parReproduction;
        }

        /// <summary>
        /// Констуктор копирования
        /// </summary>
        /// <param name="parFish">Художественная принадлежность</param>
        protected Fish(Fish parFish)
        {
            this.Copy(parFish);
        }

        /// <summary>
        /// Получение информации о рыбе
        /// </summary>
        /// <returns>Информация о рыбе</returns>
        public virtual string GetInfo()
        {
            return $"Название: {Name} , Класс: {Class}, Семейство: {Family}, Отряд: {Order}, Размер: {Size}, Размножение: {Order} ft long";
        }

        /// <summary>
        /// Копирование объекта
        /// </summary>
        /// <param name="parFish">Рыба</param>
        public virtual void Copy(Fish parFish)
        {
            this.Name = parFish.Name;
            this.Size = parFish.Size;
            this.Class = parFish.Class;
            this.Order = parFish.Order;
            this.Family = parFish.Family;
            this.Reproduction = parFish.Reproduction;
        }


        /// <summary>
        /// Клонирование объекта
        /// </summary>
        /// <returns>Рыба</returns>
        public abstract object Clone();
    }
}