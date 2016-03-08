using RecipeCalculator.UI.ViewModel;
using System.Windows;
using System;

namespace RecipeCalculator.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            var results = App.GetViewModel();
            this.DataContext = results;
        }

        public MainViewModel Model
        {
            get { return App.ViewModel; }
        }
    }
}
