using Fishes;
using FishesFactories;
using Form1.Helpers;
using LoadingForm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace Form1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Количество генерируемых записей
        /// </summary>
        private const int TEST_DATA_SIZE = 4;

        /// <summary>
        /// Коллекция фабрик для создания рыб
        /// </summary>
        private ObservableCollection<IFishFactory> _fishesFactories = new ObservableCollection<IFishFactory>();


        /// <summary>
        /// Коллекция рыб
        /// </summary>
        private ObservableCollection<Fish> _fishes = new ObservableCollection<Fish>();

        /// <summary>
        /// Список фабричных методов для создания фабрик рыб
        /// </summary>
        private List<FishFactoryMethod> _fishesFactoryMethods = new List<FishFactoryMethod>();


        /// <summary>
        /// Коллекция рыб
        /// </summary>
        public ObservableCollection<Fish> Fishes
        {
            get => _fishes;
            set => _fishes = value;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            InitArtSupplyFactories();
            fishesDataGrid.ItemsSource = Fishes;
            ComboBoxFactory.ItemsSource = _fishesFactories;
        }


        /// <summary>
        /// Инициализация фабрик для создания рыб
        /// </summary>
        private void InitArtSupplyFactories()
        {
            _fishesFactoryMethods = new List<FishFactoryMethod>()
      {
        InitPrototypeFactoryMethod(), new HerbivorousFishAndSaltwaterFishFactoryMethod()
      };

            _fishesFactoryMethods.ForEach(factoryMethod =>
              _fishesFactories.Add(factoryMethod.CreateFishFactory())
            );
        }

        /// <summary>
        /// Инициализация фабричного метода прототипов
        /// </summary>
        /// <returns>Фабричный метод прототипов</returns>
        private FishFactoryMethod InitPrototypeFactoryMethod()
        {
            return new FishPrototypeFactoryMethod(InitWaterForFishPrototype(), InitFishFoodPrototype());
        }

        /// <summary>
        /// Инициализация прототипа Вода для рыб
        /// </summary>
        /// <returns>Вода для рыб</returns>
        private WaterForFish InitWaterForFishPrototype()
        {
            FreshwaterFishWindow window = new(new FreshwaterFish(), FormAction.Add);

            WaterForFish waterForFishPrototype = new FreshwaterFish();

            bool isClosed = window.ShowDialog() == true;

            if (isClosed)
            {
                waterForFishPrototype = window.FreshwaterFish;
            }

            return waterForFishPrototype;
        }

        /// <summary>
        /// Инициализация прототипа Корм для рыб
        /// </summary>
        /// <returns>Корм для рыб</returns>
        private FishFood InitFishFoodPrototype()
        {
            PredatorFishWindow window = new(new PredatorFish(), FormAction.Add);

            FishFood fishFoodPrototype = new PredatorFish();

            bool isClosed = window.ShowDialog() == true;

            if (isClosed)
            {
                fishFoodPrototype = (FishFood)window.PredatorFish;
            }

            return fishFoodPrototype;
        }


        /// <summary>
        /// Обработчик генерации тестовых данных
        /// </summary>
        /// <param name="parSender"></param>
        /// <param name="parE"></param>
        private void ButtonGenerateTestData_Click(object parSender, RoutedEventArgs parE)
        {
            int number = int.Parse(TextBoxDataNumber.Text);
            bool closeOnComplete = CheckBoxCloseOnComplete.IsChecked.Value;

            LoadingWindow loadingWindow = new LoadingWindow(number, closeOnComplete, FishGenerator.GenerateTestFish);
            loadingWindow.OnFinish += SaveFishes;

            loadingWindow.Show();
        }

        /// <summary>
        /// Добавление сгенерированных данных
        /// </summary>
        /// <param name="parList">Сгенерированные данные</param>
        private void SaveFishes(List<object> parList)
        {
            parList.ForEach(parItem => Fishes.Add(item: (Fish)parItem));
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

        /// <summary>
        /// Обработчик удаления объекта
        /// </summary>
        /// <param name="parSender"></param>
        /// <param name="parE"></param>
        private void ButtonDelete_Click(object parSender, RoutedEventArgs parE)
        {
            Fish selectedFish = (Fish)fishesDataGrid.SelectedItem;

            if (selectedFish == null)
            {
                return;
            }

            IFishWindow window = GetWindow(selectedFish, FormAction.Delete);

            bool isClosed = window.ShowDialogWindow();

            if (isClosed)
            {
                Fishes.RemoveAt(fishesDataGrid.SelectedIndex);
            }
        }

        /// <summary>
        /// Обработчик редактирования объекта
        /// </summary>
        /// <param name="parSender"></param>
        /// <param name="parE"></param>
        private void ButtonEdit_Click(object parSender, RoutedEventArgs parE)
        {
            Fish selectedFish = (Fish)fishesDataGrid.SelectedItem;

            if (selectedFish == null)
            {
                return;
            }

            IFishWindow window = GetWindow(selectedFish, FormAction.Edit);

            bool isClosed = window.ShowDialogWindow();

            if (isClosed)
            {
                selectedFish.Copy(window.GetFish());
                fishesDataGrid.Items.Refresh();

            }
        }


        /// <summary>
        /// Обработчик добавления воды для рыб
        /// </summary>
        /// <param name="parSender"></param>
        /// <param name="parE"></param>
        private void ButtonAddWaterForFish_Click(object parSender, RoutedEventArgs parE)
        {
            WaterForFish writingSubject = ((IFishFactory)ComboBoxFactory.SelectedItem).CreateWaterForFish();

            IFishWindow window = GetWindow(writingSubject, FormAction.Add);

            bool isClosed = window.ShowDialogWindow();

            if (isClosed)
            {
                Fishes.Add(window.GetFish());
            }
        }

        /// <summary>
        /// Обработчик добавления корма для рыб
        /// </summary>
        /// <param name="parSender"></param>
        /// <param name="parE"></param>
        private void ButtonAddFishFood_Click(object parSender, RoutedEventArgs parE)
        {
            FishFood drawingSurface = ((IFishFactory)ComboBoxFactory.SelectedItem).CreateFishFood();

            IFishWindow window = GetWindow(drawingSurface, FormAction.Add);

            bool isClosed = window.ShowDialogWindow();

            if (isClosed)
            {
                Fishes.Add(window.GetFish());
            }
        }

        /// <summary>
        /// Получение окна по типу объекта
        /// </summary>
        /// <param name="parFish">Рыба</param>
        /// <param name="parAction">Тип действия</param>
        /// <returns>Окно рыб</returns>
        private IFishWindow GetWindow(Fish parFish, FormAction parAction)
        {
            if (parFish is PredatorFish)
            {
                return new PredatorFishWindow((PredatorFish)parFish, parAction);
            }
            else if (parFish is HerbivorousFish)
            {
                return new HerbivorousFishWindow((HerbivorousFish)parFish, parAction);
            }
            else if (parFish is FreshwaterFish)
            {
                return new FreshwaterFishWindow((FreshwaterFish)parFish, parAction);
            }
            else
            {
                return new SaltwaterFishWindow((SaltwaterFish)parFish, parAction);
            }
        }
    }
}