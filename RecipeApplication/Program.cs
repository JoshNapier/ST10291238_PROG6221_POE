using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApplication
{/// <summary>
/// Josh Napier
/// ST10291238
/// Module: PRG6221
/// </summary>
//-----------------------------------------------------------------------
    internal class Program
    {
//-----------------------------------------------------------------------
        static void Main(string[] args)
        {
            while (true)
            {
                Recipe recipe = new Recipe();

                Console.WriteLine("Welcome to the Recipe Creation Programm!");
                Console.WriteLine("Choose an option below:");
                Console.WriteLine("1. Create a new recipe");
                Console.WriteLine("2. Exit");

                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        recipe.NewRecipe();
                        break;
                    case 2:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }

        }
//-----------------------------------------------------------------------
    }
}
//-------------------------------------- END OF FILE --------------------------------------