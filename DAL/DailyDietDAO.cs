using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class DailyDietDAO : DAO<DailyDiet>
    {
        public IDAO<Recipe> recipeDAO { get; private set; }
        public DailyDietDAO(IDAO<Recipe> recipeDAO)
        {
            this.recipeDAO = recipeDAO;
            Create(new DailyDiet(new List<Recipe>() { recipeDAO.Get(1) }, DateTime.Now.AddDays(-1)));
        }
    }
}
