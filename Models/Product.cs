using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Product : IBase
    {
        public int Id { get; set; }
        private String name;
        private Composition composition;
        public Composition Composition { get { return composition; }  set { composition = value; } }

        public Product(String name, Composition composition)
        {
            this.name = name;
            this.composition = composition;
        }
    }
}
