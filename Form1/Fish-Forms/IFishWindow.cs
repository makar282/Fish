using Fishes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Form1
{
    /// <summary>
    /// Общий интерфейс окна работы с Fish
    /// </summary>
    internal interface IFishWindow
    {
        /// <summary>
        /// Получение объекта с формы
        /// </summary>
        /// <returns>Объект художественной принадлежности</returns>
        Fish GetFish();

        /// <summary>
        /// Получение результата открытия диалогового окна
        /// </summary>
        /// <returns>Результат открытия диалогового окна</returns>
        bool ShowDialogWindow();
    }
}