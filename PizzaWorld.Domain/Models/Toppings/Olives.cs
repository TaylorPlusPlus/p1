using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models
{
    public class Olives : AToppingModel
    {
        protected override void AddName()
        {
            Name = "Olives";
        }
        protected override void AddPrice()
        {
            Price = 1.40m;
        }
    }
}