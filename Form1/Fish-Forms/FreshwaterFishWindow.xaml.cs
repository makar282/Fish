using Fishes;
using Form1.Helpers;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Form1
{
    /// <summary>
    /// Логика взаимодействия для FreshwaterFishWindow.xaml
    /// </summary>
    public partial class FreshwaterFishWindow : Window, IFishWindow
    {
        /// <summary>
        /// Объект пресноводной рыбы
        /// </summary>
        private FreshwaterFish _freshwaterFish = new FreshwaterFish();

        /// <summary>
        /// Доступность элементов для ввода на форме
        /// </summary>
        private bool _isItemsEnabled = true;

        /// <summary>
        /// Объект 
        /// </summary>
        public FreshwaterFish FreshwaterFish
        {
            get => _freshwaterFish;
            set => _freshwaterFish = value;
        }

        /// <summary>
        /// Доступность элементов для ввода на форме
        /// </summary>
        public bool IsItemsEnabled
        {
            get => _isItemsEnabled;
            set => _isItemsEnabled = value;
        }

        ///<

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parFreshwaterFish"></param>
        /// <param name="parAction"></param>
        public FreshwaterFishWindow(FreshwaterFish parFreshwaterFish, FormAction parAction)
        {
            InitializeComponent();

            FreshwaterFish = new FreshwaterFish(parFreshwaterFish);
            this.DataContext = this;
            ButtonAction.Content = parAction.ToString();
            Title = parAction.ToString() + " Freshwater Fish";

            if (parAction == FormAction.Delete)
            {
                IsItemsEnabled = false;
            }
            this.ComboBoxClass.ItemsSource = Enum.GetValues(typeof(Classes));
            this.ComboBoxOrder.ItemsSource = Enum.GetValues(typeof(Orders));
            this.ComboBoxFamily.ItemsSource = Enum.GetValues(typeof(Families));
            this.ComboBoxReproduction.ItemsSource = Enum.GetValues(typeof(Reproductions));
        }

        /// <summary>
        /// Возврат объекта
        /// </summary>
        /// <returns></returns>
        Fish IFishWindow.GetFish()
        {
            return FreshwaterFish;
        }


        /// <summary>
        /// Получение результата открытия диалогового окна
        /// </summary>
        /// <returns></returns>
        bool IFishWindow.ShowDialogWindow()
        {
            return this.ShowDialog() == true;
        }


        /// <summary>
        /// Проверка на вещественное число
        /// </summary>
        /// <param name="parSender"></param>
        /// <param name="parE"></param>
        private void PreviewTextFloatInput(object parSender, TextCompositionEventArgs parE)
        {
            if (InputValidator.IsFloatNumber(parE.Text) && !(parE.Text == "." && ((TextBox)parSender).Text.Contains(parE.Text)))
            {
                parE.Handled = false;
            }
            else
            {
                parE.Handled = true;
            }
        }

        /// <summary>
        /// Обработчик подтверждения выполнения операции
        /// </summary>
        /// <param name="parSender"></param>
        /// <param name="parE"></param>
        private void ButtonAction_Click(object parSender, RoutedEventArgs parE)
        {
            this.DialogResult = true;
            this.Close();
        }

        /// <summary>
        /// Проверка на целое число
        /// </summary>
        /// <param name="parSender"></param>
        /// <param name="parE"></param>
        private void PreviewTextIntInput(object parSender, TextCompositionEventArgs parE)
        {
            parE.Handled = InputValidator.IsIntNumber(parE.Text);
        }
    }
}