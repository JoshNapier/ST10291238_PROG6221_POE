using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApplication
{/// <summary>
/// Josh Napier
/// ST10291238
/// Module: PROG6221
/// </summary>
//-----------------------------------------------------------------------
    internal class Recipes
    {
        public string Name { get; private set; }//Getter and setter for recipe name
        private List<Ingredients> IngredientsList;//List for recipe ingredients
        private List<string> Steps;//Array for recipe instruction steps

        public delegate void CaloriesExceededHandler(string message);
        public event CaloriesExceededHandler OnCaloriesExceeded;
        //-----------------------------------------------------------------------
        public Recipes(string name)//Constructor for Recipes class
        {
            Name = name;
            IngredientsList = new List<Ingredients>();
            Steps = new List<string>();
        }
        //-----------------------------------------------------------------------
        public void AddIngredient(Ingredients ingredient)
        {
            //Adds ingredients object to ingredients list
            IngredientsList.Add(ingredient);
        }
        //-----------------------------------------------------------------------
        public void AddStep(string description)
        {
            //Adds description to steps list
            Steps.Add(description);
        }
        //-----------------------------------------------------------------------
        public void PrintRecipe()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;//Declaring colour of text
            Console.WriteLine("----Ingredients----", Console.ForegroundColor);
            Console.ResetColor();//Resets colour of text to default

            for (int i = 0; i < IngredientsList.Count; i++)//For Loop that loops according to the length of the ingredients list
            {
                Console.WriteLine("Ingredient " + (i + 1) + ":");
                Console.WriteLine("Name: " + IngredientsList[i].Name);//Prints ingredient name taken from array
                Console.WriteLine("Quantity: " + IngredientsList[i].Quantity + " " + IngredientsList[i].Units);//Prints ingredient quantity and unit taken from array
                Console.WriteLine("Calories: " + IngredientsList[i].Calories);//Prints ingredient calories taken from list
                Console.WriteLine("Food Group: " + IngredientsList[i].FoodGroup);//Prints ingredient food group taken from list
                Console.WriteLine();
            }

            Console.ForegroundColor= ConsoleColor.Cyan;//Declaring colour of text
            Console.WriteLine("----Instructions----", Console.ForegroundColor);
            Console.ResetColor();//Resets colour of text to default

            for (int i = 0; i < Steps.Count; i++)//For Loop that loops according to the length of the steps array
            {
                Console.WriteLine("Step " + (i + 1) + ":");
                Console.WriteLine("Description: " + Steps[i]);
                Console.WriteLine();
            }
        }
        //-----------------------------------------------------------------------
        public void ScaleQuantities(double factor)
        {
            for (int i = 0; i < IngredientsList.Count; i++)//For Loop that loops according to the length of the ingredients list
            {
                IngredientsList[i].Quantity *= factor;//Multiplies the value of quantity by the value of factor
            }
        }
        //-----------------------------------------------------------------------
        public void ResetQuantities()
        {
            for (int i = 0; i < IngredientsList.Count; i++)//For Loop that loops according to the length of the ingredients array
            {
                IngredientsList[i].Quantity = 0;//Resets the value of quantity to zero
            }
        }
        //-----------------------------------------------------------------------
        public void ClearRecipe()//Clears data of every field for recipe
        {
            Name = "";
            IngredientsList.Clear();
            Steps.Clear();
        }
        //-----------------------------------------------------------------------
        public void CheckCalories()
        {
            double totalCalories = IngredientsList.Sum(ingredient => ingredient.Calories);
            if (totalCalories > 300)
            {
                OnCaloriesExceeded?.Invoke($"Total calories for {Name} exceed 300");
            }
        }
        //-----------------------------------------------------------------------
    }
}
//-------------------------------------- END OF FILE --------------------------------------