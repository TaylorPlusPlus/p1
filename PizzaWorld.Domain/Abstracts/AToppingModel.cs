using System.Collections.Generic;
using System;
namespace PizzaWorld.Domain.Abstracts
{
    public class AToppingModel : AEntity
    {

        // three fields
        public string Name { get; set;}
        public decimal Price { get; set;}
        //public List<S> Toppings{get; set;}
        // a constructor that calls the three methods to set the fields
       protected AToppingModel()
        {
            AddName();
            AddPrice();
        }
        // three methods that set the properties uniquely to the implementation
        
        protected virtual void AddName(){}

        protected virtual void AddPrice(){}

        public override string ToString()
        {
            return $"Name: {Name} Price: {Price}";
        }

    }
}