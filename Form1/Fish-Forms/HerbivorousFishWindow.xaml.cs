using Fishes;
using Form1.Helpers;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace Form1
{
    /// <summary>
    /// Логика взаимодействия для травоядными
    /// </summary>
    public partial class HerbivorousFishWindow : Window, IFishWindow
    {
        /// <summary>
        /// Объект травоядной рыбы
        /// </summary>
        private HerbivorousFish _herbivorousFish = new HerbivorousFish();

        /// <summary>
        /// Доступность элементов для ввода на форме
        /// </summary>
        private bool _isItemsEnabled = true;

        /// <summary>
        /// Объект 
        /// </summary>
        public HerbivorousFish HerbivorousFish
        {
            get => _herbivorousFish;
            set => _herbivorousFish = value;
        }

        /// <summary>
        /// Доступность элементов для ввода на форме
        /// </summary>
        public bool IsItemsEnabled
        {
            get => _isItemsEnabled;
            set => _isItemsEnabled = value;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="parHerbivorousFish"></param>
        /// <param name="parAction"></param>
        public HerbivorousFishWindow(HerbivorousFish parHerbivorousFish, FormAction parAction)
        {
            InitializeComponent();

            HerbivorousFish = new HerbivorousFish(parHerbivorousFish);
            this.DataContext = this;
            ButtonAction.Content = parAction.ToString();
            Title = parAction.ToString() + " Herbivorous Fish";

            if (parAction == FormAction.Delete)
            {
                IsItemsEnabled = false;
            }
            this.ComboBoxClass.ItemsSource = Enum.GetValues(typeof(Classes));
            this.ComboBoxOrder.ItemsSource = Enum.GetValues(typeof(Orders));
            this.ComboBoxFamily.ItemsSource = Enum.GetValues(typeof(Families));
            this.ComboBoxReproduction.ItemsSource = Enum.GetValues(typeof(Reproductions));
            this.ComboFoodType.ItemsSource = Enum.GetValues(typeof(FoodType));

        }

        /// <summary>
        /// Возврат объекта
        /// </summary>
        /// <returns></returns>
        Fish IFishWindow.GetFish()
        {
            return HerbivorousFish;
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
