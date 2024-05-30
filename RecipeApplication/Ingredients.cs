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
    public class Ingredients
    {
        //Getters and setters of each component of ingredients
        public string Name { get; set; }//Getter and setter for ingredient name
        public double Quantity { get; set; }//Getter and setter for ingredient quantity
        public string Units { get; set; }//Getter and setter for ingredient units
        public double Calories { get; set; }//Getter and setter for ingredient calories
        public string FoodGroup { get; set; }//Getter and setter for ingredient food group
    }
    //-----------------------------------------------------------------------
}
//-------------------------------------- END OF FILE --------------------------------------