using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DailyDiet : ICompositionCounter, IBase
    {
        public int Id { get; set; }
        private List<Recipe> recipes;
        public DateTime date { get; private set; }

        public DailyDiet(List<Recipe> recipes, DateTime date)
        {
            this.recipes = recipes;
            this.date = date;
        }

        public Composition CountComposition()
        {
            Composition result = new Composition();
            recipes.ForEach(x =>
            {
                result = Composition.SumCompositions(result, x.CountComposition());
            });
            return result;
        }

        public void AddRecipe(Recipe recipe)
        {
            recipes.Add(recipe);
        }

        public List<Recipe> GetRecipes()
        {
            return recipes;
        }
    }
}
