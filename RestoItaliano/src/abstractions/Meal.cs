using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestoItaliano.src.enumerations;
using RestoItaliano.src.interfaces;

namespace RestoItaliano.src.abstractions
{
    public abstract class Meal : IMeal
    {
        protected string Name { get; set; }
        protected string Description { get; set; }
        protected Nutriscore Nutriscore { get; set; }

        public Meal(string Name, string Description, Nutriscore Nutriscore)
        {
            this.Name = Name;
            this.Description = Description;
            this.Nutriscore = Nutriscore;
        }

        public string GetName()
        {
            return this.Name;
        }

        public string GetDescription()
        {
            return this.Description;
        }

        public Nutriscore GetNutriscore()
        {
            return this.Nutriscore;
        }

        public override string ToString()
        {
            return "Type de plat: " + this.GetType().Name + "\n" +
                   "Nom: " + this.Name + "\n" +
                   "Description: " + this.Description + "\n" +
                   "Nutriscore: " + this.Nutriscore;
        }

    }
}
