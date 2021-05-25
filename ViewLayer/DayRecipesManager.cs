using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ViewLayer
{
    class DayRecipesManager
    {
        public IDAO<Recipe> recipeDAO { get; private set; }
        private DailyDiet currentDiet;
        public DayRecipesManager(IDAO<Recipe> recipeDAO, DailyDiet currentDiet)
        {
            this.recipeDAO = recipeDAO;
            this.currentDiet = currentDiet;

            bool active = true;
            while (active)
            {
                switch (displayMenu())
                {
                    case 1:
                        addRecipe();
                        break;
                    case 2:
                        viewRecipes();
                        break;
                    case 3:
                        getDayComposition();
                        break;
                    case 0:
                        active = false;
                        break;
                    default:
                        Console.WriteLine("No such command");
                        break;
                }

            }
        }
        private int displayMenu()
        {
            int selection;

            Console.WriteLine($"\nDiet for {currentDiet.date.ToShortDateString()}\n" +
                              "1) Add recipe\n" +
                              "2) View all recipes\n" +
                              "3) Get day stats\n" +
                              "0) End day");
            selection = Convert.ToInt32(Console.ReadLine());
            return selection;
        }

        private void addRecipe()
        {
            IDictionary<int, Recipe> recipes = recipeDAO.GetAll();
            Console.WriteLine("Avaliable recipes:");
            foreach (KeyValuePair<int, Recipe> entry in recipes)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value.Name}");
            }
            Console.Write("Choose recipe(number):");
            currentDiet.AddRecipe(recipes[Int32.Parse(Console.ReadLine())]);
        }
        private void viewRecipes()
        {
            Console.WriteLine("Added recipes ([index] id: name):");
            List<Recipe> recipes = currentDiet.GetRecipes();
            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine($" [{i}] {recipes[i].Id}: {recipes[i].Name}");
            }
        }
        
        private void getDayComposition()
        {
            Console.WriteLine(currentDiet.CountComposition());
        }
    }
}
