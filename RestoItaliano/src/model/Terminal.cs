using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestoItaliano.src.abstractions;
using RestoItaliano.src.enumerations;
using RestoItaliano.src.interfaces;
using RestoItaliano.src.model.food;

namespace RestoItaliano.src.model
{
    public class Terminal
    {
        public static Terminal instance;
        private static readonly object padlock = new object();

        public static Terminal GetInstance()
        {
            if (instance == null)
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Terminal();
                    }
                }
            }
            return instance;
        }

        private List<Order> Orders { get; set; }

        private List<Pizza> SamplePizzas { get; set; }
        private List<PastaBox> SamplePastas { get; set; }
        private List<Sweet> SampleSweets { get; set; }

        private Terminal()
        {
            Orders = new List<Order>();
            SamplePizzas = new List<Pizza>();
            SamplePastas = new List<PastaBox>();
            SampleSweets = new List<Sweet>();
        }

        public void CreateOrder()
        {
            int id = this.Orders.Count + 1;
            Order order = new Order(id, DateTime.Now);
            this.Orders.Add(order);
        }

        public void DeleteOrder(int idOrder)
        {
            foreach (Order order in this.Orders)
            {
                if (order.Id == idOrder)
                {
                    this.Orders.Remove(order);
                }
            }
        }

        public List<Order> GetOrders()
        {
            return this.Orders;
        }

        public void InitSampleDatas()
        {

            // Pizzas
            Pizza pizza1 = new Pizza(
                "Nordique",
                "Cuite au feu de bois, saumon frais, citron, mozzarella et lit de crème fraiche.",
                Nutriscore.A,
                5,
                33
                );
            Pizza pizza2 = new Pizza(
                "Reigna",
                "Cuite au feu de bois, champignons frais, jambon, mozzarella, olives, origan et coulis de tomate maison.",
                Nutriscore.A,
                6,
                33
                );
            Pizza pizza3 = new Pizza(
                "Landaise",
                "Cuite au feu de bois, cèpes frais, osso irati, foie gras, olives, origan et coulis de tomate maison.",
                Nutriscore.D,
                7,
                33
                );

            // Pastas
            PastaBox pasta1 = new PastaBox(
                "Verdo di Napoli",
                "Pâtes fraiches maison, pesto, jambon de parme et parmesan italien",
                Nutriscore.B,
                10,
                "Sauce maison, basilic frais, pignons de pins, huile d'olive et fromage affiné"
                );
            PastaBox pasta2 = new PastaBox(
                "Rosso di Roma",
                " Pâtes fraiches maison, pesto rosso, boeuf haché, olives et parmesan italien",
                Nutriscore.B,
                9,
                "Sauce maison, tomates fraiches, basilic frais, olives noires, huile d'olive et fromage frais"
                );
            PastaBox pasta3 = new PastaBox(
                "Lassagnas di la Mama",
                "Pâte à lasagnes fraiche maison, sauce maison, boeuf haché, parmesan italien",
                Nutriscore.C,
                25,
                "Sauce maison, tomates fraiches, oignons, origan, huile d'olive et pointe d'ail"
                );

            // Sweets
            Sweet sweet1 = new Sweet(
                "La dinguerie",
                "Pizz-ookie de Chicago, cookie au chocolat géant mi-cuit, passé au four à bois, servie avec une boule de glace à la vanille.",
                Nutriscore.F,
                false
                );
            Sweet sweet2 = new Sweet(
                "Crèpe du gourmant",
                "Crèpe au nutella, chantilly, morceaux de cookies et MnM's.",
                Nutriscore.F,
                true
                );
            Sweet sweet3 = new Sweet(
                "Glace italienne",
                "Glace à l'italienne, crème glacée légère onctueuse à la vanille.",
                Nutriscore.C,
                false
                );
            Sweet sweet4 = new Sweet(
                "Tiramisu",
                "Tiramisu maison, crème mascarpone, café, cacao et biscuits à la cuillère.",
                Nutriscore.D,
                false
                );

            // Adding samples
            this.SamplePizzas.AddRange(new List<Pizza> { pizza1, pizza2, pizza3 });
            this.SamplePastas.AddRange(new List<PastaBox> { pasta1, pasta2, pasta3 });
            this.SampleSweets.AddRange(new List<Sweet> { sweet1, sweet2, sweet3 });
            this.SampleSweets.Add(sweet4);

        }

        public List<Pizza> GetSamplePizzas()
        {
            return this.SamplePizzas;
        }

        public List<PastaBox> GetSamplePastas()
        {
            return this.SamplePastas;
        }

        public List<Sweet> GetSampleSweets()
        {
            return this.SampleSweets;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Bonjour, nous somme le " + DateTime.Today.ToString("dd/MM/yyyy", new CultureInfo("FR-fr")) + " il est " +
                      DateTime.Now.ToString("HH:mm", new CultureInfo("FR-fr")) + "\n"
                      );
            sb.Append("Il y a actuellement " + this.Orders.Count + " commandes enregistrées pour un total de " +
                      this.Orders.Sum(order => order.GetMeals().Count) + " plats. \nDont " +
                      this.Orders.Sum(order => order.GetMeals().OfType<Pizza>().Count()) + " pizzas, " +
                      this.Orders.Sum(order => order.GetMeals().OfType<PastaBox>().Count()) + " pastabox et " +
                      this.Orders.Sum(order => order.GetMeals().OfType<Sweet>().Count()) + " desserts.\n"
                      );
            sb.Append("-----------------------------------------------------------\n");
            foreach (Order order in this.Orders)
            {
                sb.Append(order.ToString());
                sb.Append("-----------------------------------------------------------\n");
            }

            return sb.ToString();

        }

        // Added Personnal Feature

        public Order GetLastOrder()
        {
            return this.Orders.Last();
        }

        public void Start()
        {
            char? choice;
            int i = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Menu Principal\n" +
                                  "- Créer Commande (C)\n" +
                                  "- Voir Liste des Commandes (L)\n" +
                                  "- Quitter (X)");
                try
                {
                    choice = Console.ReadLine().ToUpper()[0];
                }
                catch (IndexOutOfRangeException)
                {
                    choice = null;
                }
                switch (choice)
                {
                    case 'C':
                        this.CreateOrder();
                        Order currentOrder = this.GetLastOrder();
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Commande");
                            Console.WriteLine("- Ajouter Pizza (1)");
                            Console.WriteLine("- Ajouter PastaBox (2)");
                            Console.WriteLine("- Ajouter Dessert (3)");
                            Console.WriteLine("- Retour (R)");
                            try
                            {
                                choice = Console.ReadLine().ToUpper()[0];
                            }
                            catch (IndexOutOfRangeException)
                            {
                                choice = null;
                            }
                            switch (choice)
                            {
                                case '1':
                                    do
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Liste des Pizzas");
                                        i = 0;
                                        foreach (Pizza pizza in this.SamplePizzas)
                                        {
                                            Console.WriteLine("- Pizza : " + pizza.GetName() + " (" + (i + 1) + ")");
                                            i++;
                                        }
                                        Console.WriteLine("- Voir Descriptions (D)");
                                        Console.WriteLine("- Annuler (A)");
                                        try
                                        {
                                            choice = Console.ReadLine().ToUpper()[0];
                                        }
                                        catch (IndexOutOfRangeException)
                                        {
                                            choice = null;
                                        }
                                        switch (choice)
                                        {
                                            case 'A':
                                                break;
                                            case 'D':
                                                Console.Clear();
                                                Console.WriteLine("-----------------------------------------------------------");
                                                foreach (Pizza pizza in this.SamplePizzas)
                                                {
                                                    Console.WriteLine(pizza.ToString());
                                                    Console.WriteLine("-----------------------------------------------------------");
                                                }
                                                Console.WriteLine("Appuyez sur une touche pour continuer...");
                                                Console.ReadKey();
                                                break;
                                            default:
                                                if (choice == null)
                                                {
                                                    break;
                                                }
                                                string whitelist = new string("123456789");
                                                string safechoice = new string(choice.ToString().Where(c => whitelist.Contains(c)).ToArray());
                                                if (safechoice != "")
                                                {
                                                    int value = Int32.Parse(safechoice);
                                                    if (value >= 1 && value < this.SamplePizzas.Count + 1)
                                                    {
                                                        currentOrder.AddMeal((IMeal)this.SamplePizzas[value - 1]);
                                                    }
                                                }
                                                break;
                                        }
                                    } while (choice != 'A');
                                    break;

                                case '2':
                                    do
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Liste des PastaBox");
                                        i = 0;
                                        foreach (PastaBox pastaBox in this.SamplePastas)
                                        {
                                            Console.WriteLine("- PastaBox : " + pastaBox.GetName() + " (" + (i + 1) +
                                                              ")");
                                            i++;
                                        }

                                        Console.WriteLine("- Voir Descriptions (D)");
                                        Console.WriteLine("- Annuler (A)");
                                        try
                                        {
                                            choice = Console.ReadLine().ToUpper()[0];
                                        }
                                        catch (IndexOutOfRangeException)
                                        {
                                            choice = null;
                                        }

                                        switch (choice)
                                        {
                                            case 'A':
                                                break;
                                            case 'D':
                                                Console.Clear();
                                                Console.WriteLine(
                                                    "-----------------------------------------------------------");
                                                foreach (PastaBox pastaBox in this.SamplePastas)
                                                {
                                                    Console.WriteLine(pastaBox.ToString());
                                                    Console.WriteLine(
                                                        "-----------------------------------------------------------");
                                                }

                                                Console.WriteLine("Appuyez sur une touche pour continuer...");
                                                Console.ReadKey();
                                                break;
                                            default:
                                                if (choice == null)
                                                {
                                                    break;
                                                }
                                                string whitelist = new string("123456789");
                                                string safechoice = new string(choice.ToString().Where(c => whitelist.Contains(c)).ToArray());
                                                if (safechoice != "")
                                                {
                                                    int value = Int32.Parse(safechoice);
                                                    if (value >= 1 && value < this.SamplePastas.Count + 1)
                                                    {
                                                        currentOrder.AddMeal((IMeal)this.SamplePastas[value - 1]);
                                                    }
                                                }

                                                break;
                                        }
                                    } while (choice != 'A');
                                    break;

                                case '3':
                                    do
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Liste des Desserts");
                                        i = 0;
                                        foreach (Sweet sweet in this.SampleSweets)
                                        {
                                            Console.WriteLine("- Dessert : " + sweet.GetName() + " (" + (i + 1) + ")");
                                            i++;
                                        }
                                        Console.WriteLine("- Voir Descriptions (D)");
                                        Console.WriteLine("- Annuler (A)");
                                        try
                                        {
                                            choice = Console.ReadLine().ToUpper()[0];
                                        }
                                        catch (IndexOutOfRangeException)
                                        {
                                            choice = null;
                                        }

                                        switch (choice)
                                        {
                                            case 'A':
                                                break;
                                            case 'D':
                                                Console.Clear();
                                                Console.WriteLine("-----------------------------------------------------------");
                                                foreach (Sweet sweet in this.SampleSweets)
                                                {
                                                    Console.WriteLine(sweet.ToString());
                                                    Console.WriteLine("-----------------------------------------------------------");
                                                }
                                                Console.WriteLine("Appuyez sur une touche pour continuer...");
                                                Console.ReadKey();
                                                break;
                                            default:
                                                if (choice == null)
                                                {
                                                    break;
                                                }
                                                string whitelist = new string("123456789");
                                                string safechoice = new string(choice.ToString().Where(c => whitelist.Contains(c)).ToArray());
                                                if (safechoice != "")
                                                {
                                                    int value = Int32.Parse(safechoice);
                                                    if (value >= 1 && value < this.SampleSweets.Count + 1)
                                                    {
                                                        currentOrder.AddMeal((IMeal)this.SampleSweets[value - 1]);
                                                    }
                                                }
                                                break;
                                        }
                                    } while (choice != 'A');
                                    break;

                                case 'R':
                                    break;
                            }
                        } while (choice != 'R');
                        if (currentOrder.isEmpty())
                        {
                            this.Orders.Remove(currentOrder);
                        }
                        break;
                    case 'L':
                        Console.Clear();
                        Console.WriteLine(this.ToString());
                        Console.WriteLine("Appuyez sur une touche pour continuer...");
                        Console.ReadKey();
                        break;
                    case 'X':
                        Console.WriteLine("Au revoir !");
                        break;
                    default:
                        Console.WriteLine("Choix invalide !");
                        break;
                }
            } while (choice != 'X');
        }
    }
}
