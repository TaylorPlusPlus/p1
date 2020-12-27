using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models
{
    public class Ham : AToppingModel
    {
        protected override void AddName()
        {
            Name = "Ham";
        }
        protected override void AddPrice()
        {
            Price = "1.75";
        }
    }
}