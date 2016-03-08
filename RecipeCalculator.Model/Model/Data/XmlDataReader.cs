using System;
using System.Linq;
using System.Xml.Linq;
using System.IO;

namespace RecipeCalculator.Model.Data
{
    /// <summary>
    /// Reads the input data for the RecipeCalculator from an Xml file
    /// </summary>
    public class XmlDataReader : IDataReader
    {
        private string _filePath;

        public XmlDataReader(string filePath)
        {
            _filePath = filePath;
        }

        public RecipeCalculatorData GetData()
        {
            if(string.IsNullOrEmpty(_filePath))
            {
                throw new ArgumentNullException("Xml File Path is not specified");
            }

            if (!File.Exists(_filePath))
            {
                throw new FileNotFoundException(string.Format("Xml File '{0}' doesn't exist.", _filePath));
            }

            var doc = XDocument.Load(_filePath);
            
            // read all ingredients
            var elems = doc.Root.Element("AllIngredients").Elements();
            var ingredients = elems.Select(
                elem => new Ingredient()
                    {
                        Name = elem.Attr<string>("name"),
                        Category = elem.Attr<string>("category"),
                        IsOrganic = elem.Attr<bool>("organic"),
                        Price = elem.Attr<decimal>("price"),
                        Unit = elem.Attr<string>("unit"),
                    });

            // read settings
            var settings = new CalculatorSetting();
            elems = doc.Root.Element("Settings").Elements();           
            var tmpElem = elems.FirstOrDefault(e => e.Attr<string>("name").Equals("sales tax", StringComparison.CurrentCultureIgnoreCase));
            if(tmpElem != null)
            {
                settings.TaxPercentage = tmpElem.Attr<decimal>("value");
                settings.TaxRounding = tmpElem.Attr<int>("rounding");
            }

            tmpElem = elems.FirstOrDefault(e => e.Attr<string>("name").Equals("discount", StringComparison.CurrentCultureIgnoreCase));
            if (tmpElem != null)
            {
                settings.DiscountPercentage = tmpElem.Attr<decimal>("value");
                settings.DiscountRounding = tmpElem.Attr<int>("rounding");
            }

            // read all recipes

            elems = doc.Root.Element("Recipes").Elements();
            var recipes = elems.Select(
                elem => new Recipe()
                {
                    Name = elem.Attr<string>("name"),
                    Ingredients = elem.Element("Ingredients")
                                      .Elements()
                                      .Select(
                                ingrdnt => new RecipeIngredient()
                                {
                                    IngredientName = ingrdnt.Attr<string>("name"),
                                    Quantity = ingrdnt.Attr<decimal>("quantity")
                                }).ToList()
                });

            // return

            var data = new RecipeCalculatorData()
            {
                Ingredients = ingredients.AsQueryable(),
                Recipes = recipes.AsQueryable(),
                Settings = settings
            };

            return data;
        }
    }

}
