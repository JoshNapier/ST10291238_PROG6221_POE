   M S B A M L   `   `   `  ����O  KRecipeApplicationWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:RecipeApplicationWPFRecipeApplicationWPF  5   	   ,    &RecipeApplicationWPF.ViewRecipesWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   4local"clr-namespace:RecipeApplicationWPF     5   	     � Title$  View Recipes��5   	   $	��750��6   $	��800��6+   .��5	      � .+�5
   
   �� .+�5      �� $��Recipes:��6   $��16(�6(   $
��Bold"�66   $��10q�6H   �� 5      $��Ingredient Name:��6   $
��Left=�6/   �� 5      -   5         ��Name$ IngredientNameTextBox��5      $��10q�65   $	��200��6A   $
��Left=�6M   �� 5      $��Food Group:��6   $
��Left=�6*   �� 5      -   5         ��Name$ FoodGroupComboBox��5      $��10q�62   $	��200��6>   $
��Left=�6J   .@�5      �� $	��All��6   �� 5      $��Starchy foods��6   �� 5      $��Fruits and vegetables��6   �� 5      $'��!Dry beans, peas, lentils and soya��6   �� 5      $"��Chicken, fish, meat and eggs��6   �� 5      $��Milk and dairy products��6   �� 5      $��Fats and oil��6   �� 5      $��Water��6   5      �� 5      $��Max calories:��6   $
��Left=�6,   �� 5      -   5        $ MaxCaloriesTextBox��5      $��10q�62   $	��200��6>   $
��Left=�6J   �� 5      -   5        $��Filter��5      $��10q�6A   $	��100��6M   $
��Left=�6Y   �� 5      -   5         ��Name$ RecipesListBox��5      $��10q�6.   $	��200��6:   6G   �� 5      -   5         ��Name$ RecipeDetailsTextBlock��5      $*��$Select a recipe to view its details.��68   $��10q�6d   $
��Wrap=�6p   �� 5      $��Scaling Factor:��6   $
��Left=�6.   �� 5      -   5        $ ScalingFactorTextBox��5      $��10q�64   $	��200��6@   $
��Left=�6L   �� 5       -   5        $��Scale Ingredients��5       $��10q�6K   $	��150��6W   $
��Left=�6c   �� 5!      -	   5        $��Reset Ingredients��5!      $��10q�6K   $	��150��6W   $
��Left=�6c   �� 5"      -
   5        $��Close��5"      $��10q�69   $��Right=�6E   5#      5$      5%      