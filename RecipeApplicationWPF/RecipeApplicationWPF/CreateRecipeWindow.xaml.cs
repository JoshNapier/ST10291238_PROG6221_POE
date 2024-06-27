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
{
    /// <summary>
    /// Interaction logic for CreateRecipeWindow.xaml
    /// </summary>
    public partial class CreateRecipeWindow : Window
    {
        public Recipe NewRecipe { get; set; }//New recipe object
        //-----------------------------------------------------------------------
        public CreateRecipeWindow()
        {
            InitializeComponent();
        }
        //-----------------------------------------------------------------------
        private void Next_Click(object sender, RoutedEventArgs e)//Create a new recipe
        {
            string name = RecipeNameTextBox.Text;//Get the name of the recipe
            if (int.TryParse(NumIngredientsTextBox.Text, out int numIngredients) && int.TryParse(NumStepsTextBox.Text, out int numSteps))//Check if the number of ingredients and steps are valid numbers
            {
                NewRecipe = new Recipe(name);//Create a new recipe object

                for (int i = 0; i < numIngredients; i++)//For each ingredient
                {
                    var ingredientWindow = new IngredientWindow();//Create a new ingredient window
                    ingredientWindow.ShowDialog();//Show the ingredient window
                    if (ingredientWindow.Ingredient != null)//If the ingredient is not null
                    {
                        NewRecipe.AddIngredient(ingredientWindow.Ingredient);//Add the ingredient to the recipe
                    }
                }

                for (int i = 0; i < numSteps; i++)//For each step
                {
                    var stepWindow = new StepWindow();//Create a new step window
                    stepWindow.ShowDialog();//Show the step window
                    if (!string.IsNullOrEmpty(stepWindow.StepDescription))//If the step description is not null or empty
                    {
                        NewRecipe.AddStep(stepWindow.StepDescription);//Add the step to the recipe
                    }
                }

                NewRecipe.CheckCalories();//Check the calories of the recipe
                MessageBox.Show("Recipe created successfully!");//Show a message that the recipe was created successfully

                RecipeDetailsWindow recipeDetailsWindow = new RecipeDetailsWindow(NewRecipe);//Create a new recipe details window
                recipeDetailsWindow.ShowDialog();//Show the recipe details window

                Close();//Close the create recipe window
            }
            else
            {
                MessageBox.Show("Please enter valid numbers for ingredients and steps.");//Show a message that the number of ingredients and steps are not valid
            }
        }
        //-----------------------------------------------------------------------
    }
    //-----------------------------------------------------------------------
}
//-------------------------------------- END OF FILE --------------------------------------