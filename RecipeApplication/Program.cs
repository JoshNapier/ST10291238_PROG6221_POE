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
        }
    }
}
