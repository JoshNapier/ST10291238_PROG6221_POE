using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApplication
{
    internal class Recipes
    {
        public string Name { get; private set; }
        private Ingredients[] Ingredients;
        private string[] Steps;

        public Recipes(string name, int numIngredients, int numSteps)
        {
            Name = name;
            Ingredients = new Ingredients[numIngredients];
            Steps = new string[numSteps];
        }

        public void AddIngredient(int index, string name, double quantity, string unit)
        {
            Ingredients[index] = new Ingredients { Name = name, Quantity = quantity, Units = unit };
        }

        public void AddStep(int index, string description)
        {
            Steps[index] = description;
        }

        public void PrintRecipe()
        {
            Console.WriteLine("Recipe Name: " + Name);
            Console.WriteLine("Number of Ingredients: " + Ingredients.Length);

            for (int i = 0; i < Ingredients.Length; i++)
            {
                Console.WriteLine("Ingredient " + (i + 1) + ":");
                Console.WriteLine("Name: " + Ingredients[i].Name);
                Console.WriteLine("Quantity: " + Ingredients[i].Quantity);
                Console.WriteLine("Unit of Measurement: " + Ingredients[i].Units);
                Console.WriteLine();
            }

            Console.WriteLine("Number of Steps: " + Steps.Length);

            for (int i = 0; i < Steps.Length; i++)
            {
                Console.WriteLine("Step " + (i + 1) + ":");
                Console.WriteLine("Description: " + Steps[i]);
                Console.WriteLine();
            }
        }

        public void ScaleQuantities(double factor)
        {
            for (int i = 0; i < Ingredients.Length; i++)
            {
                Ingredients[i].Quantity *= factor;
            }
        }

        public void ResetQuantities()
        {
            for (int i = 0; i < Ingredients.Length; i++)
            {
                Ingredients[i].Quantity = 0;
            }
        }

        public void ClearRecipe()
        {
            Name = "";
            Ingredients = new Ingredients[0];
            Steps = new string[0];
        }

    }
}
