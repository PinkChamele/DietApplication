using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
     public class Recipe : ICompositionCounter, IBase
    {
        public int Id { get; set; }
        public String Name { get; private set; }
        public String Description { get; private set; }
        private List<DosedProduct> dosedProducts;

        public Recipe(String name, String description, List<DosedProduct> dosedProducts)
        {
            Name = name;
            Description = description;
            this.dosedProducts = dosedProducts;
        }

        public Composition CountComposition()
        {
            Composition result = new Composition();
            dosedProducts.ForEach(x =>
            {
                result = Composition.SumCompositions(result, Composition.CountAbsoluteDose(x.Product.Composition, x.Weight));
            });
            return result;
        }
    }
}
