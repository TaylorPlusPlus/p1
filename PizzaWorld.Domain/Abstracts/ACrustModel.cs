using System.Collections.Generic;
using System;
namespace PizzaWorld.Domain.Abstracts
{
    public class ACrustModel : AEntity
    {

        // three fields
        public string Name { get; set;}
        public decimal Price { get; set;}
        
       protected ACrustModel()
        {
            AddName();
            AddPrice();
        }
        // three methods that set the properties uniquely to the implementation
        
        protected virtual void AddName(){}

        protected virtual void AddPrice(){}

        public override string ToString()
        {
            return $"{Name} Price: {Price}";
        }

    }
}