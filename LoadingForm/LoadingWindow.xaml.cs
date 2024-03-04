using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace LoadingForm
{
  /// <summary>
  /// Interaction logic for LoadingWindow.xaml
  /// </summary>
  public partial class LoadingWindow : Window
  {
    /// <summary>
    /// Делегат функции добавления объекта
    /// </summary>
    public delegate object DelegateAddObject();

    /// <summary>
    /// Делегат отмены генерации
    /// </summary>
    public delegate void DelegateCancel();

    /// <summary>
    /// Делегат успешного окончания генерации
    /// </summary>
    public delegate void DelegateFinish(List<object> parList);

    /// <summary>
    /// Событие отмены генерации
    /// </summary>
    public event DelegateCancel OnCancel;

    /// <summary>
    /// Событие успешного окончания генерации
    /// </summary>
    public event DelegateFinish? OnFinish;

    /// <summary>
    /// Флаг успешного окончания генерации
    /// </summary>
    private bool _isFinished = false;

    /// <summary>
    /// Флаг отмены генерации
    /// </summary>
    private bool _isCanceled = false;

    /// <summary>
    /// Флаг автозакрытия окна
    /// </summary>
    private bool _isAutoClosing = false;

    /// <summary>
    /// Список генерируемых объектов
    /// </summary>
    private List<object> _generatingOjects = new();

    /// <summary>
    /// Функция добавления нового объекта
    /// </summary>
    private DelegateAddObject AddNewObjectFunction;

    /// <summary>
    /// Список генерируемых объектов
    /// </summary>
    public List<object> GeneratingObjects
    {
      get => _generatingOjects;
      set => _generatingOjects = value;
    }

    /// <summary>
    /// Флаг успешного прекращения генерации
    /// </summary>
    public bool IsFinished
    {
      get { return _isFinished; }
      set { _isFinished = value; }
    }

    /// <summary>
    /// Флаг отмены генерации
    /// </summary>
    public bool IsCanceled
    {
      get { return _isCanceled; }
    }

    /// <summary>
    /// Флаг автозакрытия окна
    /// </summary>
    public bool IsAutoClosing
    {
      get { return _isAutoClosing; }
      set { _isAutoClosing = value; }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parNumber">Количество объектов для генерации</param>
    /// <param name="parIsAutoClosing">Автозакрытие</param>
    /// <param name="parAddObjectFunction">Функция генерации объекта</param>
    public LoadingWindow(int parNumber, bool parIsAutoClosing, DelegateAddObject parAddObjectFunction)
    {
      InitializeComponent();

      AddNewObjectFunction = parAddObjectFunction;
      ProgressBar.Minimum = 0;
      ProgressBar.Maximum = parNumber;

      IsAutoClosing = parIsAutoClosing;
      Closing += Window_Closing!;
      OnCancel += ClearGeneratingObjects;

      GetGenerateThread(parNumber).Start();
      GetRefreshThread().Start();
    }

    /// <summary>
    /// Очистить сгенерированные объекты
    /// </summary>
    private void ClearGeneratingObjects()
    {
      GeneratingObjects.Clear();
    }

    /// <summary>
    /// Создание потока генерации
    /// </summary>
    /// <param name="parNumber">Количество объектов для генерации</param>
    /// <returns>Поток генерации данных</returns>
    private Thread GetGenerateThread(int parNumber)
    {
      return new Thread(() =>
      {
        for (int i = 0; i < parNumber && !this.IsCanceled && !this.IsFinished; i++)
        {
          GeneratingObjects.Add(AddNewObjectFunction());
        }
      })
      {
        IsBackground = true
      };
    }/// <summary>
     /// Создание потока обновления
     /// </summary>
     /// <returns>Поток обновления прогресса</returns>
    private Thread GetRefreshThread()
    {
      return new Thread(() =>
      {
        while (!(IsFinished || IsCanceled))
        {
          this.RefreshProgress(GeneratingObjects.Count);
        }
      })
      {
        IsBackground = true
      };
    }

    /// <summary>
    /// Обновление прогресса
    /// </summary>
    /// <param name="parNewValue">Новое значение прогресса</param>
    private void RefreshProgress(int parNewValue)
    {
      try
      {
        Dispatcher.Invoke(() =>
        {
          ProgressBar.Value = parNewValue;

          if (!IsFinished && ProgressBar.Value >= ProgressBar.Maximum - 1)
          {
            ButtonAction.Content = "Close";
            LabelGenerating.Content = "Generation completed";
            IsFinished = true;

            if (IsAutoClosing)
            {
              OnFinish?.Invoke(GeneratingObjects);
              Close();
            }
          }
        });
      }
      catch (Exception)
      {
        OnCancel?.Invoke();
      }
    }

    /// <summary>
    /// Закрытие окна генерации или отмена генерации
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param> 
    private void ButtonAction_Click(object sender, RoutedEventArgs e)
    {
      if (!_isFinished)
      {
        _isCanceled = true;
        ButtonAction.IsEnabled = false;
        OnCancel?.Invoke();
        Close();
      }
      else
      {
        OnFinish?.Invoke(GeneratingObjects);
        Close();
      }
    }

    /// <summary>
    /// Закрытие окна
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Window_Closing(object sender, CancelEventArgs e)
    {
      if (!_isFinished)
      {
        _isCanceled = true;
        ButtonAction.IsEnabled = false;
        OnCancel?.Invoke();
      }
    }
  }
}