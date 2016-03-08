using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeCalculator.Model
{
    /// <summary>
    /// Calculates the Tax, Discount and total prices of Recipes
    /// </summary>
    public class RecipeCalculator
    {
        private RecipeCalculatorData _data;

        public RecipeCalculator(RecipeCalculatorData data)
        {
            _data = data;
        }

        /// <summary>
        /// Calculates the Tax, Discount and total prices of Recipes
        /// </summary>
        public IEnumerable<RecipeResult> Calculate()
        {
            if (null == _data)
            {
                throw new RecipeCalculatorException("RecipeCalculatorData must be specified.");
            }

            if (_data.Ingredients == null || !_data.Ingredients.Any())
            {
                throw new RecipeCalculatorException("List of Ingredients not found.");
            }

            if (_data.Recipes == null || !_data.Recipes.Any())
            {
                throw new RecipeCalculatorException("List of Recipes not found.");
            }

            /*
            compute the following for each recipe:

             - Sales Tax(% 8.6 of the total price rounded up to the nearest 7 cents, applies to everything except produce)

            - Wellness Discount(-% 5 of the total price rounded up to the nearest cent, applies only to organic items)

            - Total Cost(should include the sales tax and the discount)
            */

            var allIngredients = _data.Ingredients.ToDictionary(ing => ing.Name);
            var results = new List<RecipeResult>();
            var settings = _data.Settings;
            var taxprcnt = settings.TaxPercentage / 100.0M;
            var dscnt = settings.DiscountPercentage / 100.0M;

            foreach (var rcp in _data.Recipes)
            {
                var result = new RecipeResult() { RecipeName = rcp.Name };

                foreach (var rcpingrdnt in rcp.Ingredients)
                {
                    if(!allIngredients.ContainsKey(rcpingrdnt.IngredientName))
                    {
                        throw new RecipeCalculatorException(string.Format("Ingredient '{0}' not found in the list of ingredients.", rcpingrdnt.IngredientName));
                    }

                    var ingrdnt = allIngredients[rcpingrdnt.IngredientName];
                    decimal price = rcpingrdnt.Quantity * ingrdnt.Price;
                    
                    if (!IsProduce(ingrdnt))
                    {
                        result.Tax += price * taxprcnt;
                    }

                    if (ingrdnt.IsOrganic)
                    {
                        result.Discount += price * dscnt;
                    }

                    result.RecipeCost += price;
                }

                result.Tax = RoundToNearestCents(result.Tax, settings.TaxRounding);
                result.Discount = RoundToNearestCents(result.Discount, settings.DiscountRounding);
                result.RecipeCost = RoundToNearestCents(result.RecipeCost, 1M);

                results.Add(result);
            }

            return results;
        }

        static decimal RoundToNearestCents(decimal value, decimal nearestCents)
        {
            if (nearestCents == decimal.Zero)
            {
                return value;
            }

            nearestCents = (nearestCents / 100.0M);

            return Math.Ceiling(value / nearestCents) * nearestCents;
        }
        
        private bool IsProduce(Ingredient ingredient)
        {
            return ingredient.Category != null &&
                   ingredient.Category.Equals("produce", StringComparison.CurrentCultureIgnoreCase);
        }

        public RecipeCalculatorData Data
        {
            get { return _data; }
        }
    }
}
