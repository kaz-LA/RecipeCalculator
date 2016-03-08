using System;
using System.Configuration;
using System.Windows;
using RecipeCalculator.Model;

namespace RecipeCalculator.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static RecipeCalculatorData      RecipeCalculatorData;
        public static ViewModel.MainViewModel   ViewModel;

        public static ViewModel.MainViewModel GetViewModel()
        {
            var xmlFilePath = ConfigurationManager.AppSettings["InputFile"];
            xmlFilePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, xmlFilePath);

            var reader = new Model.Data.XmlDataReader(xmlFilePath);
            RecipeCalculatorData = reader.GetData();

            var calculator = new Model.RecipeCalculator(RecipeCalculatorData);
            var result = calculator.Calculate();

            var viewModel = new ViewModel.MainViewModel()
            {
                Data = RecipeCalculatorData,
                Results = result
            };

            ViewModel = viewModel;

            return viewModel;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);                        
        }                
    }
}
