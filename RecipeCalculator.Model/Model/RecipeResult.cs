
namespace RecipeCalculator.Model
{
    /// <summary>
    /// Represents Recipe Calculation Result
    /// </summary>
    public class RecipeResult
    {
        public string RecipeName { get; set; }

        public decimal Tax { get; set; }

        public decimal Discount { get; set; }

        /// <summary>
        /// Cost before Tax and discounts
        /// </summary>
        public decimal RecipeCost { get; set; }

        public decimal TotalCost
        {
            get { return RecipeCost - Discount + Tax; }
        }
    }
}
