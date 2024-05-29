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
    internal class Recipe
    {


        public void NewRecipe()//Method called whenever a new recipe is created
        {
            Console.ForegroundColor = ConsoleColor.Red;//Declaring colour of text
            Console.WriteLine("************Recipe Creator Program************", Console.ForegroundColor);
            Console.ResetColor();//Resets colour of text to default

            Console.Write("What is the name of your recipe? ");
            string name = Console.ReadLine();//Prompts user to input name of recipe

            Console.WriteLine();

            int numIngredients;//Variable used for number of ingredients
            bool validNumIngredients = false;
            do
            {
                Console.Write("How many ingredients? ");
                string inputIngredients = Console.ReadLine();
                validNumIngredients = int.TryParse(inputIngredients, out numIngredients);//TryParse that decides if the input value is a valid intger

                if (!validNumIngredients)
                {
                    Console.WriteLine("Please enter a valid integer for the number of ingredients.");//Error message if value inputted is not a valid intger value
                }

            } while (!validNumIngredients);

            Console.WriteLine();

            int numSteps;//Variable used for number of instruction steps
            bool validNumSteps = false;
            do
            {
                Console.Write("How many steps of instructions? ");
                string inputSteps = Console.ReadLine();
                validNumSteps = int.TryParse(inputSteps, out numSteps);//TryParse that decides if the input value is a valid intger

                if (!validNumSteps)
                {
                    Console.WriteLine("Please enter a valid integer for the number of steps.");//Error message if value inputted is not a valid intger value
                }
            } while (!validNumSteps);

            Console.WriteLine();

            //Creates an object of the Recipes class with the name, number of ingredients and number of steps as parameters
            Recipes recipe = new Recipes(name);

            for (int i = 0; i < numIngredients; i++)//For Loop that loops according to the number of ingredients inputted
            {
                Console.WriteLine("Enter details for Ingredient " + (i + 1) + ":");
                Console.Write("Name: ");
                string ingredientName = Console.ReadLine();//Takes in name of ingredient and

                double quantity;//Variable used for quantity of ingredients
                bool validQuantity = false;
                do
                {
                    Console.Write("Quantity: ");
                    string inputQuantity = Console.ReadLine();
                    validQuantity = double.TryParse(inputQuantity, out quantity);//TryParse that decides if the input value is a valid double

                    if (!validQuantity)
                    {
                        Console.WriteLine("Please enter a valid double value for the quantity of the ingredient.");//Error message if value inputted is not a valid double value
                    }
                } while (!validQuantity);

                Console.Write("Unit of Measurement: ");
                string unit = Console.ReadLine();//Takes in name of unit of measurement

                double calories;//Variable used for calories of ingredients
                bool validCalories = false;
                do
                {
                    Console.Write("Calories: ");
                    string inputCalories = Console.ReadLine();
                    validCalories = double.TryParse(inputCalories, out calories);//TryParse that decides if the input value is a valid double

                    if (!validCalories)
                    {
                        Console.WriteLine("Please enter a valid double value for the calories of the ingredient.");//Error message if value inputted is not a valid double value
                    }
                } while (!validCalories);

                Console.Write("Food Group: ");
                string foodGroup = Console.ReadLine();//Takes in name of food group

                //Calls method that adds data to ingredients list
                recipe.AddIngredient(new Ingredients { Name = ingredientName, Quantity = quantity, Units = unit, Calories = calories, FoodGroup = foodGroup });
            }

            Console.WriteLine();

            for (int i = 0; i < numSteps; i++)//For Loop that loops according to the number of instruction steps inputted
            {
                Console.WriteLine("Enter details for step " + (i + 1) + ":");
                Console.Write("Description: ");
                string stepDescription = Console.ReadLine();//Takes in description of instruction step 

                recipe.AddStep(stepDescription);//Calls method that adds data to steps list
            }

            Console.WriteLine();

            recipe.CheckCalories();//Calls method to check if total calories exceed 300

            Console.ForegroundColor = ConsoleColor.Green;//Declaring colour of text
            Console.WriteLine("************Recipe Details************", Console.ForegroundColor);
            Console.ResetColor();//Resets colour of text to default
            CreatedRecipe(recipe);
        }
        //-----------------------------------------------------------------------
        public void CreatedRecipe(Recipes recipe)
        {
            recipe.PrintRecipe();//Calls method to print recipe details

            while (true)
            {
                //Message to prompt user to choose an option
                Console.WriteLine();
                Console.WriteLine("Select an option: ");
                Console.WriteLine("1. Scale ingredient quantities");
                Console.WriteLine("2. Reset ingredient quantities");
                Console.WriteLine("3. Clear all recipe data");
                Console.WriteLine("4. Exit");

                int option = int.Parse(Console.ReadLine());//Parses integer to a string value

                switch (option)//Switch case for choosing option
                {
                    case 1:
                        Console.Write("Enter scaling factor: ");
                        double factor = double.Parse(Console.ReadLine());//Parses double to a string value
                        recipe.ScaleQuantities(factor);//Calls method to scale quantities with the variable factor as parameter
                        Console.WriteLine("Ingredient quantities scaled.");
                        recipe.PrintRecipe();//Calls method to print recipe details after scaling quantities
                        break;
                    case 2:
                        recipe.ResetQuantities();//Calls method to reset quantities
                        Console.WriteLine("Ingredient quantities reset.");
                        recipe.PrintRecipe();//Calls method to print recipe details after resetting quantities
                        break;
                    case 3:
                        recipe.ClearRecipe();//Calls method to clear recipe data
                        Console.WriteLine("Recipe data cleared. Ready to create a new recipe.");
                        Console.WriteLine();
                        NewRecipe();//Calls method to create new recipe with new data
                        break;
                    case 4:
                        Environment.Exit(0);//Ends programm when selected
                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }
            }
        }
        //-----------------------------------------------------------------------

    }
}
//-------------------------------------- END OF FILE --------------------------------------