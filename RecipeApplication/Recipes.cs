using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApplication
{
    internal class Recipes
    {


        public string[] Name { get; set; }
        public string[] Ingredients { get; set; }
        public string[] Steps { get; set; }

        public Recipes(string name, int numIngredients, int numSteps, Ingredients[] ingredients)
        {
            Name = name;
            NumIngredients = numIngredients;
            Ingredients[] ingredients1 = new Ingredients[numIngredients];
            NumSteps = numSteps;
            Steps = new string[numSteps];
        }
    }
}
