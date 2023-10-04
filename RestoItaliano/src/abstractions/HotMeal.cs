using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestoItaliano.src.enumerations;

namespace RestoItaliano.src.abstractions
{
    public abstract class HotMeal : Meal
    {
        private int CookingTime { get; set; }

        protected HotMeal(string Name, string Description, Nutriscore Nutriscore, int CookingTime) : base(Name, Description, Nutriscore)
        {
            this.CookingTime = CookingTime;
        }

        /* Erreur dans le schema UML corrigé en CookingTime:int
        protected HotMeal(string Name, string Description, Nutriscore Nutriscore, CookingTemperature CookingTemp) : base(Name, Description, Nutriscore)
        {
        }
        */

        public int GetCookingTime()
        {
            return this.CookingTime;
        }

        public override string ToString()
        {
            return "Type de plat: " + this.GetType().Name + "\n" +
                   "Nom: " + this.Name + "\n" +
                   "Description: " + this.Description + "\n" +
                   "Nutriscore: " + this.Nutriscore + "\n" +
                   "Cuisson: " + this.CookingTime + " min";
        }

    }
}
