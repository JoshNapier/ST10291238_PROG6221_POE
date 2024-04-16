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
        private Ingredients[] Ingredients;//Array for recipe ingredients
        private string[] Steps;//Array for recipe instruction steps
//-----------------------------------------------------------------------
        public Recipes(string name, int numIngredients, int numSteps)//Constructor for Recipes class
        {
            Name = name;
            Ingredients = new Ingredients[numIngredients];
            Steps = new string[numSteps];
        }
//-----------------------------------------------------------------------
        public void AddIngredient(int index, string name, double quantity, string unit)
        {
            //Adds ingredients object to ingredients array with name, quantity and units as parameters
            Ingredients[index] = new Ingredients { Name = name, Quantity = quantity, Units = unit };
        }
//-----------------------------------------------------------------------
        public void AddStep(int index, string description)
        {
            //Adds description to steps array
            Steps[index] = description;
        }
//-----------------------------------------------------------------------
        public void PrintRecipe()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;//Declaring colour of text
            Console.WriteLine("----Ingredients----", Console.ForegroundColor);
            Console.ResetColor();//Resets colour of text to default

            for (int i = 0; i < Ingredients.Length; i++)//For Loop that loops according to the length of the ingredients array
            {
                Console.WriteLine("Ingredient " + (i + 1) + ":");
                Console.WriteLine("Name: " + Ingredients[i].Name);//Prints ingredient name taken from array
                Console.WriteLine("Quantity: " + Ingredients[i].Quantity + " " + Ingredients[i].Units);//Prints ingredient quantity and unit taken from array
                Console.WriteLine();
            }

            Console.ForegroundColor= ConsoleColor.Cyan;//Declaring colour of text
            Console.WriteLine("----Instructions----", Console.ForegroundColor);
            Console.ResetColor();//Resets colour of text to default

            for (int i = 0; i < Steps.Length; i++)//For Loop that loops according to the length of the steps array
            {
                Console.WriteLine("Step " + (i + 1) + ":");
                Console.WriteLine("Description: " + Steps[i]);
                Console.WriteLine();
            }
        }
//-----------------------------------------------------------------------
        public void ScaleQuantities(double factor)
        {
            for (int i = 0; i < Ingredients.Length; i++)//For Loop that loops according to the length of the ingredients array
            {
                Ingredients[i].Quantity *= factor;//Multiplies the value of quantity by the value of factor
            }
        }
//-----------------------------------------------------------------------
        public void ResetQuantities()
        {
            for (int i = 0; i < Ingredients.Length; i++)//For Loop that loops according to the length of the ingredients array
            {
                Ingredients[i].Quantity = 0;//Resets the value of quantity to zero
            }
        }
//-----------------------------------------------------------------------
        public void ClearRecipe()//Clears data of every field for recipe
        {
            Name = "";
            Ingredients = new Ingredients[0];
            Steps = new string[0];
        }
//-----------------------------------------------------------------------
    }
}
//-------------------------------------- END OF FILE --------------------------------------