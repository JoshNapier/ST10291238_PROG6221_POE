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
    public partial class IngredientWindow : Window
    {
        public Ingredient Ingredient { get; set; }//Ingredient object

        public IngredientWindow()
        {
            InitializeComponent();
        }
        //-----------------------------------------------------------------------
        private void AddIngredient_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(QuantityTextBox.Text, out double quantity) && double.TryParse(CaloriesTextBox.Text, out double calories))//Check if the quantity and calories are valid numbers
            {
                Ingredient = new Ingredient
                {
                    Name = IngredientNameTextBox.Text,
                    Quantity = quantity,
                    Units = UnitTextBox.Text,
                    Calories = calories,
                    FoodGroup = ((ComboBoxItem)FoodGroupComboBox.SelectedItem).Content.ToString()
                };//Create new ingredient object
                MessageBox.Show("Ingredient added successfully!");//Show a message that the ingredient was added successfully
                Close();
            }
            else
            {
                MessageBox.Show("Please enter valid numbers for quantity and calories.");//Show a message that the quantity and calories are not valid
            }
        }
        //-----------------------------------------------------------------------
    }
    //-----------------------------------------------------------------------
}
//-------------------------------------- END OF FILE --------------------------------------