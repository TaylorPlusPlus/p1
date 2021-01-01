using System.Collections.Generic;
using PizzaWorld.Domain.Abstracts;


namespace PizzaWorld.Domain.Models
{
    
    public class HawaiianPizza : APizzaModel
    {
     
        // override the methods 
       protected override void AddToppings()
        {
             Toppings = new List<AToppingModel>{
                topping.Make<Ham>(),
                topping.Make<PineApple>()
            };
        }
        protected override void AddCrust()
        {
            Crust = crust.Make<OriginalCrust>();
        }
    
    }
}