namespace RecipeCalculator.Model.Data
{
    /// <summary>
    /// when implemented, enables to read the input data for the Recipe Calculator from an external source, such as 
    /// an XML file, JSON file, SQL Database, a web service etc
    /// </summary>
    public interface IDataReader
    {
        RecipeCalculatorData GetData();
    }
}
