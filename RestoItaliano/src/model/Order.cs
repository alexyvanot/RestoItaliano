using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using RestoItaliano.src.interfaces;
using RestoItaliano.src.model.food;

namespace RestoItaliano.src.model
{
    public class Order
    {
        public int Id { get; private set; }
        private List<IMeal> Meals { get; set; }
        private DateTime DateOrder { get; set; }

        public Order(int Id, DateTime DateOrder)
        {
            this.Id = Id;
            this.DateOrder = DateOrder;
            this.Meals = new List<IMeal>();
        }

        public void AddMeal(IMeal meal)
        {
            this.Meals.Add(meal);
        }

        public List<Pizza> GetPizzas()
        {
            List<Pizza> pizzas = new List<Pizza>();
            foreach (IMeal meal in this.Meals)
            {
                if (meal is Pizza)
                {
                    pizzas.Add((Pizza)meal);
                }
            }
            return pizzas;
        }

        public List<PastaBox> GetPastas()
        {
            List<PastaBox> pastas = new List<PastaBox>();
            foreach (IMeal meal in this.Meals)
            {
                if (meal is PastaBox)
                {
                    pastas.Add((PastaBox)meal);
                }
            }
            return pastas;
        }

        public List<Sweet> GetSweets()
        {
            List<Sweet> sweets = new List<Sweet>();
            foreach (IMeal meal in this.Meals)
            {
                if (meal is Sweet)
                {
                    sweets.Add((Sweet)meal);
                }
            }
            return sweets;
        }

        public override string ToString()
        {
            CultureInfo ci = new CultureInfo("fr-FR");
            StringBuilder sb = new StringBuilder();
            string day = this.DateOrder.ToString("dddd", ci).ToUpper()[0] + this.DateOrder.ToString("dddd", ci).Substring(1);
            string month = this.DateOrder.ToString("MMMM", ci).ToUpper()[0] + this.DateOrder.ToString("MMMM", ci).Substring(1);

            sb.Append("Commande n°" + this.Id + "\n");
            sb.Append("Passée le " + day + " " + this.DateOrder.Day + " " + month + " à " + this.DateOrder.ToString("HH:mm") + "\n");
            string rowFormatMeal = "";
            foreach (IMeal meal in this.Meals)
            {
                rowFormatMeal = "- " + this.Meals.Count(m => m == meal) + " " + meal.GetType().Name + " " + meal.GetName() + "\n";
                if (!sb.ToString().Contains(rowFormatMeal))
                {
                    sb.Append(rowFormatMeal);
                }
            }


            return sb.ToString();

        }

        // Personnal Feature Added

        public bool isEmpty()
        {
            return this.Meals.Count == 0;
        }

        public List<IMeal> GetMeals()
        {
            return this.Meals;
        }

    }
}
