using Fishes;
using Form1.Helpers;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Form1
{
    /// <summary>
    /// Логика взаимодействия для хищников
    /// </summary>
    public partial class PredatorFishWindow : Window, IFishWindow
    {
        /// <summary>
        /// Объект хищной рыбы
        /// </summary>
        private Fish _predatorFish = new PredatorFish();

        /// <summary>
        /// Доступность элементов для ввода на форме
        /// </summary>
        private bool _isItemsEnabled = true;

        /// <summary>
        /// Объект 
        /// </summary>
        public Fish PredatorFish
        {
            get => _predatorFish;
            set => _predatorFish = value;
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
        /// <param name="parPredatorFish"></param>
        /// <param name="parAction"></param>
        public PredatorFishWindow(PredatorFish parPredatorFish, FormAction parAction)
        {
            InitializeComponent();

            PredatorFish = new PredatorFish(parPredatorFish);
            this.DataContext = this;
            ButtonAction.Content = parAction.ToString();
            Title = parAction.ToString() + " Predator Fish";

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
            return PredatorFish;
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
