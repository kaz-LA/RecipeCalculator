using System;

namespace RecipeCalculator.Model
{
    public class RecipeCalculatorException : ApplicationException 
    {
        public RecipeCalculatorException() { }

        public RecipeCalculatorException(string message) : base(message) { }

        public RecipeCalculatorException(string message, Exception inner) : base(message, inner) { }
    }
}
