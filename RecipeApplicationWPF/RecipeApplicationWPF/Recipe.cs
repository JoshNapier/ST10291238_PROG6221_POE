using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApplicationWPF
{/// <summary>
/// Josh Napier
/// ST10291238
/// Module: PROG6221
/// </summary>
    public class Recipe
    {
        public string Name { get; private set; }//Name of the recipe
        public List<Ingredient> IngredientsList;//List of ingredients
        public List<string> Steps;//List of steps
        private List<double> OriginalQuantities;//List of original quantities
        //-----------------------------------------------------------------------
        public delegate void CaloriesExceededHandler(string message);//Delegate for calories exceeded event
        public event CaloriesExceededHandler OnCaloriesExceeded;//Event for calories exceeded
        //-----------------------------------------------------------------------
        public Recipe(string name)//Constructor
        {
            Name = name;//Set the name of the recipe
            IngredientsList = new List<Ingredient>();//Initialize the list of ingredients
            Steps = new List<string>();//Initialize the list of steps
            OriginalQuantities = new List<double>();//Initialize the list of original quantities
        }
        //-----------------------------------------------------------------------
        public void AddIngredient(Ingredient ingredient)//Add ingredient method
        {
            IngredientsList.Add(ingredient);//Add the ingredient to the list of ingredients
            OriginalQuantities.Add(ingredient.Quantity);//Add the quantity of the ingredient to the list of original quantities
        }
        //-----------------------------------------------------------------------
        public void AddStep(string description)//Add step method
        {
            Steps.Add(description);//Add the step to the list of steps
        }
        //-----------------------------------------------------------------------
        public void CheckCalories()//Check calories method
        {
            double totalCalories = IngredientsList.Sum(ingredient => ingredient.Calories);//Calculate the total calories
            if (totalCalories > 300)//If the total calories exceed 300
            {
                OnCaloriesExceeded?.Invoke($"Total calories ({totalCalories}) exceed 300!");//Invoke the calories exceeded event
            }
        }
        //-----------------------------------------------------------------------
    }
}
//-------------------------------------- END OF FILE --------------------------------------