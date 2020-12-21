using PizzaWorld.Domain.Abstracts;
using System.Collections.Generic;
namespace PizzaWorld.Domain.Models
{
    public class GreekPizza : APizzaModel
    {
        protected override void AddToppings()
        {
            Toppings = new List<string>{
                "Olives",
                "Garlic",
                "Feta"
            };
        }
    }
}