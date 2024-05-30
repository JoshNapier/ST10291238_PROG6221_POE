using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApplication
{
    /// <summary>
    /// Josh Napier
    /// ST10291238
    /// Module: PROG6221
    /// </summary>
    //-----------------------------------------------------------------------
    public class Recipes
    {
        public string Name { get; private set; }//Getter and setter for recipe name
        private List<Ingredients> IngredientsList;//List for recipe ingredients
        private List<string> Steps;//Array for recipe instruction steps
        private List<double> OriginalQuantities;//List to store original quantities

        public delegate void CaloriesExceededHandler(string message);
        public event CaloriesExceededHandler OnCaloriesExceeded;
        //-----------------------------------------------------------------------
        public Recipes(string name)//Constructor for Recipes class
        {
            Name = name;
            IngredientsList = new List<Ingredients>();
            Steps = new List<string>();
            OriginalQuantities = new List<double>();
        }
        //-----------------------------------------------------------------------
        public void AddIngredient(Ingredients ingredient)
        {
            //Adds ingredients object to ingredients list
            IngredientsList.Add(ingredient);
            OriginalQuantities.Add(ingredient.Quantity);
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

            Console.ForegroundColor = ConsoleColor.Cyan;//Declaring colour of text
            Console.WriteLine("----Instructions----", Console.ForegroundColor);
            Console.ResetColor();//Resets colour of text to default

            for (int i = 0; i < Steps.Count; i++)//For Loop that loops according to the length of the steps array
            {
                Console.WriteLine("Step " + (i + 1) + ":");//Prints step number
                Console.WriteLine("Description: " + Steps[i]);//Prints step description taken from list
                Console.WriteLine();
            }
        }
        //-----------------------------------------------------------------------
        public void ScaleQuantities(double factor)
        {
            for (int i = 0; i < IngredientsList.Count; i++)//For Loop that loops according to the length of the ingredients list
            {
                IngredientsList[i].Quantity = OriginalQuantities[i] * factor;//Multiplies the value of quantity by the value of factor
            }
        }
        //-----------------------------------------------------------------------
        public void ResetQuantities()
        {
            Console.WriteLine("Are you sure you want to reset the quantities? (Y/N)");//Asks user for confirmation
            string confirmation = Console.ReadLine();

            if (confirmation.ToUpper() == "Y")//If user enters Y, then reset quantities
            {
                for (int i = 0; i < IngredientsList.Count; i++)//For Loop that loops according to the length of the ingredients array
                {
                    IngredientsList[i].Quantity = OriginalQuantities[i];//Resets the value of quantity to original values
                }
                Console.WriteLine("Quantities reset successfully.");//Prints message to user
            }
            else//If user enters N, then cancel reset
            {
                Console.WriteLine("Quantities reset cancelled.");//Prints message to user
            }
        }
        //-----------------------------------------------------------------------
        public void ClearRecipe()//Clears data of every field for recipe
        {
            Name = "";//Clears name
            IngredientsList.Clear();//Clears ingredients list
            Steps.Clear();//Clears steps list
        }
        //-----------------------------------------------------------------------
        public void CheckCalories()//Method to check if total calories exceed 300 and display message to user
        {
            double totalCalories = IngredientsList.Sum(ingredient => ingredient.Calories);//Calculates total calories of ingredients
            if (totalCalories > 300)
            {
                OnCaloriesExceeded?.Invoke("Total calories exceed 300");//Invokes event if total calories exceed 300
                Console.WriteLine("Total calories exceed 300");//Prints message to user
                Console.WriteLine();
            }
        }
        //-----------------------------------------------------------------------
    }
}
//-------------------------------------- END OF FILE --------------------------------------