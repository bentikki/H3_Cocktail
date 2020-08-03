using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H3_Cocktail
{
    class Program
    {
        static void Main(string[] args)
        {

            DrinkCard mainDrinkCard = new DrinkCard("Main Card");

            mainDrinkCard.AddDrink(
                new Drink(
                        "Margarita",
                        new Dictionary<Ingridient, int>()
                        {
                            { new Ingridient("Lime Juice"), 60 },
                            { new Ingridient("Triple Sec"), 30 },
                            { new Ingridient("Tequila"), 60 },
                        },
                        new List<Accessory>()
                        {
                            new Accessory("Salt rim"),
                            new Accessory("Crushed Ice"),
                            new Accessory("lime segment")
                        }
                    )
                );


            mainDrinkCard.AddDrink(
                new Drink(
                        "Mai Tai",
                        new Dictionary<Ingridient, int>()
                        {
                            { new Ingridient("Dark Rum"), 50 },
                            { new Ingridient("Orange Curacao"), 15 },
                            { new Ingridient("Lime juice"), 10 },
                            { new Ingridient("Almond Syrup"), 60 },
                        },
                        new List<Accessory>()
                        {
                            new Accessory("lime section"),
                            new Accessory("maraschino cherry"),
                            new Accessory("lime segment")
                        }
                    )
                );


            Console.WriteLine("Drink card: " + mainDrinkCard.NameOfCard);
            Console.WriteLine("Available drinks:");
            Console.WriteLine("__________________________________________");
            foreach (Drink drink in mainDrinkCard.Drinks)
            {
                Console.WriteLine(drink.Name);
                Console.WriteLine("Ingridients:");
                foreach (var ingridient in drink.Ingridients)
                {
                    Console.WriteLine($"{ingridient.Key.Name} {ingridient.Value}ml");
                }
                Console.WriteLine();
                Console.WriteLine("Accesories:");
                StringBuilder accString = new StringBuilder();
                string delimiter = string.Empty;
                foreach (var ingridient in drink.Accessories)
                {
                    accString.Append(delimiter);
                    accString.Append(ingridient.Name);
                    delimiter = ",";
                }
                Console.WriteLine(accString);
                Console.WriteLine("_______________________");
            }
            Console.WriteLine();

            Console.ReadKey();

        }
    }

    class DrinkCard
    {
        public string NameOfCard { get; private set; }
        public List<Drink> Drinks { get; private set; }

        public DrinkCard(string name)
        {
            this.NameOfCard = name;
            this.Drinks = new List<Drink>();
        }

        public DrinkCard(string name, List<Drink> drinks) : this(name)
        {
            this.Drinks = drinks;
        }

        public void AddDrink(Drink drinkToAdd)
        {
            this.Drinks.Add(drinkToAdd);
        }
    }

    class Drink
    {
        public string Name { get; private set; }
        public Dictionary<Ingridient, int> Ingridients { get; private set; }
        public List<Accessory> Accessories{ get; private set; }

        public Drink(string name, Dictionary<Ingridient, int> ingridients, List<Accessory> accessories)
        {
            Name = name.ToUpper();
            Ingridients = ingridients;
            Accessories = accessories;
        }
    }

    class Ingridient
    {
        public string Name { get; private set; }

        public Ingridient(string name)
        {
            Name = name.ToUpper();
        }
    }

    class Accessory
    {
        public string Name { get; private set; }

        public Accessory(string name)
        {
            Name = name.ToLower();
        }

    }

}
