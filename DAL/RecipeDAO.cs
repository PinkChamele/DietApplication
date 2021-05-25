using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class RecipeDAO : DAO<Recipe>
    {
        public RecipeDAO(IDAO<Product> productDAO)
        {
            Create(new Recipe("Пюре картопляне",
                "Маса кип'яченого молока. За відсутності молока можна на 10 г збільшити норму закладки жиру.",
                new List<DosedProduct>() { new DosedProduct() { Product = productDAO.Get(1), Weight = 830.0},
                     new DosedProduct() { Product = productDAO.Get(2), Weight = 158.0},
                     new DosedProduct() { Product = productDAO.Get(3), Weight = 60.0}}));
        }
    }
}
