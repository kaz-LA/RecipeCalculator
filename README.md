# RecipeCalculator
RecipeCalculator is a coding exercise for a Senior Developer position some where in Los Angeles, and contains three projects:
<ul>
 <li>RecipeCalculator.Model - acts as the business logic + data layer</li>
 <li>RecipeCalculator.UI - a WPF UI project for displaying the results of the Recipe Calculator</li>
 <li>RecipeCalculator.Tests - unit testing project containing a few tests for the RecipeCalculator in the Model </li>
</ul> 

<p>It's developed in Visual Studio 2015 on MS Surface Pro 3 running Windows 10.</p>

<h3>Notable Design Patterns </h3>
<ul>
 <li>MVVM/MVC - the solution as a whole is a minimalistic MVVM</li>
 <li>Strategy - the implementation of the input data reading uses the strategy pattern. The IDataReader represents a generic data reading algorithm that can be implemented in different ways for the different input data types - xml, csv, SQL Database, non-sql database, etc</li>
</ul>

Enjoy!!!

<img src='screenshot.PNG' />
