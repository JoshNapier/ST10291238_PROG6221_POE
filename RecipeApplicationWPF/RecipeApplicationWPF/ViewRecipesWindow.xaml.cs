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
/// Josh Napier
/// ST10291238
/// Module: PROG6221
/// </summary>
    public partial class ViewRecipesWindow : Window
    {
        private Recipe selectedRecipe;
        private List<Ingredient> originalIngredients;
        //-----------------------------------------------------------------------
        public ViewRecipesWindow()//view recipes window constructor
        {
            InitializeComponent();//initialize component
            RefreshRecipeList();//refresh recipe list
        }
        //-----------------------------------------------------------------------
        private void RefreshRecipeList(IEnumerable<Recipe> recipes = null)//refresh recipe list method
        {
            RecipesListBox.Items.Clear();
            var listToDisplay = recipes ?? MainWindow.recipeList;//if recipes is null, display all recipes
            foreach (var recipe in MainWindow.recipeList)//display all recipes
            {
                RecipesListBox.Items.Add(recipe.Name);//add recipe name to list box
            }
        }
        //-----------------------------------------------------------------------
        private void FilterButton_Click(object sender, RoutedEventArgs e)//filter recipes method
        {
            string ingredientName = IngredientNameTextBox.Text.ToLower();//get ingredient name
            string selectedFoodGroup = (FoodGroupComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();//get selected food group
            string maxCaloriesText = MaxCaloriesTextBox.Text;//get max calories
            double maxCalories;
            bool isMaxCaloriesValid = double.TryParse(maxCaloriesText, out maxCalories);//check if max calories is valid

            var filteredRecipes = MainWindow.recipeList.Where(recipe =>
                (string.IsNullOrWhiteSpace(ingredientName) || recipe.IngredientsList.Any(ingredient => ingredient.Name.ToLower().Contains(ingredientName))) &&
                (selectedFoodGroup == "All" || recipe.IngredientsList.Any(ingredient => ingredient.FoodGroup == selectedFoodGroup)) &&
                (!isMaxCaloriesValid || recipe.IngredientsList.Sum(ingredient => ingredient.Calories) <= maxCalories)
            );//filter recipes based on ingredient name, food group, and max calories

            RefreshRecipeList(filteredRecipes);//refresh recipe list
        }
        //-----------------------------------------------------------------------
        private void RecipesListBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)//display recipe details method
        {
            if (RecipesListBox.SelectedItem != null)//if a recipe is selected
            {
                string selectedRecipeName = RecipesListBox.SelectedItem.ToString();//get selected recipe name
                Recipe selectedRecipe = MainWindow.recipeList.Find(r => r.Name == selectedRecipeName);//find selected recipe
                if (selectedRecipe != null)//if selected recipe is not null
                {
                    originalIngredients = selectedRecipe.IngredientsList.Select(ingredient => new Ingredient
                    {
                        Name = ingredient.Name,
                        Quantity = ingredient.Quantity,
                        Units = ingredient.Units,
                        Calories = ingredient.Calories,
                        FoodGroup = ingredient.FoodGroup
                    }).ToList();//copy ingredients to original ingredients list

                    DisplayRecipeDetails(selectedRecipe);//display recipe details
                }
            }
        }
        //-----------------------------------------------------------------------
        private void ScaleButton_Click(object sender, RoutedEventArgs e)//scale recipe method
        {
            if (selectedRecipe == null || string.IsNullOrWhiteSpace(ScalingFactorTextBox.Text))//if no recipe is selected or scaling factor is empty
            {
                MessageBox.Show("Please select a recipe and enter a scaling factor.");//display error message
                return;
            }

            if (!double.TryParse(ScalingFactorTextBox.Text, out double scalingFactor) || scalingFactor <= 0)//if scaling factor is not a valid number
            {
                MessageBox.Show("Please enter a valid scaling factor (positive number).");//display error message
                return;
            }

            foreach (var ingredient in selectedRecipe.IngredientsList)//scale each ingredient
            {
                ingredient.Quantity *= scalingFactor;//scale ingredient quantity
            }

            DisplayRecipeDetails(selectedRecipe);//display recipe details
        }
        //-----------------------------------------------------------------------
        private void ResetButton_Click(object sender, RoutedEventArgs e)//reset recipe method
        {
            if (selectedRecipe == null)//if no recipe is selected
            {
                MessageBox.Show("Please select a recipe first.");//display error message
                return;
            }

            selectedRecipe.IngredientsList = originalIngredients.Select(ingredient => new Ingredient
            {
                Name = ingredient.Name,
                Quantity = ingredient.Quantity,
                Units = ingredient.Units,
                Calories = ingredient.Calories,
                FoodGroup = ingredient.FoodGroup
            }).ToList();//reset ingredients to original ingredients

            DisplayRecipeDetails(selectedRecipe);//display recipe details
        }
        //-----------------------------------------------------------------------
        private void DisplayRecipeDetails(Recipe recipe)//display recipe details method
        {
            RecipeDetailsTextBlock.Text = $"Name: {recipe.Name}\n\n";//display recipe name

            RecipeDetailsTextBlock.Text += "Ingredients:\n";//display ingredients
            foreach (var ingredient in recipe.IngredientsList)//display each ingredient
            {
                RecipeDetailsTextBlock.Text += $"- {ingredient.Name}, {ingredient.Quantity} {ingredient.Units}, {ingredient.Calories} calories, Food Group ({ingredient.FoodGroup})\n";//display ingredient details
            }

            RecipeDetailsTextBlock.Text += "\nInstructions:\n";//display instructions
            for (int i = 0; i < recipe.Steps.Count; i++)//display each step
            {
                RecipeDetailsTextBlock.Text += $"{i + 1}. {recipe.Steps[i]}\n";//display step details
            }
        }
        //-----------------------------------------------------------------------
        private void Close_Click(object sender, RoutedEventArgs e)//close window method
        {
            Close();//close window
        }
        //-----------------------------------------------------------------------
    }
    //-----------------------------------------------------------------------
}
//-------------------------------------- END OF FILE --------------------------------------