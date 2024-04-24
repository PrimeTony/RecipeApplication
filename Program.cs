
using System.Collections.Generic;

namespace RecipeApplication
{
    // Notifying the user about exceeding calories
    public delegate void ExceedCaloriesNotification(string recipeName, double totalCalories);

    // class for ingredients
    class Ingredient
    {
        public string? Name { get; set; }
        public double Quantity { get; set; }
         public string Unit { get; set; } = "unit"; // Default value
        public double Calories { get; set; }
        public string? FoodGroup { get; set; } = "unknown"; // Default value
    }

    // Class for recipes
    class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> Steps { get; set; }
        public double TotalCalories { get; private set; }

        public Recipe(string name)
        {
            Name = name;
            Ingredients = new List<Ingredient>();
            Steps = new List<string>();
            TotalCalories = 0;
        }

        // Method to add an ingredient to the recipe
        public void AddIngredient(string name, double quantity, string unit, double calories, string foodGroup)
        {
            Ingredient ingredient = new Ingredient
            {
                Name = name,
                Quantity = quantity,
                Unit = unit,
                Calories = calories,
                FoodGroup = foodGroup
            };
            Ingredients.Add(ingredient);
            // Update total calories
            TotalCalories += calories * quantity;
        }

        // Method to add a step to the recipe
        public void AddStep(string step)
        {
            Steps.Add(step);
        }

        // Method to display the recipe
        public void DisplayRecipe()
        {
            Console.WriteLine($"Recipe: {Name}");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({ingredient.Calories} calories) - {ingredient.FoodGroup}");
            }

            Console.WriteLine("\nSteps:");
            for (int i = 0; i < Steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Steps[i]}");
            }

            Console.WriteLine($"Total Calories: {TotalCalories}");
        }
    }

    // Main program
    class Program
    {
        static void Main(string[] args)
        {
            List<Recipe> recipes = new List<Recipe>();

            while (true)
            {
                Console.WriteLine("\nEnter the name of the recipe (or type 'done' to finish):");
                string recipeName = Console.ReadLine()?? "";

                if (recipeName.ToLower() == "done")
                    break;

                Recipe recipe = new Recipe(recipeName);

                Console.WriteLine("Enter the number of ingredients:");
                int numIngredients = int.Parse(Console.ReadLine() ?? "");

                for (int i = 0; i < numIngredients; i++)
                {
                    Console.WriteLine($"Enter ingredient {i + 1} name:");
                    string ingredientName = Console.ReadLine();

                    Console.WriteLine($"Enter quantity for {ingredientName}:");
                    double quantity = double.Parse(Console.ReadLine() ?? "0");

                    Console.WriteLine($"Enter unit for {ingredientName}:");
                    string unit = Console.ReadLine();

                    Console.WriteLine($"Enter calories for {ingredientName}:");
                    double calories = double.Parse(Console.ReadLine());

                    Console.WriteLine($"Enter food group for {ingredientName}:");
                    string foodGroup = Console.ReadLine();

                    recipe.AddIngredient(ingredientName, quantity, unit, calories, foodGroup);
                }

                Console.WriteLine("Enter the number of steps:");
                int numSteps = int.Parse(Console.ReadLine());

                for (int i = 0; i < numSteps; i++)
                {
                    Console.WriteLine($"Enter step {i + 1}:");
                    string step = Console.ReadLine();
                    recipe.AddStep(step);
                }

                recipes.Add(recipe);
            }

            // Display recipes sorted alphabetically by name
            recipes.Sort((x, y) => string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase));
            foreach (var recipe in recipes)
            {
                Console.WriteLine($"- {recipe.Name}");
            }

            // Allow user to choose which recipe to display
            Console.WriteLine("\nEnter the name of the recipe to display:");
            string recipeToDisplay = Console.ReadLine();
            Recipe selectedRecipe = recipes.Find(r => r.Name.Equals(recipeToDisplay, StringComparison.OrdinalIgnoreCase));
            if (selectedRecipe != null)
            {
                selectedRecipe.DisplayRecipe();
            }
            else
            {
                Console.WriteLine("Recipe not found.");
            }

            // Notify user if total calories exceed 300
            foreach (var recipe in recipes)
            {
                if (recipe.TotalCalories > 300)
                {
                    Console.WriteLine($"Warning: {recipe.Name} exceeds 300 calories.");
                }
            }
        }
    }
}
