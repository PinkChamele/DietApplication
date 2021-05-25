using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace DietApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            new DayManager(new DailyDietDAO(new RecipeDAO(new ProductDAO())));
            Console.WriteLine("exiting...");
        }
    }
}
