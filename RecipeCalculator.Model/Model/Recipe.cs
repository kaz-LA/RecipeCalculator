
using System.Collections.Generic;
using System.Linq;
using System;

namespace RecipeCalculator.Model
{
    /// <summary>
    /// Represents a Recipe that has a unique name and ingredients associated with the Recipe
    /// </summary>
    public class Recipe
    {
        public Recipe() { }

        public Recipe(string name)
        {
            this.Name = name;
            Ingredients = new List<RecipeIngredient>();
        }
        
        /// <summary>
        /// Adds an ingredient
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public Recipe Ingredient(string ingredientName, decimal quantity)
        {
            if(Ingredients == null)
            {
                Ingredients = new List<RecipeIngredient>();
            }

            Ingredients.Add(new RecipeIngredient() { IngredientName = ingredientName, Quantity = quantity });

            return this;
        }

        /// <summary>
        /// name of the Recipe
        /// </summary>
        public string Name { get; set; }

        public IList<RecipeIngredient> Ingredients { get; set; }

        public string IngredientsStr
        {
            get { return Ingredients != null ? Ingredients.Aggregate("", (str, a) => str+=(str.Length > 0 ? "\n" : "") + a.ToString()) : null; }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
