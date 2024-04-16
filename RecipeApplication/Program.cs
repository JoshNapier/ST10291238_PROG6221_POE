using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Recipe Creator Program");

            Console.Write("What is the name of your recipe?");
            string name = Console.ReadLine();

            Console.Write("How many ingredients?");
            int numIngredients = int.Parse(Console.ReadLine());

            Console.Write("How many steps of instructions?");
            int numSteps = int.Parse(Console.ReadLine());

            Recipes recipe = new Recipes(name, numIngredients, numSteps);

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine("Enter details for Ingredient " + (i + 1) + ":");
                Console.Write("Name: ");
                string ingredientName = Console.ReadLine();
                Console.Write("Quantity: ");
                double quantity = double.Parse(Console.ReadLine());
                Console.Write("Unit of Measurement: ");
                string unit = Console.ReadLine();

                recipe.AddIngredient(i, ingredientName, quantity, unit);
            }
            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine("Enter details for step " + (i + 1) + ":");
                Console.Write("Description: ");
                string stepDescription = Console.ReadLine();

                recipe.AddStep(i, stepDescription);
            }

            Console.WriteLine("Recipe Details: ");
            NewMethod(recipe);
        }

        private static void NewMethod(Recipes recipe)
        {
            recipe.PrintRecipe();
        }
    }
}
