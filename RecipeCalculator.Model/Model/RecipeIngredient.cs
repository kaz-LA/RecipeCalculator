
namespace RecipeCalculator.Model
{
    /// <summary>
    /// Represents an Ingredient that's associated with a given Recipe
    /// </summary>
    public class RecipeIngredient
    {
        /// <summary>
        /// the name of the base Ingredient
        /// </summary>
        public string IngredientName { get; set; }

        public decimal Quantity { get; set; }

        public override string ToString()
        {
            return string.Format("{1} {0}", IngredientName, Quantity);
        }
    }
}
