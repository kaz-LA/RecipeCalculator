
namespace RecipeCalculator.Model
{
    /// <summary>
    /// Represents an Ingredient
    /// </summary>
    public class Ingredient
    {
        public Ingredient() { }

        public Ingredient(string name, string category, decimal price)
        {
            this.Name = name;
            this.Category = category;
            this.Price = price;
        }

        public Ingredient Organic(bool organic)
        {
            this.IsOrganic = organic;
            return this;
        }

        /// <summary>
        /// Name of ingredient
        /// </summary>
        public string Name { get; set; }

        public string Category { get; set; }
        public string Unit { get; set; }

        public bool IsOrganic { get; set; }

        public decimal Price { get; set; }

        public override string ToString()
        {
            return string.Format("{0} of {1} ${2}", Unit, Name, Price);
        }
    }
}
