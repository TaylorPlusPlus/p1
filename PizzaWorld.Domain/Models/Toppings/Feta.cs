using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models
{
    public class Feta : AToppingModel
    {
        protected override void AddName()
        {
            Name = "Feta";
        }
        protected override void AddPrice()
        {
            Price = "1.60";
        }
    }
}