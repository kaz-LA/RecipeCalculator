using System.Collections.Generic;
using System.Linq;

namespace RecipeCalculator.Model
{
    /// <summary>
    /// Acts as the "DataContext" for the Recipe Calculator and is the container for all the data - all ingredients and recipes
    /// </summary>
    public class RecipeCalculatorData
    {
        public RecipeCalculatorData()
        {
            Settings = new CalculatorSetting();
        }

        /// <summary>
        /// All base Ingredients by Category
        /// </summary>
        public IEnumerable<Ingredient> Ingredients { get; set; }

        /// <summary>
        /// All Recipes and their ingredients
        /// </summary>
        public IEnumerable<Recipe> Recipes { get; set; }

        public CalculatorSetting Settings { get; set; }
    }
}
