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
    /// Interaction logic for StepWindow.xaml
    /// </summary>
    public partial class StepWindow : Window
    {
        public string StepDescription { get; set; }//Description of the step
        //-----------------------------------------------------------------------
        public StepWindow()
        {
            InitializeComponent();
        }
        //-----------------------------------------------------------------------
        private void AddStep_Click(object sender, RoutedEventArgs e)//Add the step to the recipe
        {
            StepDescription = StepDescriptionTextBox.Text;//Get the description of the step
            MessageBox.Show("Step added successfully!");//Show a message that the step was added successfully
            Close();
        }
        //-----------------------------------------------------------------------
    }
    //-----------------------------------------------------------------------
}
//-------------------------------------- END OF FILE --------------------------------------