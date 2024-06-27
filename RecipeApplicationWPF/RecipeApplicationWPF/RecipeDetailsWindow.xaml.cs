using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RecipeApplicationWPF
{/// <summary>
/// Josh Napier
/// ST10291238
/// Module: PROG6221
/// </summary>
    public partial class RecipeDetailsWindow : Window
    {
        public RecipeDetailsWindow(Recipe recipe)//Recipe object
        {
            InitializeComponent();
            DisplayRecipeDetails(recipe);//Display the recipe details
        }
        //-----------------------------------------------------------------------
        private void DisplayRecipeDetails(Recipe recipe)//Display the recipe details
        {
            RecipeNameTextBlock.Text = recipe.Name;//Set the recipe name
            IngredientsListBox.Items.Clear();//Clear the ingredients list box
            foreach (var ingredient in recipe.IngredientsList)//Display the ingredients
            {
                IngredientsListBox.Items.Add($"{ingredient.Quantity} {ingredient.Units} of {ingredient.Name} ({ingredient.Calories} calories)");//Add the ingredient to the list box
            }
            StepsListBox.Items.Clear();//Clear the steps list box
            for (int i = 0; i < recipe.Steps.Count; i++)//Display the steps
            {
                StepsListBox.Items.Add($"{i + 1}. {recipe.Steps[i]}");//Add the step to the list box
            }
        }
        //-----------------------------------------------------------------------
        private void Close_Click(object sender, RoutedEventArgs e)//Close the window
        {
            Close();//Close the window
        }
        //-----------------------------------------------------------------------
    }
    //-----------------------------------------------------------------------
}
//-------------------------------------- END OF FILE --------------------------------------