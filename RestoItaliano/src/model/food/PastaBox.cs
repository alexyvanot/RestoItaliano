using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestoItaliano.src.abstractions;
using RestoItaliano.src.enumerations;

namespace RestoItaliano.src.model.food
{
    public class PastaBox : HotMeal
    {
        private string SalsaDescription { get; set; }

        public PastaBox(string Name, string Description, Nutriscore Nutriscore, int CookingTime, string SalsaDescription) : base(Name, Description, Nutriscore, CookingTime)
        {
            this.SalsaDescription = SalsaDescription;
        }

        /* Erreur dans le schema UML corrigé en CookingTime:int
        public PastaBox(string Name, string Description, Nutriscore Nutriscore, CookingTemperature CookingTemp) : base(Name, Description, Nutriscore, CookingTemp)
        {
        }
        */

        public string GetSalsaDescription()
        {
            return this.SalsaDescription;
        }

        public override string ToString()
        {
            return "Type de plat: " + this.GetType().Name + "\n" +
                   "Nom: " + this.Name + "\n" +
                   "Description: " + this.Description + "\n" +
                   "Nutriscore: " + this.Nutriscore + "\n" +
                   "Cuisson: " + this.GetCookingTime() + " min\n" +
                   "Sauce: " + this.SalsaDescription;
        }

        
    }
}
