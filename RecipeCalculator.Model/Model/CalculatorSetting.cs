
namespace RecipeCalculator.Model
{
    /// <summary>
    /// RecipeCalculator Settings - such as percentages etc
    /// </summary>
    public class CalculatorSetting
    {
        public decimal TaxPercentage { get; set; }
        public decimal TaxRounding { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountRounding { get; set; }
    }
}
