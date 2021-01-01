using System.Collections.Generic;
using PizzaWorld.Domain.Abstracts;
using System;
namespace  PizzaWorld.Domain.Models
{
    public class MeatPizza : APizzaModel
    {
        protected override void AddCrust()
        {
            Crust = crust.Make<StuffedCrust>();
        }
        
        protected override void AddToppings()
        {
           // Toppings = new List<AToppingModel>();
           // Toppings.Add()
           Toppings = new List<AToppingModel>{
                topping.Make<Sausage>(),
                topping.Make<Ham>()
            };
        }
        
    }
}