using Microsoft.VisualStudio.TestTools.UnitTesting;
using RecipeApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApplication.Tests
{
    [TestClass()]
    public class RecipesTests
    {
        [TestMethod()]
        public void CheckCalories_TotalCaloriesExceed300()//Test method to check if total calories exceed 300
        {
            //Arrange
            var recipe = new Recipes("Test Recipe");//Creates a new recipe object
            bool eventInvoked = false;//Boolean variable to check if event is invoked
            string expectedMessage = "Total calories exceed 300";//Expected message to be displayed

            recipe.OnCaloriesExceeded += (message) =>
            {
                eventInvoked = true;
                Assert.AreEqual(expectedMessage, message);
            };//Event handler for calories exceeded

            recipe.AddIngredient(new Ingredients { Name = "Sugar", Quantity = 100, Units = "grams", Calories = 100, FoodGroup = "Carbs" });//Adds ingredient to recipe
            recipe.AddIngredient(new Ingredients { Name = "Butter", Quantity = 100, Units = "grams", Calories = 250, FoodGroup = "Fats" });//Adds ingredient to recipe
            recipe.AddIngredient(new Ingredients { Name = "Flour", Quantity = 100, Units = "grams", Calories = 100, FoodGroup = "Carbs" });//Adds ingredient to recipe

            //Act
            recipe.CheckCalories();//Calls method to check if total calories exceed 300

            //Assert
            Assert.IsTrue(eventInvoked);//Asserts that event is invoked
        }

        [TestMethod()]
        public void CheckCalories_TotalCaloriesDoNotExceed300()//Test method to check if total calories do not exceed 300
        {
            //Arrange
            var recipe = new Recipes("Test Recipe");//Creates a new recipe object
            bool eventInvoked = false;//Boolean variable to check if event is invoked

            recipe.OnCaloriesExceeded += (message) =>
            {
                eventInvoked = true;
            };//Event handler for calories exceeded

            recipe.AddIngredient(new Ingredients { Name = "Sugar", Quantity = 50, Units = "grams", Calories = 50, FoodGroup = "Carbs" });//Adds ingredient to recipe
            recipe.AddIngredient(new Ingredients { Name = "Butter", Quantity = 50, Units = "grams", Calories = 75, FoodGroup = "Fats" });//Adds ingredient to recipe
            recipe.AddIngredient(new Ingredients { Name = "Flour", Quantity = 50, Units = "grams", Calories = 50, FoodGroup = "Carbs" });//Adds ingredient to recipe

            //Act
            recipe.CheckCalories();//Calls method to check if total calories exceed 300

            //Assert
            Assert.IsFalse(eventInvoked);//Asserts that event is not invoked
        }
    }
}