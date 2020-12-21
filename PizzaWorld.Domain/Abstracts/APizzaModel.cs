using System.Collections.Generic;
using System;
namespace PizzaWorld.Domain.Abstracts
{
    public abstract class APizzaModel
    {

        // three fields
        public string Crust { get; set;}
        public string Size { get; set;}
        public List<string> Toppings{get; set;}
        // a constructor that calls the three methods to set the fields
        protected APizzaModel()
        {
            AddCrust();
            AddSize();
            AddToppings();
        }
        // three methods that set the properties uniquely to the implementation
        protected void AddCrust(){
            Crust = "Original";
        }
        protected void AddSize()
        {
             Console.WriteLine("Choose Size: Small, Medium, Large, XLarge");
              string size = Console.ReadLine();
        }
        protected virtual void AddToppings(){}

    }
}