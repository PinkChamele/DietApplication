using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Composition : IBase
    {
        public int Id { get; set; }
        private Dictionary<String, double> vitamins;
        private Dictionary<String, double> minerals;
        private double proteins;
        private double fats;
        private double carbohydrates;
        private double calories;

        public Composition(Dictionary<String, double> vitamins, Dictionary<String, double> minerals, double proteins, double fats, double carbohydrates, double calories)
        {
            this.vitamins = vitamins;
            this.minerals = minerals;
            this.proteins = proteins;
            this.fats = fats;
            this.carbohydrates = carbohydrates;
            this.calories = calories;
        }

        public Composition()
        {
            this.vitamins = new Dictionary<String, double>();
            this.minerals = new Dictionary<String, double>();
            this.proteins = 0;
            this.fats = 0;
            this.carbohydrates = 0;
            this.calories = 0;
        }

        public static Composition SumCompositions(Composition c1, Composition c2)
        => new Composition(addSubstanceDose(c1.vitamins, c2.vitamins), addSubstanceDose(c1.minerals, c2.minerals),
            c1.proteins + c2.proteins, c1.fats + c2.fats, c1.carbohydrates + c2.carbohydrates,
            c1.calories + c2.calories);

        public static Composition CountAbsoluteDose(Composition c1, double k)
        => new Composition(calculateSubstanceValue(c1.vitamins, k), calculateSubstanceValue(c1.minerals, k),
            c1.proteins * k / 100, c1.fats * k / 100, c1.carbohydrates * k / 100,
            c1.calories * k / 100);

        private static Dictionary<String, double> addSubstanceDose(Dictionary<String, double> substanceDose1, Dictionary<String, double> substanceDose2)
        {
            Dictionary<String, double> result = substanceDose2;
            substanceDose1.ToList().ForEach(x =>
            {
                if (result.ContainsKey(x.Key))
                {
                    result[x.Key] += x.Value;
                }
                else
                {
                    result.Add(x.Key, x.Value);
                }
            });
            return result;
        }

        private static Dictionary<String, double> calculateSubstanceValue(Dictionary<String, double> substanses, double k)
        {
            Dictionary<String, double> result = new Dictionary<String, double>();
            foreach (KeyValuePair<String, double> entry in substanses)
            {
                result.Add(entry.Key, entry.Value * k / 100);
            }
            return result;
        }
        public override string ToString()
        {
            String result = "Vitamins:\n";
            foreach (KeyValuePair<String, double> entry in vitamins)
            {
                result += $"{entry.Key}: {entry.Value}\n";
            }
            result += "Minerals:\n";
            foreach (KeyValuePair<String, double> entry in minerals)
            {
                result += $"{entry.Key}: {entry.Value}\n";
            }
            result += $"Proteins: {proteins}\nFats: {fats}\nCarbohydrates: {carbohydrates}\nCalories: {calories}\n";
            return result;
        }
    }
}
