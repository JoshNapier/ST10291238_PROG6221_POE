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
    internal class Program
    {
        private static List<Recipes> recipeList = new List<Recipes>();//List for recipe objects

        //-----------------------------------------------------------------------
        static void Main(string[] args)
        {

            while (true)
            {
                Recipe recipe = new Recipe();//Creates an object of the Recipe class

                //Beginning message upon running
                Console.WriteLine("Welcome to the Recipe Creation Programm!");
                Console.WriteLine("Choose an option below:");
                Console.WriteLine("1. Create a new recipe");
                Console.WriteLine("2. View recipes");
                Console.WriteLine("3. Exit");

                int option = int.Parse(Console.ReadLine());

                switch (option)//Switch case for choosing option
                {
                    case 1:
                        recipe.NewRecipe();
                        break;
                    case 2:
                        if (recipeList.Count == 0)
                        {
                            Console.WriteLine("No recipes to display");
                            Console.WriteLine();
                        }
                        else
                        {
                            DisplayRecipes();
                        }
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }

        }
        //-----------------------------------------------------------------------
        public static void DisplayRecipes()
        {
            var sortedRecipes = recipeList.OrderBy(r => r.Name).ToList();//Sorts recipes in alphabetical order

            Console.WriteLine("List of Recipes:");
            for (int i = 0; i < sortedRecipes.Count; i++)//For Loop that loops according to the length of the sorted recipes list
            {
                Console.WriteLine($"{i + 1}. {sortedRecipes[i].Name}");//Prints recipe name taken from sorted recipes list
            }

            Console.WriteLine("Enter the number of the recipe to view it's details, or enter 0 to return");
            int choice = int.Parse(Console.ReadLine());//Takes in choice of recipe to view

            if (choice > 0 && choice <= sortedRecipes.Count)
            {
                sortedRecipes[choice - 1].PrintRecipe();//Prints recipe details of chosen recipe
            }
        }
        //-----------------------------------------------------------------------
    }
}
//-------------------------------------- END OF FILE --------------------------------------