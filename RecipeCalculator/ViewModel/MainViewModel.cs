using RecipeCalculator.Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace RecipeCalculator.UI.ViewModel
{
    public class MainViewModel : NotificationObject
    {
        private IEnumerable<RecipeResult> _results;
        private RecipeCalculatorData        _data;

        public MainViewModel()
        {
            CloseCommand = new Command((arg) => App.Current.Shutdown());
            RefreshCommand = new Command((arg) => this.Refresh());
        }

        public void Refresh()
        {
            OnPropertyChanged("Results");
            OnPropertyChanged("AllIngredients");
            OnPropertyChanged("Recipes");
        }

        public IEnumerable<RecipeResult> Results
        {
            get { return _results; }
            set
            {
                _results = value;
                OnPropertyChanged();
            }
        }

        public RecipeCalculatorData Data
        {
            get { return _data; }
            set
            {
                _data = value;                
                OnPropertyChanged();
                AllIngredients = null;
                Recipes = null;
            }
        }

        public IEnumerable<Ingredient> AllIngredients
        {
            get { return _data != null ? _data.Ingredients.ToList() : null; }
            set
            {
                OnPropertyChanged();
            }
        }

        public IEnumerable<Recipe> Recipes
        {
            get { return _data != null ? _data.Recipes.ToList() : null; }
            set
            {
                OnPropertyChanged();
            }
        }

        public ICommand CloseCommand { get; set; }

        public ICommand RefreshCommand { get; set; }
    }    
}
