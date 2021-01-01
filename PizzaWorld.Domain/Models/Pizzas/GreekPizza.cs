using PizzaWorld.Domain.Abstracts;
using System.Collections.Generic;
using PizzaWorld.Domain.Factories;
using System;
namespace PizzaWorld.Domain.Models
{
    public class GreekPizza : APizzaModel
    {

       
        protected override void AddCrust()
        {
            Crust = crust.Make<OriginalCrust>();
        }

        protected override void AddToppings()
        {
            Toppings = new List<AToppingModel>{
                topping.Make<Feta>(),
                topping.Make<Olives>()
            };
        }
        
    }
}