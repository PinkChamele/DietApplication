using DAL;
using Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewLayer;

namespace DietApplication
{
    class DayManager
    {
        IDAO<DailyDiet> DietDAO;
        public DayManager(IDAO<DailyDiet> dao)
        {
            DietDAO = dao;
            bool active = true;

            while (active)
            {
                switch (displayMenu())
                {
                    case 1:
                        createDay();
                        break;
                    case 2:
                        break;
                    case 3:
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

            Console.WriteLine("\nMain menu\n" +
                              "1) Start day\n" +
                              "2) View all days\n" +
                              "3) Statistics\n" +
                              "0) Quit");
            selection = Convert.ToInt32(Console.ReadLine());
            return selection;
        }

        private void createDay()
        {
            DateTime date;
            Console.WriteLine("Enter date: ");
            date = DateTime.ParseExact(Console.ReadLine(), "yyyy.MM.dd", CultureInfo.InvariantCulture);
            var newDay = new DailyDiet(new List<Recipe> { }, date);
            DietDAO.Create(newDay);

            new DayRecipesManager((DietDAO as DailyDietDAO).recipeDAO, newDay);
        }
    }
}
