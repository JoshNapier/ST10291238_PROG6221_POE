using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApplication
{
    internal class Recipe
    {
        public void NewRecipe()
        {
            Console.WriteLine("************Recipe Creator Program************");

            Console.Write("What is the name of your recipe? ");
            string name = Console.ReadLine();

            Console.WriteLine();

            int numIngredients;
            bool validNumIngredients = false;
            do
            {
                Console.Write("How many ingredients? ");
                string inputIngredients = Console.ReadLine();
                validNumIngredients = int.TryParse(inputIngredients, out numIngredients);

                if (!validNumIngredients)
                {
                    Console.WriteLine("Please enter a valid integer for the number of ingredients.");
                }

            } while (!validNumIngredients);

            Console.WriteLine();

            int numSteps;       
            bool validNumSteps = false;
            do
            {
                Console.Write("How many steps of instructions? ");
                string inputSteps = Console.ReadLine();
                validNumSteps = int.TryParse(inputSteps, out numSteps);

                if (!validNumSteps)
                {
                    Console.WriteLine("Please enter a valid integer for the number of steps.");
                }
            } while (!validNumSteps);

            Console.WriteLine();

            Recipes recipe = new Recipes(name, numIngredients, numSteps);

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine("Enter details for Ingredient " + (i + 1) + ":");
                Console.Write("Name: ");
                string ingredientName = Console.ReadLine();

                double quantity;
                bool validQuantity = false;
                do
                {
                    Console.Write("Quantity: ");
                    string inputQuantity = Console.ReadLine();
                    validQuantity = double.TryParse(inputQuantity, out quantity);

                    if (!validQuantity)
                    {
                        Console.WriteLine("Please enter a valid double value for the quantity of the ingredient.");
                    }
                } while (!validQuantity);

                Console.Write("Unit of Measurement: ");
                string unit = Console.ReadLine();

                recipe.AddIngredient(i, ingredientName, quantity, unit);
            }

            Console.WriteLine();

            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine("Enter details for step " + (i + 1) + ":");
                Console.Write("Description: ");
                string stepDescription = Console.ReadLine();

                recipe.AddStep(i, stepDescription);
            }

            Console.WriteLine();

            Console.WriteLine("************Recipe Details************");
            NewMethod(recipe);
        }
        public void NewMethod(Recipes recipe)
        {
            recipe.PrintRecipe();

            Console.WriteLine();
            Console.WriteLine("Select an option: ");
            Console.WriteLine("1. Scale ingredient quantities");
            Console.WriteLine("2. Reset ingredient quantities");
            Console.WriteLine("3. Clear all recipe data");
            Console.WriteLine("4. Exit");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.Write("Enter scaling factor (0.5/2/3): ");
                    double factor = double.Parse(Console.ReadLine());
                    recipe.ScaleQuantities(factor);
                    Console.WriteLine("Ingredient quantities scaled.");
                    recipe.PrintRecipe();
                    break;
                case 2:
                    recipe.ResetQuantities();
                    Console.WriteLine("Ingredient quantities reset.");
                    recipe.PrintRecipe();
                    break;
                case 3:
                    recipe.ClearRecipe();
                    Console.WriteLine("Recipe data cleared. Ready to create a new recipe.");
                    NewRecipe();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }

        }
    }
}
