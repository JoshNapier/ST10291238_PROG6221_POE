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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RecipeApplicationWPF
{/// <summary>
/// Josh Napier
/// ST10291238
/// Module: PROG6221
/// </summary>
    public partial class MainWindow : Window
    {
        public static List<Recipe> recipeList = new List<Recipe>();
        //-----------------------------------------------------------------------
        public MainWindow()
        {
            InitializeComponent();
        }
        //-----------------------------------------------------------------------
        private void btnCreateRecipe_Click(object sender, RoutedEventArgs e)//Create a new recipe
        {
            CreateRecipeWindow createRecipeWindow = new CreateRecipeWindow();//Create a new create recipe window
            createRecipeWindow.ShowDialog();//Show the create recipe window
            if (createRecipeWindow.NewRecipe != null)//If the new recipe is not null
            {
                recipeList.Add(createRecipeWindow.NewRecipe);//Add the new recipe to the recipe list
            }
        }
        //-----------------------------------------------------------------------
        private void btnViewRecipes_Click(object sender, RoutedEventArgs e)//View the recipes
        {
            ViewRecipesWindow viewRecipesWindow = new ViewRecipesWindow();//Create a new view recipes window
            viewRecipesWindow.Show();//Show the view recipes window
        }
        //-----------------------------------------------------------------------
        private void btnExit_Click(object sender, RoutedEventArgs e)//Exit the application
        {
            Application.Current.Shutdown();//Shutdown the application
        }
        //-----------------------------------------------------------------------
    }
    //-----------------------------------------------------------------------
}
//-------------------------------------- END OF FILE --------------------------------------