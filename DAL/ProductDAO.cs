using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class ProductDAO : DAO<Product>
    {
        public ProductDAO()
        {
            Create(new Product("Картопля", new Composition(
                new Dictionary<String, double>()
                {
                    { "C, аскорбiнова", 0.02},
                    { "В4, холiн", 0.011},
                    { "РР, нiкотинова кислота", 0.0018}
                },
                new Dictionary<string, double>()
                {
                    { "Калiй, K", 0.568 },
                    { "Хлор, Cl", 0.058 },
                    { "Фосфор, P", 0.058 },
                },
                2, 0.4, 16.3, 77)));
            Create(new Product("Молоко коров'яче", new Composition(
                new Dictionary<String, double>()
                {
                    { "C, аскорбiнова", 0.0015}
                },
                new Dictionary<string, double>()
                {
                    { "Калiй, K", 0.151 },
                    { "Кальцiй, Ca", 0.119 },
                    { "Фосфор, P", 0.093 },
                    { "Натрiй, Na", 0.049 },
                },
                3.3, 3.7, 4.7, 64)));
            Create(new Product("Маргарин", new Composition(
                new Dictionary<String, double>()
                {
                    { "Е, альфа токоферол", 0.031},
                    { "В4, холiн", 0.01065}
                },
                new Dictionary<string, double>()
                {
                    { "Калiй, K", 0.022 },
                    { "Кальцiй, Ca", 0.019 },
                    { "Фосфор, P", 0.082 },
                    { "Натрiй, Na", 0.023 }
                },
                0.5, 82, 0.7, 743)));
        }
    }
}
