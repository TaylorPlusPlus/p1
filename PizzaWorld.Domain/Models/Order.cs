using System;
using System.Collections.Generic;
using System.Linq;
using PizzaWorld.Domain.Abstracts;
using PizzaWorld.Domain.Factories;

namespace PizzaWorld.Domain.Models
{
    public class Order : AEntity
    {

        private GenericPizzaFactory _pizzaFactory = new GenericPizzaFactory();

       public List<APizzaModel> Pizzas {get; set;}

      // public long UserId{get;set;}
       public User User {get; set;}
      // public long StoreEntityId{get;set;}
       public Store Store {get;set;}

       public DateTime PurchaseDate {get; set;}


        public Order()
        {
            Pizzas = new List<APizzaModel>();
        }


        public override string ToString()
        {
            
            string returnString = "Order number: " + EntityId + "\n";
            
            foreach(APizzaModel pizza in Pizzas)
            {
                returnString += pizza.ToString() + "\n";
            }

            returnString += "Total Order Cost: " + CalculatePrice() + "\n";

            return returnString;
        }


        public decimal CalculatePrice()
        {
            decimal ReturnPrice = 0;

            foreach(APizzaModel pizza in Pizzas)
           {
                ReturnPrice += pizza.CalculateTotalCost();
            }
            return ReturnPrice;
        }
        
        public void MakeMeatPizza()
        {
            //requirement: An order can only have 50 pizza's
            if(ValidateUnderPizzaLimit())
            {
                Pizzas.Add(_pizzaFactory.Make<MeatPizza>());
            }
            ValidateUnderPriceLimit();
        }

         public void MakeHawaiianPizza()
        {
            //requirement: An order can only have 50 pizza's
            if(ValidateUnderPizzaLimit())
            {
                Pizzas.Add(_pizzaFactory.Make<HawaiianPizza>());
            }
            ValidateUnderPriceLimit();
        }
        
        public void MakeGreekPizza()
        {
             //requirement: An order can only have 50 pizza's
            if(ValidateUnderPizzaLimit())
            {
                Pizzas.Add(_pizzaFactory.Make<GreekPizza>());
            }
            ValidateUnderPriceLimit();
        }
        public bool ValidateUnderPizzaLimit()
        {
            // add this before
            if(Pizzas.Count > 50)
            {
             //   Console.WriteLine("You already have the maximum 50 pizza's in your order");
                return false;
            }
            return true;
        }
        public bool ValidateUnderPriceLimit()
        {
             // add this after the user has choosen their pizza
            if(CalculatePrice() > 250.00m)
            {
            //   Console.WriteLine("Your order can not be more than $250");
                Pizzas.Remove(Pizzas.Last());
                return false;
            }
            return true;
        }

    }
}