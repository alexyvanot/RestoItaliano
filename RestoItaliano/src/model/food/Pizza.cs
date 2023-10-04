using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestoItaliano.src.abstractions;
using RestoItaliano.src.enumerations;

namespace RestoItaliano.src.model.food
{
    public class Pizza : HotMeal
    {
        private int Size { get; set; }

        public Pizza(string Name, string Description, Nutriscore Nutriscore, int CookingTime, int Size) : base(Name, Description, Nutriscore, CookingTime)
        {
            this.Size = Size;
        }

        /* Erreur dans le schema UML corrigé en CookingTime:int
        public Pizza(string Name, string Description, Nutriscore Nutriscore, CookingTemperature CookingTemp) : base(Name, Description, Nutriscore, CookingTemp)
        {
        }
        */

        public int GetSize()
        {
            return this.Size;
        }

        public override string ToString()
        {
            return "Type de plat: " + this.GetType().Name + "\n" +
                   "Nom: " + this.Name + "\n" +
                   "Description: " + this.Description + "\n" +
                   "Nutriscore: " + this.Nutriscore + "\n" +
                   "Cuisson: " + this.GetCookingTime() + " min\n" +
                   "Taille: " + this.Size + " cm";
        }

    }
}
