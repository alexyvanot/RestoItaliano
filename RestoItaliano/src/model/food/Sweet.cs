using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestoItaliano.src.abstractions;
using RestoItaliano.src.enumerations;

namespace RestoItaliano.src.model.food
{
    public class Sweet : Meal
    {
        private bool HasAllergen { get; set; }

        public Sweet(string Name, string Description, Nutriscore Nutriscore, bool hasAllergen) : base(Name, Description, Nutriscore)
        {
            this.HasAllergen = hasAllergen;
        }

        public bool GetHasAllergen()
        {
            return this.HasAllergen;
        }

        public override string ToString()
        {
            return "Type de plat: " + this.GetType().Name + "\n" +
                   "Nom: " + this.Name + "\n" +
                   "Description: " + this.Description + "\n" +
                   "Nutriscore: " + this.Nutriscore + "\n" +
                   "Allergène: " + this.HasAllergen;
        }
    }
}
