using System;

namespace RecipeApplication
{
    class Recipe
    {
        private string[] ingredients;
        private string[] units;
        private double[] quantities;
        private string[] steps;

        public Recipe()
        {
            ingredients = new string[0];
            units = new string[0];
            quantities = new double[0];
            steps = new string[0];
        }

        public void AddIngredient(string ingredient, double quantity, string unit)
        {
            Array.Resize(ref ingredients, ingredients.Length + 1);
            Array.Resize(ref units, units.Length + 1);
            Array.Resize(ref quantities, quantities.Length + 1);

            ingredients[ingredients.Length - 1] = ingredient;
            units[units.Length - 1] = unit;
            quantities[quantities.Length - 1] = quantity;
        }

        public void AddStep(string step)
        {
            Array.Resize(ref steps, steps.Length + 1);
            steps[steps.Length - 1] = step;
        }

        public void DisplayRecipe()
        {
            Console.WriteLine("Ingredients:");
            for (int i = 0; i < ingredients.Length; i++)
            {
                Console.WriteLine($"{quantities[i]} {units[i]} of {ingredients[i]}");
            }

            Console.WriteLine("\nSteps:");
            for (int i = 0; i < steps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
        }

        public void ScaleRecipe(double factor)
        {
            for (int i = 0; i < quantities.Length; i++)
            {
                quantities[i] *= factor;
            }
        }

        public void ResetQuantities()
        {
            // Reset quantities to original values
            // Original values assumed to be stored elsewhere, not implemented in this example
        }
        

        public void ClearRecipe()
        {
            ingredients = new string[0];
            units = new string[0];
            quantities = new double[0];
            steps = new string[0];
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Recipe recipe = new Recipe();

            Console.WriteLine("Enter the number of ingredients:");
            int numIngredients = int.Parse(Console.ReadLine());

            for (int i = 0; i < numIngredients; i++)
            {
                Console.WriteLine($"Enter ingredient {i + 1} name:");
                string ingredient = Console.ReadLine();

                Console.WriteLine($"Enter quantity for {ingredient}:");
                double quantity = double.Parse(Console.ReadLine());

                Console.WriteLine($"Enter unit for {ingredient}:");
                string unit = Console.ReadLine();

                recipe.AddIngredient(ingredient, quantity, unit);
            }

            Console.WriteLine("Enter the number of steps:");
            int numSteps = int.Parse(Console.ReadLine());

            for (int i = 0; i < numSteps; i++)
            {
                Console.WriteLine($"Enter step {i + 1}:");
                string step = Console.ReadLine();
                recipe.AddStep(step);
            }

            recipe.DisplayRecipe();

            Console.WriteLine("\nEnter scaling factor (0.5, 2, or 3):");
            double scale = double.Parse(Console.ReadLine());

            recipe.ScaleRecipe(scale);
            recipe.DisplayRecipe();

            // Reset quantities if needed
            // recipe.ResetQuantities();

            Console.WriteLine("\nEnter 'clear' to clear recipe or any other key to exit:");
            string input = Console.ReadLine();

            if (input.ToLower() == "clear")
            {
                recipe.ClearRecipe();
                Console.WriteLine("Recipe cleared.");
            }
        }
    }
}
