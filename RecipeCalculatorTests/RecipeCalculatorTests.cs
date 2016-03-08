using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipeCalculator.Model;

namespace RecipeCalculator.Tests
{
    [TestClass]
    public class RecipeCalculatorTests
    {
        [TestMethod]
        [Description("Verifies that the RecipeCalculator throws the RecipeCalculatorException when no data/input is specified")]
        [TestCategory("RecipeCalculator.RecipeCalculatorTests")]
        [TestProperty("Author", "Kaz")]
        [ExpectedException(typeof(RecipeCalculatorException))]
        public void RecipeCalculatorThrowsExceptionWhenDataNotProvided()
        {
            var result = new RecipeCalculator.Model.RecipeCalculator(null).Calculate();
        }

        [TestMethod]
        [Description("Verifies that the RecipeCalculator throws the RecipeCalculatorException when no/empty data/input is specified")]
        [TestCategory("RecipeCalculator.RecipeCalculatorTests")]
        [TestProperty("Author", "Kaz")]
        [ExpectedException(typeof(RecipeCalculatorException))]
        public void RecipeCalculatorThrowsExceptionWhenIngredientsNotProvided()
        {
            var data = new RecipeCalculatorData()
            {

            };

            var result = new RecipeCalculator.Model.RecipeCalculator(data).Calculate();
        }

        [TestMethod]
        [Description("Verifies that the RecipeCalculator throws the RecipeCalculatorException when an ingredient referenced in a recipe couln't be found")]
        [TestCategory("RecipeCalculator.RecipeCalculatorTests")]
        [TestProperty("Author", "Kaz")]
        [ExpectedException(typeof(RecipeCalculatorException))]
        public void RecipeCalculatorThrowsExceptionWhenUnknownIngredientUsed()
        {
            var data = new RecipeCalculatorData()
            {
                Ingredients = new List<Ingredient>()
                {
                    new Ingredient("chicken breast", "Meat/poultry", 2.19M),
                    new Ingredient("olive oil", "Pantry", 1.92M).Organic(true)                    
                },
                Recipes = new List<Recipe>()
                {
                    new Recipe("Test Recipe")
                        .Ingredient("garlic", 1M)
                        .Ingredient("chicken breast", 4M)
                        .Ingredient("olive oil", 0.5M)
                        .Ingredient("vinegar", 0.5M)
                },
            };

            var result = new RecipeCalculator.Model.RecipeCalculator(data).Calculate();
        }

        [TestMethod]
        [Description("Verifies that the RecipeCalculator accurately and successfully computes the Tax, Discount and TotalCost")]
        [TestCategory("RecipeCalculator.RecipeCalculatorTests")]
        [TestProperty("Author", "Kaz")]
        public void RecipeCalculatorCalculatesRecipeTotals()
        {
            var data = new RecipeCalculatorData()
            {
                Ingredients = new List<Ingredient>()
                {
                    new Ingredient("garlic", "Produce", 0.67M).Organic(true),
                    new Ingredient("chicken breast", "Meat/poultry", 2.19M),
                    new Ingredient("olive oil", "Pantry", 1.92M).Organic(true),
                    new Ingredient("vinegar", "Pantry", 1.26M),
                },

                Recipes = new List<Recipe>()
                {
                    new Recipe("Test Recipe")
                        .Ingredient("garlic", 1M)
                        .Ingredient("chicken breast", 4M)
                        .Ingredient("olive oil", 0.5M)
                        .Ingredient("vinegar", 0.5M)
                },

                Settings = new CalculatorSetting() { DiscountPercentage = 5.0M, TaxPercentage = 8.6M, DiscountRounding = 1 /*cent*/, TaxRounding = 7 /*seven cents*/ }
            };

            var result = new RecipeCalculator.Model.RecipeCalculator(data).Calculate();

            Assert.IsTrue(result != null && result.Any(), "RecipeCalculator failed!");

            // Expected Tax = $0.91, Discount = ($0.09), Total = $11.84
            var calc = result.First();

            Assert.IsTrue(calc.Tax == 0.91M, "Tax calculation failed!");
            Assert.IsTrue(calc.Discount == 0.09M, "Discount calculation failed!");
            Assert.IsTrue(calc.TotalCost == 11.84M, "Total calculation failed!");
        }
    }
}
