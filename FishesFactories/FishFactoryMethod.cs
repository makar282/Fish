using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishesFactories
{
  /// <summary>
  /// Абстрактный класс для фабричного метода
  /// </summary>
  public abstract class FishFactoryMethod
  {
    /// <summary>
    /// Создание фабрики
    /// </summary>
    /// <returns>Фабрика рыб</returns>
    public abstract IFishFactory CreateFishFactory();
    }
}
