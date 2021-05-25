using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DosedProduct : IBase
    {
        public int Id { get; set; }
        private Product product;
        public Product Product { get { return product; } set { product = value; } }
        private double weight;
        public double Weight { get { return weight; } set { weight = value; } }

        public Composition GetAbsoluteComposition
        {
            get { return Composition.CountAbsoluteDose(product.Composition, weight); }
        }
    }
}
