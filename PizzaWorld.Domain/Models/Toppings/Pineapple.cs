using PizzaWorld.Domain.Abstracts;

namespace PizzaWorld.Domain.Models
{
    public class PineApple : AToppingModel
    {
        protected override void AddName()
        {
            Name = "Pineapple";
        }
        protected override void AddPrice()
        {
            Price = "1.25";
        }
    }
}