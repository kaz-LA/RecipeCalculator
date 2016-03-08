using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipeCalculator.Model.Data;
using RecipeCalculator.Model;

namespace RecipeCalculator.Tests
{
    [TestClass]
    public class DataReaderTests
    {
        [TestMethod]
        [Description("Verifies that the XmlDataReader successfully reads Recipe and ingredients input data from a specified xml file")]
        [TestCategory("RecipeCalculator.DataReaderTests")]
        [TestProperty("Author", "Kaz")]
        public void XmlDataReaderSuccessfullyReadsDataFromFile()
        {
            var dataFile = "TestData/TestData.xml";
            IDataReader reader = new XmlDataReader(dataFile);
            RecipeCalculatorData data = reader.GetData();

            Assert.IsNotNull(data, "Xml data couldn't be read from file.");
            Assert.IsTrue(data.Ingredients != null && data.Ingredients.Count() > 1, "Xml input data reading failed!");
            Assert.IsTrue(data.Recipes != null && data.Recipes.Count() > 1, "Xml input data reading failed!");
        }
    }
}
